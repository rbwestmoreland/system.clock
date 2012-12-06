namespace System
{
    public class Clock
    {
        private static Func<DateTime> UtcNowInstance = () => DateTime.UtcNow;

        public static DateTime UtcNow { get { return UtcNowInstance(); } }
        public static DateTime Now { get { return UtcNowInstance().ToLocalTime(); } }

        public static void Freeze()
        {
            var instance = new DateTime(DateTime.UtcNow.Ticks);
            UtcNowInstance = () => instance;
        }

        public static void Freeze(DateTime dateTime, bool isLocal = false)
        {
            var instance = isLocal ? new DateTime(dateTime.Ticks).ToUniversalTime() : new DateTime(dateTime.Ticks);
            UtcNowInstance = () => instance;
        }

        public static void Unfreeze()
        {
            UtcNowInstance = () => DateTime.UtcNow;
        }
    }
}
