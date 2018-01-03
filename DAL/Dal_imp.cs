using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;
namespace DAL
{
    public class Dal_imp : Idal
    {
        private static int contratNumber = 10000000;
        // Nanny function
        #region
        public void addNanny(Nanny nanny)
        {
            foreach (Nanny item in getNannyList())
            {
                if (item.Id == nanny.Id)
                    throw new Exception();
            }
            getNannyList().Add(nanny);
        }
        public List<Nanny> getNannyList()
        {
            return DataSource.NannyList;
        }
        public void removeNanny(Nanny nanny)
        {
            bool flag = true;
            foreach (Nanny item in getNannyList())
            {
                if (item.Id == nanny.Id)//if find id to delete
                {
                    flag = false;
                    getNannyList().Remove(item);
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception();
        }
        public void updateNanny(Nanny nanny)
        {
            bool flag = true;
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
        #endregion
        // Mother function
        #region
        public void addMother(Mother mother)
        {
            foreach (Mother item in getMotherList())
            {
                if (item.Id == mother.Id)
                    throw new Exception();
            }
            getMotherList().Add(mother);
        }
        public List<Mother> getMotherList()
        {
            return DataSource.MotherList;
        }
        public void removeMother(Mother mother)
        {
            bool flag = true;
            foreach (Mother item in getMotherList())
            {
                if (item.Id == mother.Id)//if find id to delete
                {
                    flag = false;
                    getMotherList().Remove(item);
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception();
        }
        public void updateMother(Mother mother)
        {
            bool flag = true;
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
        #endregion
        //Child function
        #region
        public void addChild(Child child)
        {
            bool flag = true;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == child.Id)
                    throw new Exception();
            }
            foreach (Mother item in getMotherList())
            {
                if (item.Id == child.MotherId)
                    flag = false;
            }
            if (flag)
                throw new Exception();
            DataSource.ChildList.Add(child);
        }
        public List<Child> getChildList(Mother mother)
        {
            List<Child> childList = new List<Child>();
            foreach (Child item in DataSource.ChildList)
            {
                if (item.MotherId == mother.Id)
                    childList.Add(item);
            }
            return childList;
        }
        public void removeChild(Child child)
        {
            bool flag = true;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == child.Id)//if find id to delete
                {
                    flag = false;
                    DataSource.ChildList.Remove(child);
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception();
        }
        public void updateChild(Child child)
        {
            bool flag = true;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == child.Id)//if find id to update
                    flag = false;
            }
            if (flag)//id to update not found throw Exception
                throw new Exception();
            removeChild(child);//delete the old mother
            addChild(child);//insert the update mother

        }
        #endregion
        //contract function
        #region
        public void addContract(Contract contract)
        {
            bool flag = true;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == contract.ChildID)
                    contract.MotherID = item.MotherId;//update Automatically by the child
            }
            foreach (Mother item in getMotherList())
            {
                if (item.Id == contract.MotherID)//the mother not exist
                    flag = false;
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
        public List<Contract> getContractList()
        {
            return DataSource.ContractList;
        }
        public void removeContract(Contract contract)
        {
            bool flag = true;
            foreach (Contract item in getContractList())
            {
                if (item.ContractID == contract.ContractID)//if find id to delete
                {
                    flag = false;
                    getContractList().Remove(item);
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception();
        }
        public void updateContract(Contract contract)
        {
            bool flag = true;
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
        #endregion
    }
}
