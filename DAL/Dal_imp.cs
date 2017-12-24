using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;
namespace DAL
{
    class Dal_imp : Idal
    {
        private static int contratNumber = 10000000;
        /// <summary>
        /// Nanny function
        /// </summary>
        /// <param name="nanny"></param>
        #region
        public void addNanny(Nanny nanny)
        {
            try
            {
                foreach (Nanny item in getNannyList())
                {
                    if (item.Id == nanny.Id)
                        throw new Exception();
                }
                getNannyList().Add(nanny);
            }
        }
        public List<Nanny> getNannyList()
        {
            return DataSource.NannyList;
        }
        public void removeNanny(Nanny nanny)
        {
            bool flag = true;
            try
            {
                foreach (Nanny item in getNannyList())
                {
                    if (item.Id == nanny.Id)//if find id to delete
                        flag = false;
                }
                if (flag)//id to delete not found throw Exception
                    throw new Exception();
                getNannyList().Remove(nanny);
            }
        }
        void updateNanny(Nanny nanny)
        {
            bool flag = true;
            try
            {
                foreach (Nanny item in getNannyList())
                {
                    if (item.Id == nanny.Id)//if find id to update
                        flag = false;
                }
                if (flag)//id to update not found throw Exception
                    throw new Exception();
                removeNanny(nanny);//delete the old mother
                addNanny(nanny);//insert the update mother

            }

        }
        #endregion
        /// <summary>
        /// Mother function
        /// </summary>
        /// <param name="mother"></param>
        #region
        public void addMother(Mother mother)
        {
            try
            {
                foreach (Mother item in getMotherList())
                {
                    if (item.Id == mother.Id)
                        throw new Exception();
                }
                getMotherList().Add(mother);
            }
        }
        public List<Mother> getMotherList()
        {
            return DataSource.MotherList;
        }
        public void removeMother(Mother mother)
        {
            bool flag = true;
            try
            {
                foreach (Mother item in getMotherList())
                {
                    if (item.Id == mother.Id)//if find id to delete
                        flag =false;
                }
                if (flag)//id to delete not found throw Exception
                    throw new Exception();
                getMotherList().Remove(mother);
            }
        }
        void updateMother(Mother mother)
        {
            bool flag = true;
            try
            {
                foreach (Mother item in getMotherList())
                {
                    if (item.Id == mother.Id)//if find id to update
                        flag = false;
                }
                if (flag)//id to update not found throw Exception
                    throw new Exception();
                removeMother(mother);//delete the old mother
                addMother(mother);//insert the update mother

            }

        }
        #endregion
        //Child function
        #region
        public void addChild(Child child)
        {
            try
            {
                bool flag = true;
                foreach (Child item in getChildList())
                {
                    if (item.Id == child.Id)
                        throw new Exception();
                }
                foreach (Mother item in getMotherList())
                {
                    if (item.Id == child.MotheId)
                        flag = false;
                }
                if (flag)
                    throw new Exception();
                getChildList().Add(child);
            }
        }
        public List<Child> getChildList()
        {
            return DataSource.ChildList;
        }
        public void removeChild(Child child)
        {
            bool flag = true;
            try
            {
                foreach (Child item in getChildList())
                {
                    if (item.Id == child.Id)//if find id to delete
                        flag = false;
                }
                if (flag)//id to delete not found throw Exception
                    throw new Exception();
                getChildList().Remove(child);
            }
        }
        void updateChild(Child child)
        {
            bool flag = true;
            try
            {
                foreach (Child item in getChildList())
                {
                    if (item.Id == child.Id)//if find id to update
                        flag = false;
                }
                if (flag)//id to update not found throw Exception
                    throw new Exception();
                removeChild(child);//delete the old mother
                addChild(child);//insert the update mother
            }

        }
        #endregion
        //contract function
        #region
        public void addContract(Contract contract)
        {
            try
            {
                bool flag = true;
                foreach (Child item in getChildList())
                {
                    if (item.Id==contract.ChildID)
                        flag=false;
                }
                if (flag)
                    throw new Exception();
                flag = true;
                foreach (Nanny item in getNannyList())
                {
                    if (item.Id == contract.BabySitterID)
                        flag = false;
                }
                if (flag)
                    throw new Exception();
                contract.ContractID = contratNumber.ToString();
                contratNumber++;
                getContractList().Add(contract);
            }
        }
        public List<Contract> getContractList()
        {
            return DataSource.ContractList;
        }
        public void removeContract(Contract contract)
        {
            bool flag = true;
            try
            {
                foreach (Contract item in getContractList())
                {
                    if (item.ContractID == contract.ContractID)//if find id to delete
                        flag = false;
                }
                if (flag)//id to delete not found throw Exception
                    throw new Exception();
                getContractList().Remove(contract);
            }
        }
        void updateContract(Contract contract)
        {
            bool flag = true;
            try
            {
                foreach (Contract item in getContractList())
                {
                    if (item.ContractID == contract.ContractID)//if find id to update
                        flag = false;
                }
                if (flag)//id to update not found throw Exception
                    throw new Exception();
                removeContract(contract);//delete the old mother
                addContract(contract);//insert the update mother
            }

        }
        #endregion

    }
}
