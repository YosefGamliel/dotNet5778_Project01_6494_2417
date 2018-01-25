using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class FactoryBL
    {
        static IBL ibl;


        public static IBL GetBL()
        {
            if (ibl == null)
                ibl = new BL_imp();
            return ibl;
        }

    }
}
