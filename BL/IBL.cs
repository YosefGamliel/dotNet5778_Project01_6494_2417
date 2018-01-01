using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    interface IBL
    {
        // Mother function
        #region
        void addMother(Mother mom);
        void removeMother(Mother mom);
        void updateMother(Mother mom);
        List<Mother> getMotherList();
        #endregion
        // Contract function
        #region
        void addContract(Contract contract);
        void removeContract(Contract contract);
        void updateContract(Contract contract);
        List<Contract> getContractList();
        #endregion
        // Nanny function
        #region
        void addNanny(Nanny nanny);
        void removeNanny(Nanny nanny);
        void updateNanny(Nanny nanny);
        List<Nanny> getNannyList();
        #endregion
        // child function
        #region
        void addChild(Child child);
        void removeChild(Child child);
        void updateChild(Child child);
        List<Child> getChildList(Mother mother);
        #endregion

    }
}
