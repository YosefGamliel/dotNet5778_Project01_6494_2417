using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace PL
{
    class Program
    {
        private static BL.IBL bl;
        static void Main(string[] args)
        {
            bl = new BL.BL_imp();
            initialization();
            int choice;
            do
            {

                Console.WriteLine("Enter option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add nanny");
                Console.WriteLine("2: Add mother");
                Console.WriteLine("3: Add child");
                Console.WriteLine("4: Add contract");
                Console.WriteLine("5: Print nanny list");
                Console.WriteLine("6: Print mother list");
                Console.WriteLine("7: Print child list");
                Console.WriteLine("8: Print contract list");
                Console.WriteLine("9: Update nanny details");
                Console.WriteLine("10: Update mother details");
                Console.WriteLine("11: Update child details");
                Console.WriteLine("12: Update contract details");
                Console.WriteLine("13: Delete nanny");
                Console.WriteLine("14: Delete mother");
                Console.WriteLine("15: Delete child");
                Console.WriteLine("16: Delete contract");
                Console.WriteLine("17: All good nannies for mother");
                Console.WriteLine("18: All children who need nannies");
                Console.WriteLine("19: All nannies with days off by EM");
                Console.WriteLine("20: All children of a mother");
                Console.WriteLine("21: All signed contracts");
                Console.WriteLine("22: Print child list by mother");
                Console.WriteLine("23: Print all of nannys contracts");
                Console.WriteLine("24: Print five best nanny available for mother");
                Console.WriteLine("25: Print all nannys in given radius from mother");
                Console.WriteLine("26: Print all nannys in groups of ages of kids she can take");
                Console.WriteLine("27: Print all contracts in groups of distances from wanted place");
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }

        private static void Add_nanny()
        {
            Console.WriteLine("Enter ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter family name:");
            string family_name = Console.ReadLine();
            Console.WriteLine("Enter first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter birth date: (xx/yy/zzzz)");
            DateTime bitrh_date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter telephone number:");
            string telephone = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter if has elevator (y/n)");
            bool has_elevator = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter floor:");
            int floor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter years of practice:");
            int years_of_practice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter maximum number of children:");
            int max_number_childern = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter minimum age:");
            int min_age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter maximum age:");
            int max_age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter if works by hours:(y/n)");
          bool works_by_hours = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter rate per hour:");
            float rate_per_hour = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter rate per month:");
            float rate_per_month = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter days of word (6 days, y/n for each day):");
            bool[] days_of_work = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                days_of_work[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
            }
            Console.WriteLine("Enter hours of work (xx.yy)");
            float[,] hours_of_work = new float[6, 2];
            float time = 0;
            for (int i = 0; i < 6; i++)
            {
                if (days_of_work[i])
                {
                    Console.WriteLine(Enum.GetName(typeof(DayOfWeek), i));
                    for (int j = 0; j < 2; j++)
                        hours_of_work[i, j] = float.Parse(Console.ReadLine());
                }
                else
                {
                    hours_of_work[i, 0] = (float)00.00;
                    hours_of_work[i, 1] = (float)00.00;
                }
            }
            Console.WriteLine("Enter if gets days off the the education ministry:");
            bool days_off_by_education_ministry = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter recomondations:");
            string recommendations = Console.ReadLine();
            BE.Nanny the_nanny = new BE.Nanny(id, family_name, name, telephone , address
               bitrh_date, has_elevator, floor, years_of_practice, max_number_childern, min_age
                , max_age, works_by_hours, rate_per_hour, rate_per_month, days_of_work, hours_of_work, days_off_by_education_ministry, recommendations);
            bl.addNanny(the_nanny);
        }
        private static bool yes_or_no(char option)
        {
            if (option == 'y')
                return true;
            else if (option == 'n')
                return false;
            else throw (new Exception("ERROR: wrong letter input"));

        }
        private static void Add_Contract()
        {
            Console.WriteLine("Enter BabySitter ID:");
            string babySitterID = Console.ReadLine();
            Console.WriteLine("Enter Child ID:");
            string childID = Console.ReadLine();
            Console.WriteLine("Enter Mother ID:");
            string motherID = Console.ReadLine();
            Console.WriteLine("first meeting has done? (y/n)");
            bool firsMeating = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("salary type (press y-if it per hour else press n)");
            bool salaryType = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("start day (xx/yy/zzzz)");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("end day (xx/yy/zzzz)");
            DateTime end = Convert.ToDateTime(Console.ReadLine());      
          
        }


}
    }