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
                    if (item.Id == mother.Id)//if find id to delete
                        flag = false;
                }
                if (flag)//id to delete not found throw Exception
                    throw new Exception();
                getMotherList().Remove(mother);//delete the old mother
                getMotherList().Add(mother);//insert the update mother

            }

        }
        #endregion
    }
}
