using NodaTime;

namespace AboutTime.Extensions
{
    public static class DateTimeZoneExtensions
    {
        /// <summary>
        /// Returns the earliest valid <see cref="ZonedDateTime"/> after the given local date.
        /// </summary>
        /// <remarks>
        /// If midnight exists unambiguously on the day after the given date, its midnight is returned.
        /// If the date has an ambiguous start time (e.g. the clocks go back from 1am to midnight) then
        /// the earlier <see cref="ZonedDateTime"/> is returned. If it has no midnight
        /// (e.g. the clocks go forward from midnight to 1am) then the earliest valid value is returned;
        /// this will be the instant of the transition.
        /// </remarks>
        /// <param name="timeZone">A time zone.</param>
        /// <param name="date">The local date to map in the given time zone.</param>
        /// <exception cref="SkippedTimeException">The entire day was skipped due to a very large time zone transition.
        /// (This is extremely rare.)</exception>
        /// <returns>The <see cref="ZonedDateTime"/> representing the earliest time in the given date, in this time zone.</returns>
        /// <seealso cref="DateTimeZone.AtStartOfDay(LocalDate)"/>
        public static ZonedDateTime AtEndOfDay(this DateTimeZone timeZone, LocalDate date)
        {
            if (timeZone is null)
            {
                throw new System.ArgumentNullException(nameof(timeZone));
            }

            return timeZone.AtStartOfDay(date.NextDay());
        }

        /// <summary>
        /// Gets the current date in the given time zone according to the given clock.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <param name="clock">The clock from which the current time is taken.</param>
        /// <returns>Today's date in the given time zone.</returns>
        public static LocalDate Today(this DateTimeZone timeZone, IClock clock)
        {
            if (timeZone is null)
            {
                throw new System.ArgumentNullException(nameof(timeZone));
            }
            if (clock is null)
            {
                throw new System.ArgumentNullException(nameof(clock));
            }

            return timeZone.Today(clock.GetCurrentInstant());
        }

        /// <summary>
        /// Gets the date in the given time zone at the given moment in time.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <param name="instant">The moment in time.</param>
        /// <returns>The date in the given time zone.</returns>
        public static LocalDate Today(this DateTimeZone timeZone, Instant instant)
        {
            if (timeZone is null)
            {
                throw new System.ArgumentNullException(nameof(timeZone));
            }

            return instant.InZone(timeZone).Date;
        }
    }
}