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
            List<Nanny> nannyL = getNannyList();
            List<Mother> MotherL = getMotherList();
            float[,] NannyWorkHour = new float[6, 2];//לשמור את השעות עבודה שלמ המטפלת
            float[,] MotherWorkHour = new float[6, 2];//לשמור את השעות עבודה של האמא
            float[,] commonWorkHour = new float[6, 2];//לשמור את השעות עבודה שלמ המטפלת
            foreach (var item in nannyL)
            {
                if (contract.BabySitterID == item.Id)
                {
                    NannyWorkHour = item.WorkHours;//מוצא את העוזרת המדוברת
                }
            }
            foreach (var item in MotherL)
            {
                if (MyFunctions.FindMother(contract.ChildID).Id == item.Id)
                {
                    MotherWorkHour = item.WorkHours;//מוצא את העוזרת המדוברת
                }
            }
            for (int i = 0; i < 6; i++)
            {
                commonWorkHour[i, 0] = MyFunctions.max(MotherWorkHour[i, 0], NannyWorkHour[i, 0]);
                commonWorkHour[i, 1] = MyFunctions.min(MotherWorkHour[i, 1], NannyWorkHour[i, 1]);
            }
            float A = 1.12;
            A.
            
        }
    }
   
}
