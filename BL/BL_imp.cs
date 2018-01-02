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
    class BL_imp : IBL
    {
        Dal_imp dal = new Dal_imp();
        // Mother function
        #region
        public void addMother(Mother mom)
        {
            dal.addMother(mom);
        }
        public void removeMother(Mother mom)
        {
            dal.removeMother(mom);
            foreach (Child item in dal.getChildList(mom))
                removeChild(item);
        }
        public void updateMother(Mother mom)
        {
            dal.updateMother(mom);
        }
        public List<Mother> getMotherList()
        {
            return dal.getMotherList();
        }
        #endregion
        // Contract function
        #region
        public void addContract(Contract contract)
        {
            try
            {
                int countContracts = 0;
                foreach (Child item in DataSource.ChildList)
                {
                    if (item.Id == contract.ChildID)
                        if (DateTime.Now.Month - item.Birthday.Month + (DateTime.Now.Year - item.Birthday.Year) * 12 < 3)
                            throw new Exception();
                }
                foreach (Contract item in getContractList())
                {
                    if (item.BabySitterID == contract.BabySitterID)
                        countContracts++;
                }
                dal.addContract(contract);

            }
        }
        public void removeContract(Contract contract)
        {
            throw new NotImplementedException();
        }
        public void updateContract(Contract contract)
        {
            throw new NotImplementedException();
        }
        public List<Contract> getContractList()
        {
            return dal.getContractList();
        }
        #endregion
        // Nanny function
        #region
        public void addNanny(Nanny nanny)
        {
            try
            {
                //בודק את גיל המטפלת
                if (DateTime.Now.Year - nanny.Birthday.Year < 18)//שנים
                    throw new Exception("");
                else if (DateTime.Now.Year - nanny.Birthday.Year == 18 && DateTime.Now.Month - nanny.Birthday.Month < 0)//חודשים
                    throw new Exception("");
                else if (DateTime.Now.Year - nanny.Birthday.Year == 18 && DateTime.Now.Month - nanny.Birthday.Month == 0 
                    && DateTime.Now.Day - nanny.Birthday.Day < 0)//ימים
                    throw new Exception("");
                dal.addNanny(nanny);
            }
        }
        public void removeNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }
        public void updateNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }
        public List<Nanny> getNannyList()
        {
            return dal.getNannyList();
        }
        #endregion
        // child function
        #region
        public void addChild(Child child)
        {
            dal.addChild(child);
        }
        public void removeChild(Child child)
        {

        }
        public void updateChild(Child child)
        {
            dal.updateChild(child);
        }
        public List<Child> getChildList(Mother mother)
        {
            return dal.getChildList(mother);
        }
        #endregion
    }
}
