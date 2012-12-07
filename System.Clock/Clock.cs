namespace System
{
    public static class Clock
    {
        private static Func<DateTime> UtcNowInstance = () => DateTime.UtcNow;

        /// <summary>
        /// Equivalent to DateTime.UtcNow
        /// </summary>
        public static DateTime UtcNow { get { return UtcNowInstance(); } }

        /// <summary>
        /// Equivalent to DateTime.Now
        /// </summary>
        public static DateTime Now { get { return UtcNowInstance().ToLocalTime(); } }

        /// <summary>
        /// Freeze time
        /// </summary>
        public static void Freeze()
        {
            var instance = new DateTime(DateTime.UtcNow.Ticks);
            UtcNowInstance = () => instance;
        }

        /// <summary>
        /// Freeze at a specific time
        /// </summary>
        /// <param name="dateTime">a datetime</param>
        /// <param name="isLocal">true if local, false if utc</param>
        public static void Freeze(DateTime dateTime, bool isLocal = false)
        {
            var instance = isLocal ? new DateTime(dateTime.Ticks).ToUniversalTime() : new DateTime(dateTime.Ticks);
            UtcNowInstance = () => instance;
        }

        /// <summary>
        /// Unfreeze time and return to the present
        /// </summary>
        public static void Unfreeze()
        {
            UtcNowInstance = () => DateTime.UtcNow;
        }
    }
}
