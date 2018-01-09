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
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        try
                        {
                            add_nanny();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 2:
                        try
                        {
                            add_mother();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 3:
                        try
                        {
                            add_child();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 4:
                        try
                        {
                            add_contract();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 5:
                        try
                        {
                            List<BE.Nanny> nannys = bl.getNannyList();
                            foreach (BE.Nanny nanny in nannys)
                                Console.WriteLine(nanny);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 6:
                        try
                        {
                            List<BE.Mother> mothers = bl.getMotherList();
                            foreach (BE.Mother mother in mothers)
                                Console.WriteLine(mother);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 7:
                        try
                        {
                            List<BE.Child> children = bl.getChildList();
                            foreach (BE.Child child in children)
                                Console.WriteLine(child);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 8:
                        try
                        {
                            List<BE.Contract> contracts = bl.getContractList();
                            foreach (BE.Contract contarct in contracts)
                                Console.WriteLine(contarct);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 9:
                        try
                        {
                            update_nanny();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 10:
                        try
                        {
                            update_mother();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 11:
                        try
                        {
                            update_child();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 12:
                        try
                        {
                            update_contract();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 13:
                        try
                        {
                            delete_nanny();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 14:
                        try
                        {
                            delete_mother();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 15:
                        try
                        {
                            delete_child();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 16:
                        try
                        {
                            delete_contract();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 17:
                        try
                        {
                            Console.WriteLine("Enter mothers ID");
                            string id = Console.ReadLine();
                            BE.Mother mother = bl.GetMother(id);

                            List<BE.Nanny> nannies = bl.ok_nannys_for_mother(mother);
                            if (nannies != null)
                                foreach (BE.Nanny nanny in nannies)
                                    Console.WriteLine(nanny);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 18:
                        try
                        {
                            List<BE.Child> children = bl.still_need_nannys();
                            foreach (BE.Child child in children)
                                Console.WriteLine(child);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 19:
                        try
                        {
                            List<BE.Nanny> nannies = bl.all_nannys_days_off_by_EM();
                            foreach (BE.Nanny nanny in nannies)
                                Console.WriteLine(nanny);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 20:
                        try
                        {
                            Console.WriteLine("Enter mothers ID");
                            string id = Console.ReadLine();
                            BE.Mother mother = bl.GetMother(id);
                            List<BE.Child> children = bl.all_mothers_children(mother);
                            foreach (BE.Child child in children)
                                Console.WriteLine(child);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 21:
                        try
                        {
                            List<BE.Contract> contracts = bl.all_signed_contracts();
                            foreach (BE.Contract nanny in contracts)
                                Console.WriteLine(nanny);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 22:
                        try
                        {
                            foreach (var mom_kids in bl.child_list_by_mother())
                            {
                                Console.WriteLine("mother: " + bl.GetMother(mom_kids.Key).Name + ' '
                                    + bl.GetMother(mom_kids.Key).Family_name + " children are:");
                                foreach (var kid in mom_kids)
                                    Console.WriteLine(kid);
                            }
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 23:
                        try
                        {
                            Console.WriteLine("Enter nannys ID");
                            string id = Console.ReadLine();
                            BE.Nanny nanny = bl.GetNanny(id);
                            foreach (BE.Contract contract in bl.find_all_contracts_of_nanny(nanny))
                                Console.WriteLine(contract);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 24:
                        try
                        {
                            Console.WriteLine("Enter mothers ID");
                            string id = Console.ReadLine();
                            BE.Mother mother = bl.GetMother(id);
                            List<BE.Nanny> nannys = bl.almost_good_nannys(mother);
                            foreach (BE.Nanny nanny in nannys)
                                Console.WriteLine(nanny);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 25:
                        try
                        {
                            Console.WriteLine("Enter mothers ID");
                            string id = Console.ReadLine();
                            BE.Mother mother = bl.GetMother(id);
                            Console.WriteLine("Enter distance radius to search:");
                            double radius = Convert.ToDouble(Console.ReadLine());
                            foreach (BE.Nanny nanny in bl.close_nannys(mother, radius))
                                Console.WriteLine(nanny);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 26:
                        try
                        {
                            Console.WriteLine("would you like to group according to max age of kid(y/n):");
                            bool max_age_group = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            Console.WriteLine("enter the range of months to group:");
                            int groups_of_month = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("would you like to sort(y/n):");
                            bool sort = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            foreach (var groups in bl.grouping_nannys(max_age_group, groups_of_month, sort))
                            {
                                Console.WriteLine("group of age kids from" + groups.Key + " until "
                                    + (groups.Key + groups_of_month) + " months old");
                                foreach (var nanny in groups)
                                    Console.WriteLine(nanny);
                            }
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    case 27:
                        try
                        {

                            Console.WriteLine("would you like to sort(y/n):");
                            bool sort = yes_or_no(Convert.ToChar(Console.ReadLine()));
                            foreach (var groups in bl.grouping_contracts(sort))
                            {
                                Console.WriteLine("group of distance from " + (groups.Key) * 5 + " until " + (groups.Key + 1) * 5 + " kilometers");
                                foreach (var con in groups)
                                    Console.WriteLine(con);
                            }
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message + '\n');
                        }
                        break;
                    default:
                        break;

                }

            } while (choice != 0);

        }


        private static void delete_child()
        {
            Console.WriteLine("Enter childs ID");
            string id = Console.ReadLine();
            BE.Child deleted = bl.GetChild(id);
            bl.delete_child(deleted);
        }

        private static void delete_mother()
        {
            Console.WriteLine("Enter mothers ID");
            string id = Console.ReadLine();
            BE.Mother deleted = bl.GetMother(id);
            bl.delete_mother(deleted);
        }

        private static void delete_nanny()
        {
            Console.WriteLine("Enter nannys ID");
            string id = Console.ReadLine();
            BE.Nanny deleted = bl.GetNanny(id);
            bl.delete_nanny(deleted);
        }

        private static void delete_contract()
        {
            Console.WriteLine("Enter contracts ID");
            string id = Console.ReadLine();
            BE.Contract deleted = bl.GetContract(id);
            bl.delete_contact(deleted);
        }

        private static void update_contract()
        {
            BE.Contract the_contract;
            Console.WriteLine("Enter contract's ID");
            string contracts_id = Console.ReadLine();
            the_contract = bl.GetContract(contracts_id);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("0: exit");
            Console.WriteLine("1: If had a meeting");
            Console.WriteLine("2: If contract was signed");
            Console.WriteLine("3: Payement per hour");
            Console.WriteLine("4: Payement per month");
            Console.WriteLine("5: Payement by hour or by month");
            Console.WriteLine("6: Weekly hours");
            Console.WriteLine("7: Date end of contract");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("1: Enter If had meeting (y/n)");
                    bool meeting = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    the_contract.Was_a_meeting = meeting;
                    bl.update_contacts_details(the_contract);
                    break;
                case 2:
                    Console.WriteLine("1: Enter if contract was signed");
                    bool signed = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    the_contract.Did_sign_contract = signed;
                    bl.update_contacts_details(the_contract);
                    break;
                case 3:
                    Console.WriteLine("1: Enter Payement per hour");
                    int per_hour = Convert.ToInt32(Console.ReadLine());
                    the_contract.Payment_per_hour = per_hour;
                    bl.update_contacts_details(the_contract);
                    break;
                case 4:
                    Console.WriteLine("1: Enter payement per month");
                    int per_month = Convert.ToInt32(Console.ReadLine());
                    the_contract.Payment_per_month = per_month;
                    bl.update_contacts_details(the_contract);
                    break;
                case 5:
                    Console.WriteLine("1: Enter Payement by hour or by month (y/n) ");
                    PaymentOptions hour_or_month = hourOrMonth(Convert.ToChar(Console.ReadLine()));
                    the_contract.Contract_according_month_or_hour = hour_or_month;
                    bl.update_contacts_details(the_contract);
                    break;
                case 6:
                    Console.WriteLine("Enter Weekly hours (for each of the 6 days:");
                    TimeSpan[,] hours = new TimeSpan[6, 2];

                    for (int i = 0; i < 6; i++)
                    {
                        Console.WriteLine("Day " + i + ":");
                        for (int j = 0; j < 2; j++)
                            hours[i, j] = TimeSpan.Parse(Console.ReadLine());
                    }
                    the_contract.Weakly_hours = hours;
                    bl.update_contacts_details(the_contract);
                    break;
                case 7:
                    Console.WriteLine("1: Enter Date end");
                    DateTime date_end = Convert.ToDateTime(Console.ReadLine());
                    the_contract.Date_end_of_contract = date_end;
                    bl.update_contacts_details(the_contract);
                    break;
                default:
                    throw (new Exception("number not valid"));

            }
        }

        private static void update_child()
        {
            BE.Child the_child;
            Console.WriteLine("Enter child's ID");
            string childs_id = Console.ReadLine();
            the_child = bl.GetChild(childs_id);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("0: exit");
            Console.WriteLine("1: Family name");
            Console.WriteLine("2: First name");
            Console.WriteLine("3: If has special needs");
            Console.WriteLine("4: special needs");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("1: Enter Family Name");
                    string family_name = Console.ReadLine();
                    the_child.Family_name = family_name;
                    bl.update_childs_details(the_child);
                    break;
                case 2:
                    Console.WriteLine("1: Enter First Name");
                    string first_name = Console.ReadLine();
                    the_child.Name = first_name;
                    bl.update_childs_details(the_child);
                    break;
                case 3:
                    Console.WriteLine("1: Enter if has special needs (y/n)");
                    bool has_special_needs = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    the_child.Has_special_needs = has_special_needs;
                    bl.update_childs_details(the_child);
                    break;
                case 8:
                    Console.WriteLine("1: Enter special needs");
                    string special_needs = Console.ReadLine();
                    the_child.Special_needs = special_needs;
                    bl.update_childs_details(the_child);
                    break;
                default:
                    throw (new Exception("number not valid"));

            }
        }

        private static void update_mother()
        {
            BE.Mother the_mother;
            Console.WriteLine("Enter mother's ID");
            string mothers_id = Console.ReadLine();
            the_mother = bl.GetMother(mothers_id);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("0: exit");
            Console.WriteLine("1: Family name");
            Console.WriteLine("2: First name");
            Console.WriteLine("3: Telephone");
            Console.WriteLine("4: Address");
            Console.WriteLine("5: Nanny area address");
            Console.WriteLine("6: Days that needs nanny");
            Console.WriteLine("7: Time in each day need nanny");
            Console.WriteLine("8: Extra information");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("1: Enter Family Name");
                    string family_name = Console.ReadLine();
                    the_mother.Family_name = family_name;
                    bl.update_mothers_details(the_mother);
                    break;
                case 2:
                    Console.WriteLine("1: Enter First Name");
                    string first_name = Console.ReadLine();
                    the_mother.Name = first_name;
                    bl.update_mothers_details(the_mother);
                    break;
                case 3:
                    Console.WriteLine("1: Enter telephone");
                    string telephone = Console.ReadLine();
                    the_mother.Celephone = telephone;
                    bl.update_mothers_details(the_mother);
                    break;
                case 4:
                    Console.WriteLine("1: Enter address");
                    string address = Console.ReadLine();
                    the_mother.Address = address;
                    bl.update_mothers_details(the_mother);
                    break;
                case 5:
                    Console.WriteLine("1: Enter Address that needs nanny");
                    string nanny_address = Console.ReadLine();
                    the_mother.Nannys_area_address = nanny_address;
                    bl.update_mothers_details(the_mother);
                    break;
                case 6:
                    Console.WriteLine("Enter days that needs nanny (6 days, y/n for each day):");
                    bool[] days_nanny = new bool[6];
                    for (int i = 0; i < 6; i++)
                    {
                        days_nanny[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    }
                    the_mother.Days_need_nanny = days_nanny;
                    bl.update_mothers_details(the_mother);
                    break;
                case 7:
                    Console.WriteLine("Enter hours needs nanny (for each of the 6 days:");
                    TimeSpan[,] hours_needs_nanny = new TimeSpan[6, 2];

                    for (int i = 0; i < 6; i++)
                    {
                        Console.WriteLine("Day " + i + ":");
                        for (int j = 0; j < 2; j++)
                            hours_needs_nanny[i, j] = TimeSpan.Parse(Console.ReadLine());
                    }
                    the_mother.Time_in_day_need_nanny = hours_needs_nanny;
                    bl.update_mothers_details(the_mother);
                    break;
                case 8:
                    Console.WriteLine("1: Enter extra information");
                    string extra_information = Console.ReadLine();
                    the_mother.Extra_information = extra_information;
                    bl.update_mothers_details(the_mother);
                    break;
                default:
                    throw (new Exception("number not valid"));

            }
        }

        private static void update_nanny()
        {
            BE.Nanny the_nanny;
            Console.WriteLine("Enter nanny ID");
            string nannys_id = Console.ReadLine();
            the_nanny = bl.GetNanny(nannys_id);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("0: exit");
            Console.WriteLine("1: Family name");
            Console.WriteLine("2: First name");
            Console.WriteLine("3: Telephone");
            Console.WriteLine("4: Address");
            Console.WriteLine("5: If has elevator");
            Console.WriteLine("6: Floor");
            Console.WriteLine("7: Years of practice");
            Console.WriteLine("8: Maximum number of children");
            Console.WriteLine("9: Minimum age");
            Console.WriteLine("10: Max age");
            Console.WriteLine("11: If works by hours");
            Console.WriteLine("12: rate per hour");
            Console.WriteLine("13: rate per month");
            Console.WriteLine("14: Days of work");
            Console.WriteLine("15: Hours of work");
            Console.WriteLine("16: If days off by edcation ministry");
            Console.WriteLine("17: recommendations");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("1: Enter Family Name");
                    string family_name = Console.ReadLine();
                    the_nanny.Family_name = family_name;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 2:
                    Console.WriteLine("1: Enter First Name");
                    string first_name = Console.ReadLine();
                    the_nanny.Name = first_name;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 3:
                    Console.WriteLine("1: Enter telephone");
                    string telephone = Console.ReadLine();
                    the_nanny.Telephone = telephone;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 4:
                    Console.WriteLine("1: Enter address");
                    string address = Console.ReadLine();
                    the_nanny.Address = address;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 5:
                    Console.WriteLine("1: Enter If has elevator (y/n)");
                    bool has_elevator = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    the_nanny.Has_elevator = has_elevator;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 6:
                    Console.WriteLine("1: Enter floor");
                    int floor = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Floor = floor;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 7:
                    Console.WriteLine("1: Enter years of practice");
                    int practice = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Years_of_practice = practice;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 8:
                    Console.WriteLine("1: Enter maximum number of chldren");
                    int max_children = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Max_number_childern = max_children;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 9:
                    Console.WriteLine("1: Enter mimimum age");
                    int min_age = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Min_age = min_age;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 10:
                    Console.WriteLine("1: Enter maximum age");
                    int max_age = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Max_age = max_age;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 11:
                    Console.WriteLine("1: Enter If works by hours (y/n)");
                    PaymentOptions by_hours = hourOrMonth(Convert.ToChar(Console.ReadLine()));
                    the_nanny.Works_by_hours = by_hours;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 12:
                    Console.WriteLine("1: Enter rate per hour");
                    int rate = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Rate_per_hour = rate;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 13:
                    Console.WriteLine("1: Enter rate per month");
                    int rate_month = Convert.ToInt32(Console.ReadLine());
                    the_nanny.Rate_per_month = rate_month;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 14:
                    Console.WriteLine("Enter days of word (6 days, y/n for each day):");
                    bool[] days_of_work = new bool[6];
                    for (int i = 0; i < 6; i++)
                    {
                        days_of_work[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    }
                    the_nanny.Days_of_work = days_of_work;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 15:
                    Console.WriteLine("Enter hours of work (for each of the 6 days:");
                    TimeSpan[,] hours_of_work = new TimeSpan[6, 2];

                    for (int i = 0; i < 6; i++)
                    {
                        Console.WriteLine("Day " + i + ":");
                        for (int j = 0; j < 2; j++)
                            hours_of_work[i, j] = TimeSpan.Parse(Console.ReadLine());
                    }
                    the_nanny.Hours_of_work = hours_of_work;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 16:
                    Console.WriteLine("1: Enter If gets days off by the education of ministry");
                    bool days_off = yes_or_no(Convert.ToChar(Console.ReadLine()));
                    the_nanny.Days_off_by_education_ministry = days_off;
                    bl.update_nannys_details(the_nanny);
                    break;
                case 17:
                    Console.WriteLine("1: Enter recommendations");
                    string recommendations = Console.ReadLine();
                    the_nanny.Recommendations = recommendations;
                    bl.update_nannys_details(the_nanny);
                    break;
                default:
                    throw (new Exception("number not valid"));


            }
        }

        private static void add_contract()
        {
            Console.WriteLine("Enter contract number:");
            string contract_number = Console.ReadLine();
            Console.WriteLine("Enter nannys ID:");
            string nannys_id = Console.ReadLine();
            Console.WriteLine("Enter mothers ID:");
            string mothers_id = Console.ReadLine();
            Console.WriteLine("Enter childs ID:");
            string childs_id = Console.ReadLine();
            Console.WriteLine("Enter if there was a meeting: (y/n)");
            bool was_a_meeting = yes_or_no(Convert.ToChar(Console.ReadLine()));
            //Console.WriteLine("Enter if the contract is signed: (y/n)");
            //bool did_sign_contract = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter the payment per hour:");
            double payment_per_hour = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the payment per month:");
            double payment_per_month = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter what tipe of payment:(hour(0)/month(1))");
            PaymentOptions contract_according_month_or_hour = (PaymentOptions)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter weekly hours:");
            TimeSpan[,] weakly_hours = new TimeSpan[6, 2];

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Day " + i + ":");
                for (int j = 0; j < 2; j++)
                    weakly_hours[i, j] = TimeSpan.Parse(Console.ReadLine());

            }
            Console.WriteLine("Enter date of the beginning of the contract:");
            DateTime date_begin_of_contract = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter date of the end of the contract:");
            DateTime date_end_of_contract = Convert.ToDateTime(Console.ReadLine());
            bl.add_contact(new BE.Contract(contract_number, childs_id, nannys_id, mothers_id, was_a_meeting, payment_per_hour, payment_per_month, contract_according_month_or_hour, date_begin_of_contract, date_end_of_contract
                , weakly_hours));
        }

        private static void add_child()
        {
            Console.WriteLine("Enter ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter mother's ID:");
            string mothers_id = Console.ReadLine();
            Console.WriteLine("Enter family name:");
            string family_name = Console.ReadLine();
            Console.WriteLine("Enter first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter birth_date(xx/yy/zzzz):");
            DateTime bitrh_date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter if has special needs(y/n):");
            bool has_special_need = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter special needs:");
            string special_needs = Console.ReadLine();
            BE.Child the_child = new BE.Child(id, mothers_id, family_name, name, bitrh_date, has_special_need, special_needs);
            bl.add_child(the_child);
        }

        private static void add_mother()
        {
            Console.WriteLine("Enter ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter family name:");
            string family_name = Console.ReadLine();
            Console.WriteLine("Enter first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter celephone:");
            string celephone = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter nannys area adress:");
            string nannys_area_address = Console.ReadLine();
            Console.WriteLine("Enter days that she needs a nanny: (y/n 6 times)");
            bool[] days_need_nanny = new bool[0];
            for (int i = 0; i < 6; i++)
            {
                days_need_nanny[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
            }
            Console.WriteLine("Enter time of the day the nanny is needed:");
            TimeSpan[,] time_of_day_needs_nanny = new TimeSpan[6, 2];

            for (int i = 0; i < 6; i++)
            {
                if (days_need_nanny[i])
                {
                    Console.WriteLine(Enum.GetName(typeof(DayOfWeek), i));
                    for (int j = 0; j < 2; j++)
                        time_of_day_needs_nanny[i, j] = TimeSpan.Parse(Console.ReadLine());
                }
                else
                {
                    time_of_day_needs_nanny[i, 0] = TimeSpan.Parse("00:00");
                    time_of_day_needs_nanny[i, 1] = TimeSpan.Parse("00:00");
                }
            }
            Console.WriteLine("Enter extra information:");
            string extra_information = Console.ReadLine();
            BE.Mother the_mother = new BE.Mother(id, family_name, name, celephone, address, nannys_area_address, days_need_nanny, time_of_day_needs_nanny, extra_information);
            bl.add_mother(the_mother);
        }

        private static void add_nanny()
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
            PaymentOptions works_by_hours = hourOrMonth(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter rate per hour:");
            double rate_per_hour = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter rate per month:");
            double rate_per_month = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter days of word (6 days, y/n for each day):");
            bool[] days_of_work = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                days_of_work[i] = yes_or_no(Convert.ToChar(Console.ReadLine()));
            }
            Console.WriteLine("Enter hours of work (xx:yy)");
            TimeSpan[,] hours_of_work = new TimeSpan[6, 2];
            for (int i = 0; i < 6; i++)
            {
                if (days_of_work[i])
                {
                    Console.WriteLine(Enum.GetName(typeof(DayOfWeek), i));
                    for (int j = 0; j < 2; j++)
                        hours_of_work[i, j] = TimeSpan.Parse(Console.ReadLine());
                }
                else
                {
                    hours_of_work[i, 0] = TimeSpan.Parse("00:00");
                    hours_of_work[i, 1] = TimeSpan.Parse("00:00");
                }
            }
            Console.WriteLine("Enter if gets days off the the education ministry:");
            bool days_off_by_education_ministry = yes_or_no(Convert.ToChar(Console.ReadLine()));
            Console.WriteLine("Enter recomondations:");
            string recommendations = Console.ReadLine();
            BE.Nanny the_nanny = new BE.Nanny(id, family_name, name, bitrh_date, address
                , telephone, has_elevator, floor, years_of_practice, max_number_childern, min_age
                , max_age, works_by_hours, rate_per_hour, rate_per_month, days_off_by_education_ministry, recommendations, days_of_work, hours_of_work);
            bl.add_nanny(the_nanny);
        }

        private static bool yes_or_no(char option)
        {
            if (option == 'y')
                return true;
            else if (option == 'n')
                return false;
            else throw (new Exception("ERROR: wrong letter input"));

        }
        private static PaymentOptions hourOrMonth(char option)
        {
            if (option == 'y')
                return PaymentOptions.hour;
            else if (option == 'n')
                return PaymentOptions.month;
            else throw (new Exception("ERROR: wrong letter input"));
        }
        private static void initialization()
        {
            Nanny Ayala_Zehavi = new Nanny
            ("123456782", "Ayala", "zehavi", new DateTime(1980, 5, 19), "Beit Ha-Defus St 21,Jerusalem,isreal", "0523433333", true, 2, 3, 14, 3, 8, PaymentOptions.hour, 30, 5000, false, "", new bool[] { true, true, true, true, true, false },
                new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(15.75) },{TimeSpan.FromHours(9),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }
                );
            Nanny Moria_Schneider = new Nanny
            ("258746916", "Moria", "Schneider", new DateTime(1992, 4, 9), "Shakhal St 15, Jerusalem,isreal", "0523433333", true, 2, 3, 14, 3, 8, PaymentOptions.hour, 30, 5000, false, "", new bool[] { true, true, true, true, true, false },
            new TimeSpan[,]
            {
                    {TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(7),TimeSpan.FromHours(15) },{TimeSpan.FromHours(7),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
            }
                );
            bl.add_nanny(Ayala_Zehavi);
            bl.add_nanny(Moria_Schneider);
            Mother Ayelt_Shaked = new Mother
            ("113542872", "Ayelt", "Shaked", "0521234566", "Shakhal St 23,Jerusalem,isreal", "Shakhal St 23,Jerusalem,isreal", new bool[] { true, true, true, true, true, false },
               new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(7),TimeSpan.FromHours(15) },{TimeSpan.FromHours(7),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }, "");
            Mother Gilat_Bennet = new Mother
           ("111112223", "Gilat", "Bennet", "0541485421", "HaMem Gimel St 4, Jerusalem,isreal", "HaMem Gimel St 4, Jerusalem,isreal", new bool[] { false, true, true, true, true, false },
              new TimeSpan[,]
               {
                    {TimeSpan.FromHours(0),TimeSpan.FromHours(0) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
               }, "");
            bl.add_mother(Ayelt_Shaked);
            bl.add_mother(Gilat_Bennet);
            Child Elad = new Child("322690124", "113542872", "Elad", "Shaked", new DateTime(2016, 6, 20), true, "Is STUPID");
            Child Dror = new Child("302302039", "111112223", "Dror", "Bennet", new DateTime(2015, 1, 1), false, "");
            bl.add_child(Elad);
            bl.add_child(Dror);
            Contract contract1 = new Contract("11114489", "322690124", "123456782", "113542872", true, 30, 5000, PaymentOptions.month, new DateTime(2017, 6, 20), new DateTime(2017, 12, 20), new TimeSpan[,]
            {
                    {TimeSpan.FromHours(0),TimeSpan.FromHours(0) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(9),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
            });
            Contract contract2 = new Contract("22334567", "302302039", "258746916", "111112223", true, 27, 4800, PaymentOptions.hour, new DateTime(2015, 6, 1), new DateTime(2017, 12, 20), new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(15) },{TimeSpan.FromHours(9),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                });
            bl.add_contact(contract1);
            bl.add_contact(contract2);
        }
    }


}