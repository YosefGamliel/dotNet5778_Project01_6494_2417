﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Directions.Request;

using DS;
namespace BL
{
    // public delegate bool condition(object cond);
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
                if (child.Id == item.ChildID)
                    return item.BabySitterID;
            }
            return null;
        }
        public static int numOfChildInBabySitter(List<Child> brothers, string BabySitterId)
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
            float min = end - beg - _dif;
            if (min < 0.00)
            {
                _dif += (float)(-1 + (min + 0.60));
            }
            else
                _dif += min;

            return _dif;
        }
        public static List<Contract> GetContractsBy(Func<Contract, bool> cond)
        {
            List<Contract> list = new List<Contract>();
            var ContractByCondition = from ch in DataSource.ContractList
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
            var ContractByCondition = from ch in DataSource.ContractList
                                      where cond(ch)
                                      select ch;
            foreach (var item in ContractByCondition)
                SumOfContract++;
            return SumOfContract;
        }
        public static Nanny getNannyById(string id)
        {
            foreach (var item in DataSource.NannyList)
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
        //match nany by hour;
        public List<Nanny> InitialCoordination(Mother mother)
        {
            bool flag = true;
            List<Nanny> MatchNanny = new List<Nanny>();
            foreach (var item in DataSource.NannyList)
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
        public List<Nanny> NannyByDistance(Mother mother, bool order = false)
        {
            List<Nanny> NannyL = new List<Nanny>();
            //they want the list sorted
            if (order)
            {
                var closest = from n in DataSource.NannyList
                              let distance = (int)(CalculateDistance(mother.AreaNanny, n.Address) / 5)
                              orderby distance
                              group n by distance into nannyList
                              select new { distance = nannyList.Key, orderNanny = nannyList };
                foreach (var groop in closest)
                {
                    foreach (var item in groop.orderNanny)
                    {
                        NannyL.Add(item);
                    }
                }
            }
            //they does not want the list sorted
            else
            {
                var closest = from n in DataSource.NannyList
                              let distance = (int)(CalculateDistance(mother.AreaNanny, n.Address) / 5)
                              group n by distance into nannyList
                              select new { distance = nannyList.Key, orderNanny = nannyList };
                foreach (var groop in closest)
                {
                    foreach (var item in groop.orderNanny)
                    {
                        NannyL.Add(item);
                    }
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
        public List<Nanny> FiveclosetNanny(Mother mother)
        {
            List<Nanny> bestFive = new List<Nanny>();
            var closest = from n in DataSource.NannyList
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
        private float grade(Nanny nanny, Mother mom)
        {
            float[,] commonWorkHour = new float[6, 2];//לשמור את השעות עבודה המשותפות
            float[] sumOfHourinWeek = new float[6];
            float TotalCommonHour = 0;

            for (int i = 0; i < 6; i++)
            {
                commonWorkHour[i, 0] = MyFunctions.max(mom.WorkHours[i, 0], nanny.WorkHours[i, 0]);
                commonWorkHour[i, 1] = MyFunctions.min(mom.WorkHours[i, 1], nanny.WorkHours[i, 1]);
                sumOfHourinWeek[i] = MyFunctions.dif(commonWorkHour[i, 0], commonWorkHour[i, 1]);
            }//מחשב כמה שעות עבודה יש ביום הכולל עבודה משותפת
            for (int i = 0; i < 6; i++)
            {
                TotalCommonHour += sumOfHourinWeek[i];
            }
            return TotalCommonHour;
        }
    }
}

