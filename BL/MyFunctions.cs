﻿using System;
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
        static IBL bl = new BL_imp(); // it's static because the functions are also static
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
        public static Mother FindMotherById(string MotherID)
        {
            foreach (var item in bl.getMotherList())
            {
                if (item.Id == MotherID)
                    return item;
            }
            return null;
        }
        private static string getNannyByChild(Child child)
        {
            foreach (var item in bl.getContractList())
            {
                if (child.Id == item.ChildID)
                    return item.BabySitterID;
            }
            return null;
        }
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
        public static TimeSpan max(TimeSpan a, TimeSpan b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }
        public static TimeSpan min(TimeSpan a, TimeSpan b)
        {
            if (a <= b)
                return a;
            else
                return b;
        }
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
        public static double dif(TimeSpan beg, TimeSpan end)
        {
            TimeSpan common = end - beg;
            return common.TotalHours;
        }
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
        public static Nanny getNannyById(string id)
        {
            foreach (var item in bl.getNannyList())
            {
                if (id == item.Id)
                    return item;

            }
            return null;
        }
        //google maps
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
        private static double grade(Nanny nanny, Mother mom)
        {
            TimeSpan[,] commonWorkHour = new TimeSpan[6, 2];//לשמור את השעות עבודה המשותפות
            double[] sumOfHourinWeek = new double[6];
            double TotalCommonHour = 0;

            for (int i = 0; i < 6; i++)
            {
                commonWorkHour[i, 0] = max(mom.WorkHours[i, 0], nanny.WorkHours[i, 0]);
                commonWorkHour[i, 1] = min(mom.WorkHours[i, 1], nanny.WorkHours[i, 1]);
                sumOfHourinWeek[i] = dif(commonWorkHour[i, 0], commonWorkHour[i, 1]);
                TotalCommonHour = sum(TotalCommonHour, sumOfHourinWeek[i]);
            }//מחשב כמה שעות עבודה יש ביום הכולל עבודה משותפת
            return TotalCommonHour;
        }
        //match nany by hour;
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
        public static List<Nanny> NannyByDistance(Mother mother, bool order = false)
        {
            List<Nanny> NannyL = new List<Nanny>();
            //they want the list sorted

            var closest = from n in bl.getNannyList()
                          let distance = (int)(CalculateDistance(mother.AreaNanny, n.Address) / 5)
                          orderby (order) ? distance : 0
                          group n by distance into nannyList
                          select new { distance = nannyList.Key, orderNanny = nannyList };
            foreach (var groop in closest)
            {
                foreach (var item in groop.orderNanny)
                {
                    NannyL.Add(item);
                }
            }
            return NannyL;
        }



        /// <summary>
        /// הקטע הוא כזה אני בודק לאיזה מטפלת יש הכי הרבה שעות עבודה משותפות 
        /// הבדיקה נעשית ע"י הפונקציה גרייד שמחזירה את מספר השעות עבודה משותפות
        /// ואז אני ממיין לכל מטפלת למי יש הכי הרבה שעות עבודה משותפות ומחזיר 
        /// את החמש בעלות הכי הרבה שעות עבודה
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
                //אם יש יותר מחמש נאני לא יכניס את השאר
                //ומטפל גם באפשרות שיש פחות מחמש נאני
                if (i < 5)
                {
                    bestFive.Add(nanny);
                    ++i;
                }

            }
            return bestFive;
        }
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
        public static List<Nanny> NannyByTAMAT()
        {
            List<Nanny> nannyL = new List<Nanny>();
            nannyL = GetNannyBy(x => x.VacationDaysITE == true);
            return nannyL;
        }
        /// <summary>
        /// אם יש כוח יש כמה פונקציות שנקראות
        /// getNANNYby....
        /// שאפשר להשתמש בפונקציה הזאת
        /// </summary>
        /// <param name="cond"></param>
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
        
        public static List<Nanny> NanniesToMother(Mother mom)
        {
            List<Nanny> nanList = new List<Nanny>();
            if (InitialCoordination(mom) != null)
                nanList = InitialCoordination(mom);
            else
                nanList = FiveclosetNanny(mom);
            return nanList;
        }

        #region IEnumerable
        public static IEnumerable<IGrouping<int, Nanny>> NannyByAge(bool order = false)
        {
            // List<Nanny> NannyL = new List<Nanny>();
            IEnumerable<IGrouping<int, Nanny>> check = from n in bl.getNannyList()
                                                           //max Age = true, MinAge = FALSE
                                                       let kidsAge = n.MinAge
                                                       orderby (order) ? kidsAge : 0 //they want the list sorted
                                                       group n by kidsAge;//into nannyList
                                                                          //select new { kidsAge = nannyList.Key, orderNanny = nannyList };
                                                                          //foreach (var groop in check)
                                                                          //{
                                                                          //    foreach (var item in groop.orderNanny)
                                                                          //    {
                                                                          //        NannyL.Add(item);
                                                                          //    }
                                                                          //}
            return check;
        }
        public static IEnumerable<IGrouping<int, Child>> ChildByAge(bool MaxOrMin = true)
        {
            // List<Child> ChildL = new List<Child>();
            IEnumerable<IGrouping<int, Child>> check = from n in bl.getChildList()
                                                           //big to little=False, Little to big=True
                                                       let kidsAge = (DateTime.Now.Month - n.Birthday.Month + (DateTime.Now.Year - n.Birthday.Year) * 12)
                                                       orderby (MaxOrMin) ? kidsAge : kidsAge descending //they want the list sorted
                                                       group n by kidsAge;

            //foreach (var groop in check)
            //{
            //    foreach (var item in groop.orderCHILD)
            //    {
            //        ChildL.Add(item);
            //    }
            //}
            return check;
        }
        public static IEnumerable<IGrouping<string, Child>> ChildByMother(bool MaxOrMin = true)
        {
            //List<Child> ChildL = new List<Child>();
            IEnumerable<IGrouping<string, Child>> check = from n in bl.getChildList()
                                                              //big to little=False, Little to big=True
                                                          let MotherID = n.MotherId
                                                          group n by MotherID;//into childList
                                                                              // select new { kidsAge = childList.Key, orderCHILD = childList };
                                                                              //foreach (var groop in check)
                                                                              //{
                                                                              //    foreach (var item in groop.orderCHILD)
                                                                              //    {
                                                                              //        ChildL.Add(item);
                                                                              //    }
                                                                              //}
            return check;
        }

        public static IEnumerable<IGrouping<int, Nanny>>  NannyByDistance(Mother mother)
        {
            List<Nanny> NannyL = new List<Nanny>();
            //they want the list sorted

            var closest = from n in bl.getNannyList()
                          let distance = (int)(CalculateDistance(mother.AreaNanny, n.Address)/5)
                          orderby distance
                          group n by distance; 
                                   
            return closest;
        }
        #endregion
    }
}

