using System.Collections.Generic;
using NodaTime;

namespace AboutTime.Extensions
{
    public static class DateIntervalExtensions
    {
        /// <summary>
        /// Determines whether the two date intervals overlap, i.e. both intervals contain at least one common date.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="otherInterval">The other interval to check for overlap with the first interval.</param>
        /// <exception cref="System.ArgumentException"><paramref name="otherInterval"/> is not in the same calendar as this interval.</exception>
        /// <returns><c>true</c> if <paramref name="otherInterval"/> overlaps this interval; <c>false</c> otherwise.</returns>
        public static bool Overlaps(this DateInterval interval, DateInterval otherInterval)
        {
            if (interval is null)
            {
                throw new System.ArgumentNullException(nameof(interval));
            }
            if (otherInterval is null)
            {
                throw new System.ArgumentNullException(nameof(interval));
            }

            if (!interval.Start.Calendar.Equals(otherInterval.Start.Calendar))
            {
                throw new System.ArgumentException("The given interval must be in the same calendar as this interval", nameof(otherInterval));
            }

            return interval.Start <= otherInterval.End && otherInterval.Start <= interval.End;
        }

        /// <summary>
        /// Returns the overlap between the two intervals.
        /// </summary>
        /// <param name="interval">The interval to find an overlap with.</param>
        /// <param name="otherInterval">The other interval to find an overlap with.</param>
        /// <exception cref="System.ArgumentException"><paramref name="otherInterval"/> is not in the same calendar as this interval.</exception>
        /// <returns>A date interval equal to the overlap of the two intervals, if they overlap; <c>null</c> otherwise.</returns>
        public static DateInterval GetOverlapWith(this DateInterval interval, DateInterval otherInterval)
        {
            if (interval is null)
            {
                throw new System.ArgumentNullException(nameof(interval));
            }
            if (otherInterval is null)
            {
                throw new System.ArgumentNullException(nameof(interval));
            }

            if (!interval.Start.Calendar.Equals(otherInterval.Start.Calendar))
            {
                throw new System.ArgumentException("The given interval must be in the same calendar as this interval", nameof(otherInterval));
            }

            var start = interval.Start >= otherInterval.Start ? interval.Start : otherInterval.Start;
            var end = interval.End <= otherInterval.End ? interval.End : otherInterval.End;

            return start <= end ? new DateInterval(start, end) : null;
        }

        /// <summary>
        /// Returns the dates in the period that fall on the given day of week.
        /// </summary>
        /// <param name="interval">A date interval.</param>
        /// <param name="dayOfWeek">A day of the week.</param>
        /// <returns>The dates in the period that fall on the given day of week.</returns>
        public static IEnumerable<LocalDate> GetDatesThatFallOn(this DateInterval interval, IsoDayOfWeek dayOfWeek)
        {
            if (interval is null)
            {
                throw new System.ArgumentNullException(nameof(interval));
            }

            for (var date = interval.Start.With(DateAdjusters.NextOrSame(dayOfWeek));
                interval.Contains(date);
                date = date.With(DateAdjusters.Next(dayOfWeek)))
            {
                yield return date;
            }
        }
    }
}