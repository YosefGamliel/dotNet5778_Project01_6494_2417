using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BL
{
    class BL_imp2 
    {
        Dal_imp dal = new Dal_imp();
        public void addContract(Contract contract)
        {
            float[] sumOfHourinWeek = new float[6];
            float sumOfHourinMonth = 0;
            float[,] NannyWorkHour = new float[6, 2];//לשמור את השעות עבודה שלמ המטפלת
            float[,] MotherWorkHour = new float[6, 2];//לשמור את השעות עבודה של האמא
            float[,] commonWorkHour = new float[6, 2];//לשמור את השעות עבודה שלמ המטפלת
            int sumOfChild = 0;
            foreach (var item in getNannyList())
            {
                if (contract.BabySitterID == item.Id)
                {
                    NannyWorkHour = item.WorkHours;//מוצא את העוזרת המדוברת
                }
            }//find the nanny
            if (contract.SalaryType) //per hour
            {
                foreach (var item in getMotherList())
                {
                    if (MyFunctions.FindMother(contract.ChildID).Id == item.Id)
                    {
                        MotherWorkHour = item.WorkHours;//מוצא את העוזרת המדוברת
                        sumOfChild = MyFunctions.numOfChildInBabySitter(MyFunctions.getChildList(item), contract.BabySitterID);
                    }
                }//find the nother
                for (int i = 0; i < 6; i++)
                {
                    commonWorkHour[i, 0] = MyFunctions.max(MotherWorkHour[i, 0], NannyWorkHour[i, 0]);
                    commonWorkHour[i, 1] = MyFunctions.min(MotherWorkHour[i, 1], NannyWorkHour[i, 1]);
                    sumOfHourinWeek[i] = MyFunctions.dif(commonWorkHour[i, 0], commonWorkHour[i, 1]);
                }//מחשב כמה שעות עבודה יש ביום הכולל עבודה משותפת
                for (int i = 0; i < 6; i++) //מחשב את המשכורת ע"י סכימה של שעות העבודה 
                    sumOfHourinMonth = MyFunctions.sum(sumOfHourinMonth, sumOfHourinWeek[i]);
                if (sumOfChild == 1)//no brothers-no discount
                    contract.Payment = sumOfHourinMonth * 4 * contract.SalaryPerHour;
                else
                    contract.Payment = sumOfHourinMonth * 4 * contract.SalaryPerHour * (1 - 0.02 * (sumOfChild - 1));
            }
        }

    }

}
