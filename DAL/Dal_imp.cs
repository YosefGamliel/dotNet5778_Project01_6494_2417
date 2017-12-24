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
        public void add(Nanny nanny)
        {
            try
            {
                foreach (Nanny item in getList())
                {
                    if (item.Id == nanny.Id)
                        throw new Exception();
                }
                getList().Add(nanny);
            }
        }
        public List<Nanny> getList()
        {
            return DataSource.NannyList;
        }
        public List<Contract> getList()
        {

        }
    }
}
