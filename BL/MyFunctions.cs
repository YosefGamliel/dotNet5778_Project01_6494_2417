using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Directions.Request;


namespace BL
{
    public class MyFunctions
    {
        static IBL bl = FactoryBL.GetBL(); // it's static because the functions are also static
        /// <summary>
        /// Find Mother By Child ID.
        /// </summary>
        /// <param name="childID">child id</param>
        /// <returns>mother of the child</returns>
        public static Mother FindMother(string childID)
        {
            string motherID = null;
            foreach (Child item in bl.getChildList())
            {
                if (item.Id == childID)
                    motherID = item.MotherId;
            }
            foreach (Mother item in bl.getMotherList())
            {
                if (item.Id == motherID)
                    return item;
            }
            return null;
        }
        /// <summary>
        /// find Mother by her ID
        /// </summary>
        /// <param name="MotherID">mother id</param>
        /// <returns>the mother herself</returns>
        public static Mother FindMotherById(string MotherID)
        {
            foreach (var item in bl.getMotherList())
            {
                if (item.Id == MotherID)
                    return item;
            }
            return null;
        }
        /// <summary>
        /// find the nanny of specific child
        /// </summary>
        /// <param name="child">child</param>
        /// <returns>the child's nanny</returns>
        private static string getNannyByChild(Child child)
        {
            foreach (var item in bl.getContractList())
            {
                if (child.Id == item.ChildID)
                    return item.BabySitterID;
            }
            return null;
        }
        /// <summary>
        /// check how much brother Signed in same nanny in order to calculating the discount
        /// </summary>
        /// <param name="brothers">list of all brothers</param>
        /// <param name="BabySitterId">nanny's id</param>
        /// <returns>sum of brothers who have the nanny</returns>
        public static int numOfChildInBabySitter(List<Child> brothers, string BabySitterId)
        {
            int sum = 1;
            foreach (var item in brothers)
            {
                if (getNannyByChild(item) == BabySitterId)
                    sum++;
            }
            return sum;
        }
        /// <summary>
        /// override MAX between rwo TimeSpan
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TimeSpan max(TimeSpan a, TimeSpan b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }
        /// <summary>
        ///  override MIN between rwo TimeSpan
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TimeSpan min(TimeSpan a, TimeSpan b)
        {
            if (a <= b)
                return a;
            else
                return b;
        }
        /// <summary>
        /// Performs a schema operation of hours
        /// its meaninig that 1.3 its one hour and 30 minute
        /// and if I add 1.3+1.3 its meaning that i want=>3 hours
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double sum(double beg, double end)
        {
            double _sum = (int)end + (int)beg;
            double min = end + beg - _sum;
            if (min > 0.60)
            {
                _sum += (1 + (min - 0.60));
            }
            else
                _sum += min;

            return _sum;
        }
        /// <summary>
        /// Performs a schema operation of hours
        /// its meaninig that 1.3 its one hour and 30 minute
        /// and if I add 1.3-1.2 its meaning that i want=>0.1 hours=>10 minutes
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double dif(TimeSpan beg, TimeSpan end)
        {
            TimeSpan common = end - beg;
            return common.TotalHours;
        }
        /// <summary>
        /// find Contacts By condition (using linq)
        /// </summary>
        /// <param name="cond">the condition</param>
        /// <returns></returns>
        public static List<Contract> GetContractsBy(Func<Contract, bool> cond)
        {
            List<Contract> list = new List<Contract>();
            var ContractByCondition = from ch in bl.getContractList()
                                      where cond(ch)
                                      select ch;
            foreach (var item in ContractByCondition)
                list.Add(item);
            return list;
        }
        /// <summary>
        /// Find the Number Of Contracts by Condition (using linq)
        /// </summary>
        /// <param name="cond">the condition</param>
        /// <returns></returns>
        public static int NumOfContractsBy(Func<Contract, bool> cond)
        {
            int SumOfContract = 0;
            //add to ContractByCondition all contract that standing in cond
            var ContractByCondition = from ch in bl.getContractList()
                                      where cond(ch)
                                      select ch;
            foreach (var item in ContractByCondition)
                SumOfContract++;
            return SumOfContract;
        }
        /// <summary>
        /// find NANNY by her ID
        /// </summary>
        /// <param name="id">nanny's id</param>
        /// <returns>the nanny herself</returns>
        public static Nanny getNannyById(string id)
        {
            foreach (var item in bl.getNannyList())
            {
                if (id == item.Id)
                    return item;

            }
            return null;
        }
        /// <summary>
        /// google maps function
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="dest">destination</param>
        /// <returns>the distance</returns>
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
        /// <summary>
        /// give garde to Nanny by her Common Work hours with
        /// Mother, The more hours Common, the nanny get higher score
        /// </summary>
        /// <param name="nanny">nanny</param>
        /// <param name="mom">mother</param>
        /// <returns>the nanny's grade</returns>
        private static double grade(Nanny nanny, Mother mom)
        {
            TimeSpan[,] commonWorkHour = new TimeSpan[6, 2];//לשמור את השעות עבודה המשותפות
            double[] sumOfHourinWeek = new double[6];
            double TotalCommonHour = 0;

            //calculatin the sum of the Common hours
            for (int i = 0; i < 6; i++)
            {
                commonWorkHour[i, 0] = max(mom.WorkHours[i, 0], nanny.WorkHours[i, 0]);
                commonWorkHour[i, 1] = min(mom.WorkHours[i, 1], nanny.WorkHours[i, 1]);
                sumOfHourinWeek[i] = dif(commonWorkHour[i, 0], commonWorkHour[i, 1]);
                TotalCommonHour = sum(TotalCommonHour, sumOfHourinWeek[i]);
            }
            return TotalCommonHour;
        }

        /// <summary>
        /// nanny with Precise match according to work hours
        /// </summary>
        /// <param name="mother">mother</param>
        /// <returns>list of the match nannies</returns>
        private static List<Nanny> InitialCoordination(Mother mother)
        {
            bool flag = true;
            List<Nanny> MatchNanny = new List<Nanny>();
            foreach (var item in bl.getNannyList())
            {
                //check the days
                for (int i = 0; i < 6; i++)
                {
                    if (item.WorkDays[i] != mother.NeedNanny[i])
                        flag = false;
                }
                if (flag)
                {
                    //check the hour
                    for (int i = 0; i < 6; i++)
                    {
                        //check if NannyHour does not match to MotherNeed
                        if (!(item.WorkHours[i, 0] <= mother.WorkHours[i, 0]//start working before or exactly when the mother need 
                           && item.WorkHours[i, 1] >= mother.WorkHours[i, 1])) //end working after or or exactly when the mother need.
                            flag = false;
                    }
                }
                if (flag)
                    MatchNanny.Add(item);
                flag = true;//check the next nanny
            }
            return MatchNanny;
        }

        /// <summary>
        /// הקטע הוא כזה אני בודק לאיזה מטפלת יש הכי הרבה שעות עבודה משותפות 
        /// הבדיקה נעשית ע"י הפונקציה גרייד שמחזירה את מספר השעות עבודה משותפות
        /// ואז אני ממיין לכל מטפלת למי יש הכי הרבה שעות עבודה משותפות ומחזיר 
        /// את החמש בעלות הכי הרבה שעות עבודה
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        /// <summary>
        ///***Our choice was according to the common hours because this is the main factor***
        ///match nany by hour;
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public static List<Nanny> FiveclosetNanny(Mother mother)
        {
            List<Nanny> bestFive = new List<Nanny>();
            var closest = from n in bl.getNannyList()
                          let CommonHour = grade(n, mother)
                          orderby CommonHour descending
                          select n;
            int i = 0;
            foreach (var nanny in closest)
            {
                //care that return MAX 5 Nanny's
                if (i < 5)
                {
                    bestFive.Add(nanny);
                    ++i;
                }

            }
            return bestFive;
        }

        /// <summary>
        /// return List of childs without Contract
        /// </summary>
        /// <returns></returns>
        public static List<Child> ChildWhithoutContract()
        {
            List<Child> ChildWithoutContract = new List<Child>();
            bool flag = true;
            foreach (var child in bl.getChildList())
            {
                foreach (var contract in bl.getContractList())
                {
                    if (child.Id == contract.ChildID)
                        flag = false;
                }
                if (flag)
                    ChildWithoutContract.Add(child);

                flag = true;//check the next child
            }
            return ChildWithoutContract;
        }
        /// <summary>
        /// return List Of Nannies that working By TMT
        /// </summary>
        /// <returns></returns>
        public static List<Nanny> NannyByTAMAT()
        {
            List<Nanny> nannyL = new List<Nanny>();
            nannyL = GetNannyBy(x => x.VacationDaysITE == true);//lambda
            return nannyL;
        }
        /// <summary>
        /// return List Of nannies by condition (using linq)
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns></returns>
        public static List<Nanny> GetNannyBy(Func<Nanny, bool> cond)
        {
            List<Nanny> list = new List<Nanny>();
            var NannyByCondition = from n in bl.getNannyList()
                                   where cond(n)
                                   select n;
            foreach (var item in NannyByCondition)
                list.Add(item);
            return list;
        }
        /// <summary>
        /// return List Of Childs by condition (using linq)
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns></returns>
        public static List<Child> GetChildBy(Func<Child, bool> cond)
        {
            List<Child> list = new List<Child>();
            var ChildByCondition = from n in bl.getChildList()
                                   where cond(n)
                                   select n;
            foreach (var item in ChildByCondition)
                list.Add(item);
            return list;
        }

        /// <summary>
        /// Find the best result of nanny that 
        /// match to  Specific Mother
        /// </summary>
        /// <param name="mom">mother</param>
        /// <returns></returns>
        public static List<Nanny> NanniesToMother(Mother mom)
        {
            List<Nanny> nanList = new List<Nanny>();
            if (InitialCoordination(mom) != null)//if had Full match
                nanList = InitialCoordination(mom);//return the Full match
            else//dont had full Match
                nanList = FiveclosetNanny(mom);//return the best five
            return nanList;
        }

        #region IEnumerable
        /// <summary>
        /// return Group OF nannies by minimum child age (using grouping)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, Nanny>> NannyByAge()
        {
            IEnumerable<IGrouping<int, Nanny>> check = from n in bl.getNannyList()
                                                       let kidsAge = n.MinAge
                                                       orderby  kidsAge //they want the list sorted
                                                       group n by kidsAge;
            return check;
        }
        /// <summary>
        /// return Group OF childs by age (using grouping)
        /// </summary>
        /// <param name="MaxOrMin"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, Child>> ChildByAge(bool MaxOrMin = true)
        {
            IEnumerable<IGrouping<int, Child>> check = from n in bl.getChildList()
                                                           //big to little=False, Little to big=True
                                                       let kidsAge = (DateTime.Now.Month - n.Birthday.Month + (DateTime.Now.Year - n.Birthday.Year) * 12)
                                                       orderby (MaxOrMin) ? kidsAge : kidsAge descending //they want the list sorted
                                                       group n by kidsAge;

            return check;
        }
        /// <summary>
        /// return Group OF childs with same mother
        /// </summary>
        /// <param name="MaxOrMin"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<string, Child>> ChildByMother(bool MaxOrMin = true)
        {
            IEnumerable<IGrouping<string, Child>> check = from n in bl.getChildList()
                                                              //big to little=False, Little to big=True
                                                          let MotherID = n.MotherId
                                                          group n by MotherID;
            return check;
        }
        /// <summary>
        /// return Group OF nannies by distace (using grouping)
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, Nanny>> NannyByDistance(Mother mother)
        {

            var closest = from n in bl.getNannyList()
                          let distance = (int)(CalculateDistance(mother.AreaNanny, n.Address) / 5)
                          orderby distance
                          group n by distance;

            return closest;
        }
        #endregion
    }
}

