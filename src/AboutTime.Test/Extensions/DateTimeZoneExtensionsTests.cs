using AboutTime.Extensions;
using AboutTime.Testing;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace AboutTime.Test.Extensions
{
    public class DateTimeZoneExtensionsTests
    {
        #region AtEndOfDay

        [Fact]
        public void AtEndOfDay()
        {
            // Arrange
            var offset = Offset.FromHours(2);
            var timeZone = new FixedOffsetDateTimeZone(offset);
            var date = new LocalDate(2019, 08, 02);

            // Act
            var endOfDay = timeZone.AtEndOfDay(date);

            // Assert
            var expected = new ZonedDateTime(new LocalDateTime(2019, 08, 03, 00, 00), timeZone, offset);
            endOfDay.Should().Be(expected);
        }

        #endregion

        #region Today

        [Fact]
        public void Today_SameDay()
        {
            // Arrange
            var offset = Offset.FromHours(2);
            var timeZone = new FixedOffsetDateTimeZone(offset);

            var now = Instant.FromUtc(2019, 08, 02, 01, 17, 27);

            // Act
            var today = timeZone.Today(now);

            // Assert
            today.Should().Be(new LocalDate(2019, 08, 02));
        }

        [Fact]
        public void Today_DayBefore()
        {
            // Arrange
            var offset = Offset.FromHours(-2);
            var timeZone = new FixedOffsetDateTimeZone(offset);

            var now = Instant.FromUtc(2019, 08, 02, 01, 17, 27);

            // Act
            var today = timeZone.Today(now);

            // Assert
            today.Should().Be(new LocalDate(2019, 08, 01));
        }

        #endregion
    }
}