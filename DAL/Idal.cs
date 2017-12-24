using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        /// <summary>
        /// Mother function
        /// </summary>
        /// <param name="mom"></param>
        #region
        void addMother(Mother mom);
        void removeMother(Mother mom);
        void updateMother(Mother mom);
        List<Mother> getMotherList();
        #endregion
        /// <summary>
        /// Contract function
        /// </summary>
        /// <param name="contract"></param>
        #region
        void addContract(Contract contract);
        void removeContract(Contract contract);
        void updateContract(Contract contract);
        List<Contract> getContractList();
        #endregion
        /// <summary>
        /// Nanny function
        /// </summary>
        /// <param name="nanny"></param>
        #region
        void addNanny(Nanny nanny);
        void removeNanny(Nanny nanny);
        void updateNanny(Nanny nanny);
        List<Nanny> getNannyList();
        #endregion
        /// <summary>
        /// child function
        /// </summary>
        /// <param name="child"></param>
        #region
        void addChild(Child child);
        void removeChild(Child child);
        void updateChild(Child child);
        List<Child> getChildList();
        #endregion


    }
}
