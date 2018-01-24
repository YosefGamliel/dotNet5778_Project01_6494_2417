using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
namespace DAL
{
    /*class Dal_XML_imp : Idal
    {
        int contractnumber = 0;
        XElement child;
        XElement ContractID;
        const string childPath = @"Child.xml";
        const string motherPath = @"Mother.xml";
        const string nannyPath = @"Nanny.xml";
        const string contractPath = @"Contract.xml";
        const string contractIDPath = @"ContractID.xml";
        private void CreateFiles()
        {
            child = new XElement("children");
            child.Save(childPath);
            ContractID = new XElement("ContractID", 10000000);
            ContractID.Save(contractIDPath);
        }

        private void LoadData()
        {
            try
            {
                child = XElement.Load(childPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        Dal_XML_imp()
        {
            SaveToXML(new List<Nanny>(), nannyPath);
            SaveToXML(new List<Mother>(), motherPath);
            SaveToXML(new List<Contract>(), contractPath);

        }
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }
        #region Nanny
        public void addNanny(Nanny nanny)
        {
            var list = LoadFromXML<List<Nanny>>(nannyPath);
            if (!(list == null))
            {
                foreach (Nanny item in list)
                {
                    if (item.Id == nanny.Id)
                        throw new Exception("there is already nanny with this id");
                }
            }
            list.Add(nanny);
            SaveToXML(list, nannyPath);
        }
        public List<Nanny> getNannyList()
        {
            return LoadFromXML<List<Nanny>>(nannyPath);
        }
        public void removeNanny(Nanny nanny)
        {
            Nanny todelete = new Nanny();
            bool flag = true;
            var list = LoadFromXML<List<Nanny>>(nannyPath);
            foreach (Nanny item in list)
            {
                if (item.Id == nanny.Id)//if find id to delete
                {
                    flag = false;
                    todelete = item;
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception("this nanny is not exist");
            else
                list.Remove(todelete);
            SaveToXML<List<Nanny>>(list, nannyPath);
        }
        public void updateNanny(Nanny nanny)
        {
            var list = LoadFromXML<List<Nanny>>(nannyPath);
            bool flag = true;
            foreach (Nanny item in list)
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
        #region Mother
        public void addMother(Mother mom)
        {
            var list = LoadFromXML<List<Mother>>(motherPath);
            if (!(list == null))
            {
                foreach (Mother item in list)
                {
                    if (item.Id == mom.Id)
                        throw new Exception("there is already mother with this id");
                }
            }
            list.Add(mom);
            SaveToXML(list, motherPath);
        }
        public List<Mother> getMotherList()
        {
            return LoadFromXML<List<Mother>>(motherPath);
        }
        public void removeMother(Mother mother)
        {
            var list = LoadFromXML<List<Mother>>(motherPath);
            bool flag = true;
            Mother todelete = new Mother();
            foreach (Mother item in list)
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
                list.Remove(todelete);
            SaveToXML<List<Mother>>(list, motherPath);
        }
        public void updateMother(Mother mother)
        {
            var list = LoadFromXML<List<Mother>>(motherPath);
            bool flag = true;
            foreach (Mother item in list)
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


        #region Contract
        public void addContract(Contract contract)
        {
            var listMother = LoadFromXML<List<Mother>>(motherPath);
            var listContract = LoadFromXML<List<Contract>>(contractPath);
            var listChild = LoadFromXML<List<Child>>(childPath);
            var listNanny = LoadFromXML<List<Nanny>>(nannyPath);
            bool flag = true;
            if ((listChild == null || listNanny == null || listMother == null))
                throw new Exception("Missing Details");
            foreach (Child item in listChild)
            {
                if (item.Id == contract.ChildID)
                    contract.MotherID = item.MotherId;//update Automatically by the child
            }
            foreach (Mother item in listMother)
            {
                if (item.Id == contract.MotherID)//the mother not exist
                    flag = false;
            }
            if (flag)
                throw new Exception("there is no mother with this id");
            flag = true;
            foreach (Nanny item in listNanny)
            {
                if (item.Id == contract.BabySitterID)
                    flag = false;
            }
            if (flag)
                throw new Exception("there is no nanny with this id");
            contract.ContractID = ContractID.Element("ContractID").ToString();
            contractnumber = ((int.Parse(contract.ContractID)));
            contractnumber++;
            ContractID.Element("ContractID").Value = contractnumber.ToString();
            listContract.Add(contract);
            SaveToXML(listContract, contractPath);
        }
        public List<Contract> getContractList()
        {
            return LoadFromXML<List<Contract>>(contractPath);
        }
        public void removeContract(Contract contract)
        {
            var listContract = LoadFromXML<List<Contract>>(contractPath);
            Contract ToDelete = new Contract();
            bool flag = true;
            foreach (Contract item in listContract)
            {
                if (item.ContractID == contract.ContractID)//if find id to delete
                {
                    flag = false;
                    ToDelete = item;
                }
            }
            if (flag)//id to delete not found throw Exception
                throw new Exception("Contract Not Found");
            else
                listContract.Remove(ToDelete);
            SaveToXML(listContract, contractPath);

        }
        public void updateContract(Contract contract)
        {
            var listContract = LoadFromXML<List<Contract>>(contractPath);
            bool flag = true;
            foreach (Contract item in listContract)
            {
                if (item.ContractID == contract.ContractID)//if find id to update
                    flag = false;
            }
            if (flag)//id to update not found throw Exception
                throw new Exception("Contract Not Found");
            removeContract(contract);//delete the old mother
            addContract(contract);//insert the update mother
        }
        #endregion

        #region Child

        public void addChild(Child Child)
        {
            LoadData();
            XElement id = new XElement("id", Child.Id);
            XElement firstName = new XElement("firstname", Child.FirstName);
            XElement motherid = new XElement("Mothwerid", Child.MotherId);
            XElement birthday = new XElement("Birthday", Child.Birthday.ToString());
            XElement specialneeds = new XElement("SpecialNeeds", Child.SpecialNeeds);
            XElement infospecialneeds = new XElement("InfoSpecialNeeds", Child.InfoSpecialNeeds);
            child.Add(new XElement("child", id, motherid, firstName, birthday, specialneeds, infospecialneeds));
            child.Save(childPath);

        }
        public void deleteChild(Child Child)
        {
            LoadData();

            XElement deleteChild;
            try
            {
                deleteChild = (from c in child.Elements()
                               where (c.Element("id").Value) == Child.Id
                               select c).FirstOrDefault();
                deleteChild.Remove();
                child.Save(childPath);
            }
            catch
            { throw new Exception("ERROR"); }

        }

        public void updateChild(Child Child)
        {
            LoadData();

            XElement UPdateChild = (from c in child.Elements()
                                    where (c.Element("id").Value) == Child.Id
                                    select c).FirstOrDefault();

            UPdateChild.Element("firstname").Value = Child.FirstName;
            UPdateChild.Element("SpecialNeeds").Value = Child.SpecialNeeds.ToString();
            UPdateChild.Element("InfoSpecialNeeds").Value = Child.InfoSpecialNeeds;
        }

        //public List<Child> getChildList()
        //{
        //    Child c;
        //    LoadData();
        //    foreach (var item in child.Elements())
        //    {
        //        c = new Child(item.Element("id").Value, item.Element("firstname").Value, item.Element("Mothwerid").Value, (DateTime)(item.Element("Birthday").Value), (bool)item.Element("SpecialNeeds").Value, item.Element("InfoSpecialNeeds").Value)
        //    }
        //}

        public void removeChild(Child child)
        {
            throw new NotImplementedException();
        }

        public List<Child> getChildList(Mother mother)
        {
            throw new NotImplementedException();
        }
        #endregion


    }*/
}
