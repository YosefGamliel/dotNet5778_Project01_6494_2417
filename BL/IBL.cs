using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
     public interface IBL
    {
        #region Mother function

        void addMother(Mother mom);
        void removeMother(Mother mom);
        void updateMother(Mother mom);
        List<Mother> getMotherList();
        #endregion
        #region Contract function
        void addContract(Contract contract);
        void removeContract(Contract contract);
        void updateContract(Contract contract);
        List<Contract> getContractList();
        #endregion
        #region Nanny function
        void addNanny(Nanny nanny);
        void removeNanny(Nanny nanny);
        void updateNanny(Nanny nanny);
        List<Nanny> getNannyList();
        #endregion
        #region child function
        void addChild(Child child);
        void removeChild(Child child);
        void updateChild(Child child);
        List<Child> getChildList(Mother mother);
        List<Child> getChildList();
        #endregion
    }
}
