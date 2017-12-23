using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;

namespace DAL
{
    class Dal_imp : Idal
    {
        public void add(Nanny nanny)
        {
            foreach (Nanny item in DataSource.NannyList)
            {

            }
        }
        public List<Nanny> getList()
        {
            return DataSource.NannyList;
        }
    }
}
