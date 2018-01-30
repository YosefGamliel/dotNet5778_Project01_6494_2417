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
            if (!(DataSource.NannyList == null))
            {
                foreach (Nanny item in getNannyList())
                {
                    if (item.Id == nanny.Id)//HAD nanny with same id
                        throw new Exception("there is already nanny with this id");
                }
            }
            DataSource.NannyList.Add(nanny);
        }
        public List<Nanny> getNannyList()
        {
            return DataSource.NannyList;
        }
        public void removeNanny(Nanny nanny)
        {
            Nanny todelete = new Nanny();
            bool flag = true;
            foreach (Nanny item in getNannyList())
            {
                if (item.Id == nanny.Id)//if find id to delete
                {
                    flag = false;
                   todelete=item;
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception("this nanny is not exist");
            else
                getNannyList().Remove(todelete);
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
                throw new Exception("this nanny is not exist");
            removeNanny(nanny);//delete the old mother
            addNanny(nanny);//insert the update mother
        }
        #endregion
        // Mother function
        #region
        public void addMother(Mother mother)
        {
            if (!(DataSource.MotherList == null))
            {
                foreach (Mother item in getMotherList())
                {
                    if (item.Id == mother.Id)
                        throw new Exception("there is already mother with this id");
                }
            }
            DataSource.MotherList.Add(mother);
        }
        public List<Mother> getMotherList()
        {
            return DataSource.MotherList;
        }
        public void removeMother(Mother mother)
        {
            bool flag = true;
            Mother todelete = new Mother();
            foreach (Mother item in getMotherList())
            {
                if (item.Id == mother.Id)//if find id to delete
                {
                    flag = false;
                    todelete = item; 
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception("this mother is not exist");
            else
                getMotherList().Remove(todelete);
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
                throw new Exception("this mother is not exist");
            removeMother(mother);//delete the old mother
            addMother(mother);//insert the update mother
        }
        #endregion
        //Child function
        #region
        public void addChild(Child child)
        {
            bool flag = true;
            if (!(DataSource.ChildList == null))
            {
                foreach (Child item in getChildList())
                {
                    if (item.Id == child.Id)
                        throw new Exception("there is already child with this id");
                }
                if (DataSource.MotherList == null)
                    throw new Exception("ERROR-child without Mother");
                foreach (Mother item in getMotherList())
                {
                    if (item.Id == child.MotherId)
                        flag = false;
                }
                if (flag)
                    throw new Exception("this child has no Mother");
            }
            DataSource.ChildList.Add(child);
        }
        public List<Child> getChildList(Mother mother)
        {
            List<Child> childList = new List<Child>();
            foreach (Child item in getChildList())
            {
                if (item.MotherId == mother.Id)
                    childList.Add(item);
            }
            return childList;
        }
        public List<Child> getChildList()
        {
            return DataSource.ChildList;
        }
        public void removeChild(Child child)
        {
            bool flag = true;
            Child todelete = new Child();
            foreach (Child item in getChildList())
            {
                if (item.Id == child.Id)//if find id to delete
                {
                    flag = false;
                    todelete = child;
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception("this child is not exist");
            else
                getChildList().Remove(todelete);
        }
        public void updateChild(Child child)
        {
            bool flag = true;
            foreach (Child item in getChildList())
            {
                if (item.Id == child.Id)//if find id to update
                    flag = false;
            }
            if (flag)//id to update not found throw Exception
                throw new Exception("this child is not exist");
            removeChild(child);//delete the old mother
            addChild(child);//insert the update mother

        }
        #endregion
        //contract function
        #region
        public void addContract(Contract contract)
        {
            bool flag = true;
            if ((DataSource.ChildList == null || DataSource.NannyList == null || DataSource.MotherList == null))
                throw new Exception("Missing Details");
            foreach (Child item in getChildList())
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
                throw new Exception("there is no mother with this id");
            flag = true;
            foreach (Nanny item in getNannyList())
            {
                if (item.Id == contract.BabySitterID)
                    flag = false;
            }
            if (flag)
                throw new Exception("there is no nanny with this id");
            if (contract.ContractID==null)
            {
                contract.ContractID = contratNumber.ToString();
                contratNumber++;
            }
            DataSource.ContractList.Add(contract);
        }
        public List<Contract> getContractList()
        {
            return DataSource.ContractList;
        }
        public void removeContract(Contract contract)
        {
            Contract ToDelete = new Contract();
            bool flag = true;
            foreach (Contract item in getContractList())
            {
                if (item.ContractID == contract.ContractID)//if find id to delete
                {
                    flag = false;
                    ToDelete = item;                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception("Contract Not Found");
            else
            getContractList().Remove(ToDelete);
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
                throw new Exception("Contract Not Found");
            contratNumber--;
            removeContract(contract);//delete the old mother
            addContract(contract);//insert the update mother
        }
        #endregion
    }
}
