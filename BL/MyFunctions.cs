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
        public static Mother FindMother(string childID)
        {
            string motherID = null;
            foreach (Child item in DataSource.ChildList)
            {
                if (item.Id == childID)
                    motherID = item.MotherId;
            }
            foreach (Mother item in DataSource.MotherList)
            {
                if (item.Id == motherID)
                    return item;
            }
            return null;
        }
        private static string getNannyByChild(Child child)
        {
            foreach (var item in DataSource.ContractList)
            {
               if( child.Id == item.ChildID)
                    return item.BabySitterID;
            }
            return null;
        }
        public static int numOfChildInBabySitter(List<Child> brothers,string BabySitterId)
        {
            int sum = 0;
            foreach (var item in brothers)
            {
                if (getNannyByChild(item) == BabySitterId)
                    sum++;
            }
            return sum;
        }
        public static float max(float a, float b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }
        public static float min(float a, float b)
        {
            if (a <= b)
                return a;
            else
                return b;
        }
        public static float sum(float beg, float end)
        {
            float _sum = (int)end + (int)beg;
            float min = end + beg - _sum;
            if (min > 0.60)
            {
                _sum += (float)(1 + (min - 0.60));
            }
            else
                _sum += min;

            return _sum;
        }
        public static float dif(float beg, float end)
        {
            float _dif = (int)end - (int)beg;
            float min = end -beg - _dif;
            if (min < 0.00)
            {
                _dif += (float)(-1 + (min + 0.60));
            }
            else
                _dif += min;

            return _dif;
        }
    }
}
