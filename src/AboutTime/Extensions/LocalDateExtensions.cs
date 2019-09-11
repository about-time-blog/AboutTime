using NodaTime;

namespace AboutTime.Extensions
{
    public static class LocalDateExtensions
    {
        /// <summary>
        /// Combines the <see cref="LocalDate"/> with the time at the given hour, minute, second and millisecond.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="hour">The hour of day.</param>
        /// <param name="minute">The minute of the hour.</param>
        /// <param name="second">The second of the minute.</param>
        /// <param name="millisecond">The millisecond of the second.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The parameters do not form a valid time.</exception>
        /// <returns>The resulting date time.</returns>
        public static LocalDateTime At(this LocalDate date, int hour, int minute, int second = 0, int millisecond = 0) => date.At(new LocalTime(hour, minute, second, millisecond));

        /// <summary>
        /// Determines whether the local date is on the annual date, i.e. whether the months and days are equal.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the annual date represents February 29th, and the specified date represents February 28th in a non-leap
        /// year, the returned value will be <c>true</c>; if it is a leap year, only a date representing February 29th
        /// will return <c>true</c>.
        /// </para>
        /// </remarks>
        /// <param name="date">The local date.</param>
        /// <param name="annualDate">The annual date.</param>
        /// <returns><c>true</c>, if the date is on the annual date; <c>false</c>, otherwise.</returns>
        public static bool IsOnAnnualDate(this LocalDate date, AnnualDate annualDate) => annualDate.InYear(date.Year) == date;

        /// <summary>
        /// Returns the date following the given date, i.e. the given date's tomorrow.
        /// </summary>
        /// <param name="date">A local date.</param>
        /// <returns>The date following the given date.</returns>
        // TODO: Rename to DayAfter
        public static LocalDate NextDay(this LocalDate date) => date.PlusDays(1);

        /// <summary>
        /// Returns the date preceding the given date, i.e. the given date's yesterday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>The date preceding the given date.</returns>
        // TODO: Rename to DayBefore
        public static LocalDate PreviousDay(this LocalDate date) => date.PlusDays(-1);

        /// <summary>
        /// Converts the date to an annual date, ignoring the year.
        /// </summary>
        /// <param name="date">A local date.</param>
        /// <returns>An annual date with the same month and day as the given date.</returns>
        public static AnnualDate ToAnnualDate(this LocalDate date) => new AnnualDate(date.Month, date.Day);

        /// <summary>
        /// Returns an <see cref="Interval"/> representing the local date in the given time zone.
        /// </summary>
        /// <param name="date">A local date.</param>
        /// <param name="timeZone">A time zone.</param>
        /// <returns></returns>
        public static Interval ToIntervalInZone(this LocalDate date, DateTimeZone timeZone)
        {
            if (timeZone is null)
            {
                throw new System.ArgumentNullException(nameof(timeZone));
            }

            var start = timeZone.AtStartOfDay(date);
            var end = timeZone.AtEndOfDay(date);

            return new Interval(start.ToInstant(), end.ToInstant());
        }

        /// <summary>
        /// Returns a single-day interval starting and ending on the given date.
        /// </summary>
        /// <param name="date">The local date.</param>
        /// <returns>A single-day interval starting and ending on the given date.</returns>
        public static DateInterval ToSingleDayInterval(this LocalDate date) => new DateInterval(date, date);
    }
}