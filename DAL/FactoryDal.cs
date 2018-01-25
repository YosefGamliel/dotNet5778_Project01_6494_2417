using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryDal
    {
        static Idal idal;

        public static Idal GetDal()
        {
            if (idal == null)
                idal = new Dal_XML_imp();
            return idal;
        }
    }
}
