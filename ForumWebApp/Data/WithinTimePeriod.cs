namespace ForumWebApp.Data.Enums
{
    public static class WithinTimePeriod
    {
        private static List<TimeSpan> periods;
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

        }
        public static readonly TimeSpan Day = periods[0];
        public static readonly TimeSpan Day3 = periods[1];
        public static readonly TimeSpan Week = periods[2];
        public static readonly TimeSpan Week2 = periods[3];
        public static readonly TimeSpan Week3 = periods[4];
        public static readonly TimeSpan Week4 = periods[5];
        public static readonly TimeSpan Month = periods[6];
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
    }
}
