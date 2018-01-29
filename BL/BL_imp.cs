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
    /// <summary>
    /// Realizing of the Basic Action
    /// Of our Program
    /// </summary>
    public class BL_imp : IBL
    {
        Idal dal = FactoryDal.GetDal();//
        #region MOTHER
        public void addMother(Mother mom)
        {
            dal.addMother(mom);
        }
        public void removeMother(Mother mom)
        {
            //delete the mother's children
            foreach (Child item in dal.getChildList(mom))
                removeChild(item);
            dal.removeMother(mom);
        }
        public void updateMother(Mother mom)
        {
            //delete the old mother
            dal.removeMother(mom);
            //add the update Mother
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
            double[] sumOfHourinWeek = new double[6];
            double sumOfHourinMonth = 0;
            TimeSpan[,] NannyWorkHour = new TimeSpan[6, 2];//save the Nanny working hours
            TimeSpan[,] MotherWorkHour = new TimeSpan[6, 2];////save the Mother working hours
            TimeSpan[,] commonWorkHour = new TimeSpan[6, 2];////save the Common working hours
            int sumOfChild = 0, childAge = 0;
            //check  if the child is older than 3 month
            foreach (Child item in getChildList())
            {
                if (item.Id == contract.ChildID)
                {
                    childAge = DateTime.Now.Month - item.Birthday.Month + (DateTime.Now.Year - item.Birthday.Year) * 12;
                    if (childAge < 3)
                        throw new Exception("child age can not be under 3 months");
                }
            }
            foreach (Nanny item in getNannyList())
            {
                //check max kids,if OK-add one to Nanny numOfkIDS.
                if (item.Id == contract.BabySitterID)
                {
                    if (item.NumOfKids + 1 > item.MaxKids)
                        throw new Exception("this nanny can not have more childs");
                    if (childAge < item.MinAge)
                        throw new Exception("this nanny doesn't take care of this age");
                    if (childAge > item.MaxAge)
                        throw new Exception("this nanny doesn't take care of this ages");
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
                    MotherWorkHour = item.WorkHours;//Find The requested mother
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
                        NannyWorkHour = item.WorkHours;//Find The requested Nanny
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    commonWorkHour[i, 0] = MyFunctions.max(MotherWorkHour[i, 0], NannyWorkHour[i, 0]);
                    commonWorkHour[i, 1] = MyFunctions.min(MotherWorkHour[i, 1], NannyWorkHour[i, 1]);
                    sumOfHourinWeek[i] = MyFunctions.dif(commonWorkHour[i, 0], commonWorkHour[i, 1]);
                }//calculating the common hour
                for (int i = 0; i < 6; i++) //calculating how much hour in week 
                    sumOfHourinMonth = MyFunctions.sum(sumOfHourinMonth, sumOfHourinWeek[i]);
                if (sumOfChild == 1)//no brothers-no discount
                    contract.Payment = sumOfHourinMonth * 4 * contract.SalaryPerHour;
                else
                    contract.Payment = sumOfHourinMonth * 4 * contract.SalaryPerHour * (1 - contract.Discount);
            }
            else
                contract.Payment = contract.SalaryPerMonth * (1 - contract.Discount);
            #endregion
            dal.addContract(contract);//all right, add the contract
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
            //like Mother Update
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
            //Check the Nanny age
            if (DateTime.Now.Year - nanny.Birthday.Year < 18)//שנים
                throw new Exception("age of nanny can't be under 18");
            if (DateTime.Now.Year - nanny.Birthday.Year == 18 && DateTime.Now.Month - nanny.Birthday.Month < 0)//חודשים
                throw new Exception("age of nanny can't be under 18");
            if (DateTime.Now.Year - nanny.Birthday.Year == 18 && DateTime.Now.Month - nanny.Birthday.Month == 0
                && DateTime.Now.Day - nanny.Birthday.Day < 0)//ימים
                throw new Exception("age of nanny can't be under 18");
            dal.addNanny(nanny);
        }
        public void removeNanny(Nanny nanny)
        {
            //delete all Contract that this Nanny sign on
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
            //if the new max kids is little than the current amount of her kids
            if (nanny.NumOfKids > nanny.MaxKids)
                throw new Exception("this nanny have more childs than what she can");
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
            bool flag = false;
            Contract toDelete = new Contract();
            //delete the contract the]at child sign on
            foreach (Contract item in getContractList())
            {
                if (item.ChildID == child.Id)
                {
                    flag = true;
                    toDelete = item;
                }
            }
            if (flag)
                removeContract(toDelete);
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
