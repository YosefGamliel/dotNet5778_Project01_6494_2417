using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BL
{
    class BL_imp2 : IBL
    {
        Dal_imp dal = new Dal_imp();
        public void addContract(Contract contract)
        {
            try
            {
                
                foreach (Child item in getChildList())
                {
                    if ()
                }
                dal.addContract(contract);

            }
        }
    }
}
