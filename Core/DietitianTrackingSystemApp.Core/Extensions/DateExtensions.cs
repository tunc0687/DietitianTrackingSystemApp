namespace DietitianTrackingSystemApp.Core.Extensions
{
    public static class DateExtensions
    {
        public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return dateTime.StartOfWeek(startOfWeek).AddDays(6).Date;
        }

        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).Date;
        }

        public static DateTime EndOfMonth(this DateTime dateTime)
        {
            return dateTime.StartOfMonth().AddDays(-1).Date;
        }
    }
}