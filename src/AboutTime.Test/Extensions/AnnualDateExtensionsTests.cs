using AboutTime.Extensions;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace AboutTime.Test.Extensions
{
    public class AnnualDateExtensionsTests
    {
        [Fact]
        public void NextOccurrence_SameDate()
        {
            // Arrange
            var annualDate = new AnnualDate(08, 02);
            var fromDate = new LocalDate(2019, 08, 02);

            // Act
            var date = annualDate.NextOccurrence(fromDate);

            // Assert
            date.Should().Be(fromDate);
        }

        [Fact]
        public void NextOccurrence_DayAfter()
        {
            // Arrange
            var annualDate = new AnnualDate(08, 03);
            var fromDate = new LocalDate(2019, 08, 02);

            // Act
            var date = annualDate.NextOccurrence(fromDate);

            // Assert
            date.Should().Be(fromDate.NextDay());
        }

        [Fact]
        public void NextOccurrence_DayBefore()
        {
            // Arrange
            var annualDate = new AnnualDate(08, 02);
            var fromDate = new LocalDate(2019, 08, 03);

            // Act
            var date = annualDate.NextOccurrence(fromDate);

            // Assert
            date.Should().Be(new LocalDate(2020, 08, 02));
        }

        [Fact]
        public void NextOccurrence_Feb29LeapYear()
        {
            // Arrange
            var annualDate = new AnnualDate(02, 29);
            var fromDate = new LocalDate(2019, 08, 02);

            // Act
            var date = annualDate.NextOccurrence(fromDate);

            // Assert
            date.Should().Be(new LocalDate(2020, 02, 29));
        }

        [Fact]
        public void NextOccurrence_Feb29NonLeapYear()
        {
            // Arrange
            var annualDate = new AnnualDate(02, 29);
            var fromDate = new LocalDate(2020, 08, 02);

            // Act
            var date = annualDate.NextOccurrence(fromDate);

            // Assert
            date.Should().Be(new LocalDate(2021, 02, 28));
        }
    }
}