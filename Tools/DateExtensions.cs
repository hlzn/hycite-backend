namespace hlzn.util;

public static class DateExtensions
{
    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
    }
}