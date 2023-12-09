namespace ForumWebApp.Data.Enums
{
    public static class WithinTimePeriod
    {
        static WithinTimePeriod()
        {

        }
        public static readonly TimeSpan Day = new TimeSpan(23, 59, 59);
        public static readonly TimeSpan Day3 = new TimeSpan(71, 59, 59);
        public static readonly TimeSpan Week = new TimeSpan(6, 24 + 23,59,59);
        public static readonly TimeSpan Week2 = new TimeSpan(13, 23, 59, 59);
        public static readonly TimeSpan Week3 = new TimeSpan(20, 23, 59, 59);
        public static readonly TimeSpan Week4 = new TimeSpan(27, 23, 59, 59);
        public static readonly TimeSpan Month = new TimeSpan(29, 23, 59, 59);
    }
}
