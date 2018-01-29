using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL
{
    class FactoryBL
    {
        static IBL ibl;

        
        public static IBL GetBL()
        {
            //singltone
            if (ibl == null)
                ibl = new BL_imp();
            return ibl;
        }

    }
}
