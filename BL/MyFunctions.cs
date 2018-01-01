using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DS;
namespace BL
{
    class MyFunctions
    {
        public Mother FindMother(string childID)
        {
            string motherID = null;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == childID)
                    motherID = item.MotherId;
            }

            foreach (Mother item in getMotherList())
            {
                if (item.Id == motherID)
                    return item;
            }
        }
    }
}
