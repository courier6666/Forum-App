using System;

namespace ForumWebApp.Data.Enums
{
    public static class WithinTimePeriod
    {
        private static List<TimeSpan> periods;
        private static List<string> periodsName;
        public static readonly int PeriodsCount;
        static WithinTimePeriod()
        {
            periods = new List<TimeSpan>()
            {
                new TimeSpan(23, 59, 59),
                new TimeSpan(71, 59, 59),
                new TimeSpan(6, 23, 59, 59),
                new TimeSpan(13, 23, 59, 59),
                new TimeSpan(20, 23, 59, 59),
                new TimeSpan(27, 23, 59, 59),
                new TimeSpan(29, 23, 59, 59)
            };

            PeriodsCount = periods.Count;

            Day = periods[0];
            Day3 = periods[1];
            Week = periods[2];
            Week2 = periods[3];
            Week3 = periods[4];
            Week4 = periods[5];
            Month = periods[6];

            periodsName = new List<string>() { 
                "A Day",
                "3 Days",
                "A Week",
                "2 Weeks",
                "3 Weeks",
                "4 Weeks",
                "A Month"
            };

        }
        public static readonly TimeSpan Day;
        public static readonly TimeSpan Day3;
        public static readonly TimeSpan Week;
        public static readonly TimeSpan Week2;
        public static readonly TimeSpan Week3;
        public static readonly TimeSpan Week4;
        public static readonly TimeSpan Month;
        public static TimeSpan? SelectWithinTimePeriod(TimeSpan timeSpan)
        {
            for(int i = 0; i < periods.Count; ++i)
            {
                if (periods[i] > timeSpan)
                {
                    return periods[i];
                }
            }
            return null;
        }
        public static string GetTimePeriodNameById(int id)
        {
            string result;
            try
            {
                result = periodsName[id];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }
            return result;
        }
        public static TimeSpan GetTimePeriodById(int id)
        {
            TimeSpan result;
            try
            {
                result = periods[id];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
