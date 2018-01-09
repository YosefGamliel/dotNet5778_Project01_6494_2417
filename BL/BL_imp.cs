using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DS;
namespace BL
{
    public class BL_imp : IBL
    {
        Dal_imp dal = new Dal_imp();
        #region MOTHER
        public void addMother(Mother mom)
        {
            dal.addMother(mom);
        }
        public void removeMother(Mother mom)
        {
            foreach (Child item in dal.getChildList(mom))
                removeChild(item);
            dal.removeMother(mom);
        }
        public void updateMother(Mother mom)
        {
            dal.removeMother(mom);
            addMother(mom);
        }
        public List<Mother> getMotherList()
        {
            return dal.getMotherList();
        }
        #endregion
        #region CONTRACT
        public void addContract(Contract contract)
        {
            float[] sumOfHourinWeek = new float[6];
            float sumOfHourinMonth = 0;
            float[,] NannyWorkHour = new float[6, 2];//לשמור את השעות עבודה של המטפלת
            float[,] MotherWorkHour = new float[6, 2];//לשמור את השעות עבודה של האמא
            float[,] commonWorkHour = new float[6, 2];//לשמור את השעות עבודה של המטפלת
            int sumOfChild = 0, childAge = 0;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == contract.ChildID)
                {
                    childAge = DateTime.Now.Month - item.Birthday.Month + (DateTime.Now.Year - item.Birthday.Year) * 12;
                    if (childAge < 3)
                        throw new Exception();
                }
            }
            foreach (Nanny item in getNannyList())
            {
                //check max kids,if OK-add one to Nanny numOfkIDS.
                if (item.Id == contract.BabySitterID)
                {
                    if (item.NumOfKids + 1 > item.MaxKids)
                        throw new Exception();
                    if (childAge < item.MinAge)
                        throw new Exception();
                    if (childAge > item.MaxAge)
                        throw new Exception();
                    item.NumOfKids++;
                }
            }
            //calculating the payment
            #region
            foreach (var item in getNannyList())
            {
                if (item.Id==contract.BabySitterID)
                {
                    contract.SalaryPerHour = item.HourSalary;
                    contract.SalaryPerMonth = item.MonthSalary;
                    contract.SalaryType = item.HourlyRate;
                }
            }
            foreach (var item in getMotherList()) //find the mother
            {
                if (MyFunctions.FindMother(contract.ChildID).Id == item.Id)
                {
                    MotherWorkHour = item.WorkHours;//מוצא את האמא המדוברת
                    //using in item (mother )to find how many brothers with same nanny
                    sumOfChild = MyFunctions.numOfChildInBabySitter(getChildList(item), contract.BabySitterID);
                }
            }
            contract.Discount = (float)(0.02 * (sumOfChild - 1));
            if (contract.SalaryType) //per hour
            {
                foreach (var item in getNannyList())
                {
                    if (contract.BabySitterID == item.Id)
                    {
                        NannyWorkHour = item.WorkHours;//מוצא את העוזרת המדוברת
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    commonWorkHour[i, 0] = MyFunctions.max(MotherWorkHour[i, 0], NannyWorkHour[i, 0]);
                    commonWorkHour[i, 1] = MyFunctions.min(MotherWorkHour[i, 1], NannyWorkHour[i, 1]);
                    sumOfHourinWeek[i] = MyFunctions.dif(commonWorkHour[i, 0], commonWorkHour[i, 1]);
                }//מחשב כמה שעות עבודה יש ביום הכולל עבודה משותפת
                for (int i = 0; i < 6; i++) //מחשב את המשכורת ע"י סכימה של שעות העבודה 
                    sumOfHourinMonth = MyFunctions.sum(sumOfHourinMonth, sumOfHourinWeek[i]);
                if (sumOfChild == 1)//no brothers-no discount
                    contract.Payment = sumOfHourinMonth * 4 * contract.SalaryPerHour;
                else
                    contract.Payment = sumOfHourinMonth * 4 * contract.SalaryPerHour * (1 - contract.Discount);
            }
            else
                contract.Payment = contract.SalaryPerMonth * (1 - contract.Discount);
            #endregion
            contract.Signed = true;
            dal.addContract(contract);
        }
        public void removeContract(Contract contract)
        {
            int sumOfChild = 0;
            #region SUMOFCHILD
            foreach (var item in getMotherList()) //find the mother
            {
                if (MyFunctions.FindMother(contract.ChildID).Id == item.Id)
                    //using in item (mother )to find how many brothers with same nanny
                    sumOfChild = MyFunctions.numOfChildInBabySitter(getChildList(item), contract.BabySitterID);
            }
            #endregion
            //update the discount of the other brothers and their new payment
            foreach (var item in MyFunctions.GetContractsBy(x => x.MotherID == contract.MotherID))//lambda
            {
                if (item.Discount > contract.Discount)
                {
                    item.Payment /= (1 - item.Discount);
                    item.Discount -= (float)0.02;
                    item.Payment *= (1 - item.Discount);
                }
                MyFunctions.getNannyById(contract.BabySitterID).NumOfKids -= 1;
            }
            dal.removeContract(contract);//delete
        }
        public void updateContract(Contract contract)
        {
            removeContract(contract);
            addContract(contract);
        }
        public List<Contract> getContractList()
        {
            return dal.getContractList();
        }
        #endregion
        #region NANNY
        public void addNanny(Nanny nanny)
        {
            //בודק את גיל המטפלת
            if (DateTime.Now.Year - nanny.Birthday.Year < 18)//שנים
                throw new Exception("");
            if (DateTime.Now.Year - nanny.Birthday.Year == 18 && DateTime.Now.Month - nanny.Birthday.Month < 0)//חודשים
                throw new Exception("");
            if (DateTime.Now.Year - nanny.Birthday.Year == 18 && DateTime.Now.Month - nanny.Birthday.Month == 0
                && DateTime.Now.Day - nanny.Birthday.Day < 0)//ימים
                throw new Exception("");
            dal.addNanny(nanny);
        }
        public void removeNanny(Nanny nanny)
        {
            foreach (Contract item in getContractList())
            {
                if (item.BabySitterID == nanny.Id)
                    removeContract(item);
            }
            dal.removeNanny(nanny);
        }
        public void updateNanny(Nanny nanny)
        {
            dal.removeNanny(nanny);
            addNanny(nanny);
            if (nanny.NumOfKids > nanny.MaxKids)
                throw new Exception();
        }
        public List<Nanny> getNannyList()
        {
            return dal.getNannyList();
        }
        #endregion
        #region CHILD
        public void addChild(Child child)
        {
            dal.addChild(child);
        }
        public void removeChild(Child child)
        {
            foreach (Contract item in getContractList())
            {
                if (item.ChildID == child.Id)
                    removeContract(item);
            }
            dal.removeChild(child);
        }
        public void updateChild(Child child)
        {
            dal.removeChild(child);
            addChild(child);
        }
        public List<Child> getChildList(Mother mother)
        {
            return dal.getChildList(mother);
        }
        public List<Child> getChildList()
        {
            return dal.getChildList();
        }
        #endregion
    }
}
