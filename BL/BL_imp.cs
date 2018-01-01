using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
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
            throw new NotImplementedException();
        }

        public void addMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void addNanny(Nanny nanny)
        {
            if(nanny.Birthday.Year==)
            dal.addNanny(nanny);
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
