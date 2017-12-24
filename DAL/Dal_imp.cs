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
            foreach (Nanny item in getList())
            {

            }
        }
        public List<Nanny> getList()
        {
            return DataSource.NannyList;
        }
    }
}
