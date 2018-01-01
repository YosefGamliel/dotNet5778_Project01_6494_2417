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

        public void addChild(Child child)
        {
            dal.addChild(child);
        }

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
        public void addMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void addNanny(Nanny nanny)
        {
            try
            {
                //בודק את גיל המטפלת
                if (nanny.Birthday.Year - DateTime.Now.Year < 18)//שנים
                    throw new Exception("");
                if (nanny.Birthday.Year - DateTime.Now.Year == 18 && nanny.Birthday.Month - DateTime.Now.Month > 0)//חודשים
                    throw new Exception("");
                if (nanny.Birthday.Year - DateTime.Now.Year == 18 && nanny.Birthday.Month - DateTime.Now.Month == 0)//ימים
                    if (nanny.Birthday.Day - DateTime.Now.Day > 0)
                        throw new Exception("");

                dal.addNanny(nanny);

            }
        }

        public List<Child> getChildList(Mother mother)
        {
            throw new NotImplementedException();
        }

        public List<Contract> getContractList()
        {
            throw new NotImplementedException();
        }

        public List<Mother> getMotherList()
        {
            throw new NotImplementedException();
        }

        public List<Nanny> getNannyList()
        {
            throw new NotImplementedException();
        }

        public void removeChild(Child child)
        {
            throw new NotImplementedException();
        }

        public void removeContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void removeMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void removeNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        public void updateChild(Child child)
        {
            throw new NotImplementedException();
        }

        public void updateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void updateMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }
    }
}
