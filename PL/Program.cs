using System;
using System.Collections.Generic;
using BE;
using BL;


/// <summary>
/// yosef Gamliel 207846494
/// shlomi batito 208032417
/// </summary>
namespace PL
{

    class Program
    {
        private static BL_imp bl;
        private static MyFunctions bl_functions;
        static void Main(string[] args)
        {
            bl = new BL.BL_imp();
            initialization();
            int choice;
            string ID = null;
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
                choice = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                List<Nanny> bestNanny = new List<Nanny>();
                try
                {
                    switch (choice)
                    {

                        #region
                        case 1:
                            Add_nanny();
                            break;
                        case 2:
                            Add_Mother();
                            break;
                        case 3:
                            Add_Child();
                            break;
                        case 4:
                            Add_Contract();
                            break;
                        case 5:
                            index = 0;
                            foreach (var item in bl.getNannyList())
                            {
                                Console.WriteLine("Nanny number" + index + "\n");
                                Console.WriteLine(item.ToString());
                                index++;
                            }
                            break;
                        case 6:
                            index = 0;
                            foreach (var item in bl.getMotherList())
                            {
                                Console.WriteLine("Mother number" + index + "\n");
                                Console.WriteLine(item.ToString());
                                index++;
                            }
                            break;
                        case 7:
                            index = 0;
                            foreach (var item in bl.getChildList())
                            {
                                Console.WriteLine("Child number" + index + "\n");
                                Console.WriteLine(item.ToString());
                                index++;
                            }
                            break;
                        case 8:
                            index = 0;
                            foreach (var item in bl.getContractList())
                            {
                                Console.WriteLine("Contract number" + index + "\n");
                                Console.WriteLine(item.ToString());
                                index++;
                            }
                            break;
                        case 9:
                            Console.WriteLine("enter update details of the nanny");
                            #region
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
                            #endregion
                            BE.Nanny the_nanny = new BE.Nanny(id, family_name, name, telephone, address,
                               bitrh_date, has_elevator, floor, years_of_practice, max_number_childern, min_age
                                , max_age, works_by_hours, rate_per_hour, rate_per_month, days_of_work, hours_of_work, days_off_by_education_ministry, recommendations);
                            bl.updateNanny(the_nanny);
                            break;
                        case 10:
                            Console.WriteLine("enter update details of the Mother");
                            #region
                            Console.WriteLine("Enter Mother ID:");
                            string motherID = Console.ReadLine();
                            Console.WriteLine("Enter Mother first name:");
                            string motherFirstName = Console.ReadLine();
                            Console.WriteLine("Enter Mother last name:");
                            string motherLasttName = Console.ReadLine();
                            Console.WriteLine("Enter Mother phone nunber:");
                            string motherPhoneNumber = Console.ReadLine();
                            Console.WriteLine("Enter Mother address:");
                            string motherAddress = Console.ReadLine();
                            Console.WriteLine("Enter area address of nanny for mother:");
                            string motherAreaNanny = Console.ReadLine();
                            Console.WriteLine("Enter y/n for days when needs nanny: (y-yes,n-no)");
                            bool[] motherNeedNanny = new bool[6];
                            for (int i = 0; i < 6; ++i)
                            {
                                Console.WriteLine(" day: {0}", i + 1);
                                motherNeedNanny[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            }
                            Console.WriteLine("Enter start hour and end hour for days when needs nanny: (xx.yy)");
                            float[,] workHours = new float[6, 2];
                            for (int i = 0; i < 6; ++i)
                            {
                                Console.WriteLine(" day: {0}", i + 1);
                                Console.WriteLine("start hour: ");
                                workHours[i, 0] = float.Parse(Console.ReadLine());
                                Console.WriteLine("end hour: ");
                                workHours[i, 1] = float.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("enter notes if you wants:");
                            string motherNotes = Console.ReadLine();
                            BE.Mother mom = new Mother(motherID, motherLasttName, motherFirstName, motherPhoneNumber, motherAddress, motherAreaNanny, motherNeedNanny, workHours, motherNotes);
                            #endregion
                            bl.updateMother(mom);
                            break;
                        case 11:
                            Console.WriteLine("enter update details of the Child");
                            #region
                            Console.WriteLine("Enter  ID:");
                            id = Console.ReadLine();
                            Console.WriteLine("Enter  first name:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter last name:");
                            string LasttName = Console.ReadLine();
                            Console.WriteLine("Enter Mother ID:");
                            motherID = Console.ReadLine();
                            Console.WriteLine("Enter birth date: (xx/yy/zzzz)");
                            bitrh_date = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("had special needs? (y/n)");
                            bool specialNeeds = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            Console.WriteLine("explan:");
                            string infoSpecialNeeds = Console.ReadLine();

                            BE.Child child = new Child(id, firstName, LasttName, motherID, bitrh_date, specialNeeds, infoSpecialNeeds);
                            bl.updateChild(child);
                            break;
                        case 12:
                            Console.WriteLine("Enter BabySitter ID:");
                            string babySitterID = Console.ReadLine();
                            Console.WriteLine("Enter Child ID:");
                            string ChildID = Console.ReadLine();
                            Console.WriteLine("first meeting has done? (y/n)");
                            bool firsMeating = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            Console.WriteLine("which type of salary (y-hour rate/n-month rate)");
                            bool type = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            Console.WriteLine("start day (xx/yy/zzzz)");
                            DateTime start = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("end day (xx/yy/zzzz)");
                            DateTime end = Convert.ToDateTime(Console.ReadLine());
                            BE.Contract con = new Contract(babySitterID, ChildID, firsMeating, type, start, end);
                            #endregion
                            bl.updateContract(con);
                            break;
                        case 13:
                            Nanny Todelete3 = new Nanny();
                            Console.WriteLine("enret Nanny ID to delete");
                            ID = Console.ReadLine();
                            foreach (var item in bl.getNannyList())
                            {
                                if (item.Id == ID)
                                    Todelete3 = item;
                            }
                            bl.removeNanny(Todelete3);

                            break;
                        case 14:
                            Mother Todelete2 = new Mother();
                            Console.WriteLine("enret Mother ID to delete");
                            ID = Console.ReadLine();
                            foreach (var item in bl.getMotherList())
                            {
                                if (item.Id == ID)
                                    Todelete2 = item;
                            }
                            bl.removeMother(Todelete2);
                            break;
                        case 15:
                            Child Todelete1 = new Child();
                            Console.WriteLine("enret Child ID to delete");
                            ID = Console.ReadLine();
                            foreach (var item in bl.getChildList())
                            {
                                if (item.Id == ID)
                                    Todelete1 = item;
                            }
                            bl.removeChild(Todelete1);
                            break;
                        case 16:
                            Contract Todelete = new Contract();
                            Console.WriteLine("enret contract ID to delete");
                            ID = Console.ReadLine();
                            foreach (var item in bl.getContractList())
                            {
                                if (item.ContractID == ID)
                                    Todelete = item;
                            }
                            bl.removeContract(Todelete);
                            break;
                        case 17:
                            Console.WriteLine("enret Mother ID to find Nanny's");
                            ID = Console.ReadLine();
                            foreach (var item in bl.getMotherList())
                            {
                                if (item.Id == ID)
                                {
                                    bestNanny = bl_functions.InitialCoordination(item);
                                    if (bestNanny.Count == 0)
                                        Console.WriteLine("dont found Match Nanny (try press 24)\n");
                                }
                            }
                            index = 0;
                            foreach (var item in bestNanny)
                            {
                                Console.WriteLine("Nanny number" + index + "\n");
                                Console.WriteLine(item.ToString());
                                index++;
                            }
                            break;
                        default:
                            break;
                            #endregion

                    }
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

            } while (choice != 0);
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
            BE.Nanny the_nanny = new BE.Nanny(id, family_name, name, telephone, address,
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
            string ChildID = Console.ReadLine();
            Console.WriteLine("first meeting has done? (y/n)");
            bool firsMeating = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("which type of salary (y-hour rate/n-month rate)");
            bool type = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("start day (xx/yy/zzzz)");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("end day (xx/yy/zzzz)");
            DateTime end = Convert.ToDateTime(Console.ReadLine());
            BE.Contract con = new Contract(babySitterID, ChildID, firsMeating, type, start, end);
            bl.addContract(con);
        }
        private static void Add_Mother()
        {
            Console.WriteLine("Enter Mother ID:");
            string motherID = Console.ReadLine();
            Console.WriteLine("Enter Mother first name:");
            string motherFirstName = Console.ReadLine();
            Console.WriteLine("Enter Mother last name:");
            string motherLasttName = Console.ReadLine();
            Console.WriteLine("Enter Mother phone nunber:");
            string motherPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Mother address:");
            string motherAddress = Console.ReadLine();
            Console.WriteLine("Enter area address of nanny for mother:");
            string motherAreaNanny = Console.ReadLine();
            Console.WriteLine("Enter y/n for days when needs nanny: (y-yes,n-no)");
            bool[] motherNeedNanny = new bool[6];
            for (int i = 0; i < 6; ++i)
            {
                Console.WriteLine(" day: {0}", i + 1);
                motherNeedNanny[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
            }
            Console.WriteLine("Enter start hour and end hour for days when needs nanny: (xx.yy)");
            float[,] workHours = new float[6, 2];
            for (int i = 0; i < 6; ++i)
            {
                Console.WriteLine(" day: {0}", i + 1);
                Console.WriteLine("start hour: ");
                workHours[i, 0] = float.Parse(Console.ReadLine());
                Console.WriteLine("end hour: ");
                workHours[i, 1] = float.Parse(Console.ReadLine());
            }
            Console.WriteLine("enter notes if you wants:");
            string motherNotes = Console.ReadLine();
            BE.Mother mom = new Mother(motherID, motherLasttName, motherFirstName, motherPhoneNumber, motherAddress, motherAreaNanny, motherNeedNanny, workHours, motherNotes);
            bl.addMother(mom);
        }
        private static void Add_Child()
        {
            Console.WriteLine("Enter  ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter  first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string LasttName = Console.ReadLine();
            Console.WriteLine("Enter Mother ID:");
            string motherID = Console.ReadLine();
            Console.WriteLine("Enter birth date: (xx/yy/zzzz)");
            DateTime bitrh_date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("had special needs? (y/n)");
            bool specialNeeds = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("explan:");
            string infoSpecialNeeds = Console.ReadLine();

            BE.Child child = new Child(id, firstName, LasttName, motherID, bitrh_date, specialNeeds, infoSpecialNeeds);
            bl.addChild(child);

        }
        private static void initialization()
        {
            bool[] wd = new bool[6] { true, true, true, true, true, true };
            float[,] workH = new float[6, 2];
            DateTime Birth = new DateTime(1990, 01, 01); ;
            for (int i = 0; i < 6; i++)
            {
                workH[i, 0] = (float)14.35;
                workH[i, 1] = (float)19.35;
            }
            #region NannyExample
            Nanny yafit = new Nanny("307471672", "yafit", "yafit", "0547951348", "Pashos 29,Beer Sheva,israel",
              Birth, true, 3, 3, 20, 3
                , 55, true, (float)30.5, 3500, wd, workH, true, null);
            bl.addNanny(yafit);
            Birth = new DateTime(1989, 01, 01);
            Nanny shlomit = new Nanny("308922202", "shlomit", "batito", "0547951349", "Pashos 50,Beer Sheva,israel",
            Birth, true, 3, 3, 20, 3
              , 55, true, (float)50.5, 5000, wd, workH, true, null);
            bl.addNanny(shlomit);
            #endregion
            #region MotherExample
            Mother galit = new Mother("309549079", "galit", "galit", "0547951344", "Pashos 40,Beer Sheva,israel", "Pashos 40,Beer Sheva,israel", wd, workH, null);
            bl.addMother(galit);
            Mother hagit = new Mother("314370768", "hagit", "hagit", "0547951366", "Pashos 41,Beer Sheva,israel", "Pashos 41,Beer Sheva,israel", wd, workH, null);
            bl.addMother(hagit);
            #endregion
            #region ChildExample
            Birth = new DateTime(2017, 05, 05);
            Child sunofgalit = new Child("317383297", "sunofgalit", "sunofgalit", "309549079", Birth, false, null);
            bl.addChild(sunofgalit);
            Birth = new DateTime(2017, 04, 04);
            Child sunofhagit = new Child("318000262", "sunofgalit", "sunofhagit", "314370768", Birth, false, null);
            bl.addChild(sunofhagit);
            #endregion
            #region ContractExample
            Birth = new DateTime(2019, 01, 09);
            DateTime End = new DateTime(2019, 05, 09);
            BE.Contract HagitContractAndYafit = new Contract("307471672", "318000262", true, true, Birth, End);
            bl.addContract(HagitContractAndYafit);
            Birth = new DateTime(2019, 01, 08);
            End = new DateTime(2019, 05, 08);
            BE.Contract GalitContractAndshlomit = new Contract("308922202", "317383297", true, true, Birth, End);
            bl.addContract(GalitContractAndshlomit);
            #endregion ContractExample

        }
    }
}
