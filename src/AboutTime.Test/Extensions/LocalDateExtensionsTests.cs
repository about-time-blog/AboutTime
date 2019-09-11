using AboutTime.Extensions;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace AboutTime.Test.Extensions
{
    public class LocalDateExtensionsTests
    {
        #region At

        [Fact]
        public void At_FullTime()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 02);
            var time = new LocalTime(14, 57, 16, 157);

            // Act
            var dateTime = date.At(time.Hour, time.Minute, time.Second, time.Millisecond);

            // Assert
            dateTime.Should().Be(date.At(time));
        }

        [Fact]
        public void At_HoursAndMinutes()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 02);
            var time = new LocalTime(14, 57);

            // Act
            var dateTime = date.At(time.Hour, time.Minute);

            // Assert
            dateTime.Should().Be(date.At(time));
        }

        #endregion At

        #region IsOnAnnualDate

        [Fact]
        public void IsOnAnnualDate_DifferentAnnualDates()
        {
            // Arrange
            var annualDate = new AnnualDate(08, 02);
            var date = annualDate.InYear(2020);
            var otherAnnualDate = new AnnualDate(01, 06);

            // Act
            var isOnAnnualDate = date.IsOnAnnualDate(otherAnnualDate);

            // Assert
            isOnAnnualDate.Should().BeFalse();
        }

        [Fact]
        public void IsOnAnnualDate_Same_True()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 02);
            var annualDate = date.ToAnnualDate();

            // Act
            var isOnAnnualDate = date.IsOnAnnualDate(annualDate);

            // Assert
            isOnAnnualDate.Should().BeTrue();
        }

        [Fact]
        public void IsOnAnnualDate_Feb29OnNonLeapYear()
        {
            // Arrange
            var date = new LocalDate(2019, 02, 28);
            var annualDate = new AnnualDate(02, 29);

            // Act
            var isOnAnnualDate = date.IsOnAnnualDate(annualDate);

            // Assert
            isOnAnnualDate.Should().BeTrue();
        }

        [Fact]
        public void IsOnAnnualDate_Feb28OnNonLeapYear()
        {
            // Arrange
            var date = new LocalDate(2019, 02, 28);
            var annualDate = new AnnualDate(02, 28);

            // Act
            var isOnAnnualDate = date.IsOnAnnualDate(annualDate);

            // Assert
            isOnAnnualDate.Should().BeTrue();
        }

        [Fact]
        public void IsOnAnnualDate_Feb29OnLeapYear()
        {
            // Arrange
            var date = new LocalDate(2020, 02, 29);
            var annualDate = new AnnualDate(02, 29);

            // Act
            var isOnAnnualDate = date.IsOnAnnualDate(annualDate);

            // Assert
            isOnAnnualDate.Should().BeTrue();
        }

        [Fact]
        public void IsOnAnnualDate_Feb28OnLeapYear()
        {
            // Arrange
            var date = new LocalDate(2020, 02, 28);
            var annualDate = new AnnualDate(02, 29);

            // Act
            var isOnAnnualDate = date.IsOnAnnualDate(annualDate);

            // Assert
            isOnAnnualDate.Should().BeFalse();
        }

        #endregion ToAnnualDate

        #region NextDay

        [Fact]
        public void NextDay()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 02);

            // Act
            var nextDay = date.NextDay();

            // Assert
            nextDay.Should().Be(new LocalDate(2019, 08, 03));
        }

        #endregion

        #region PreviousDay

        [Fact]
        public void PreviousDay()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 01);

            // Act
            var previousDay = date.PreviousDay();

            // Assert
            previousDay.Should().Be(new LocalDate(2019, 07, 31));
        }

        #endregion

        #region ToAnnualDate

        [Fact]
        public void ToAnnualDate()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 02);

            // Act
            var annualDate = date.ToAnnualDate();

            // Assert
            annualDate.Month.Should().Be(date.Month);
            annualDate.Day.Should().Be(date.Day);
        }

        #endregion ToAnnualDate

        #region ToSingleDayInterval

        [Fact]
        public void ToSingleDayInterval()
        {
            // Arrange
            var date = new LocalDate(2019, 08, 02);

            // Act
            var dateInterval = date.ToSingleDayInterval();

            // Assert
            dateInterval.Start.Should().Be(date);
            dateInterval.End.Should().Be(date);
        }

        #endregion ToSingleDayInterval
    }
}