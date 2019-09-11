using System;
using AboutTime.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using NodaTime;
using Xunit;

namespace AboutTime.Test.Extensions
{
    public class DateIntervalExtensionsTests
    {
        #region Overlaps

        [Fact]
        public void Overlaps_Before()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 10, 1), new LocalDate(2020, 03, 23));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = first.Overlaps(second);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeFalse();
                overlapsInverted.Should().BeFalse();
            }
        }

        [Fact]
        public void Overlaps_Meets()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 09, 17), new LocalDate(2019, 10, 1));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = second.Overlaps(first);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeFalse();
                overlapsInverted.Should().BeFalse();
            }
        }

        [Fact]
        public void Overlaps_Overlaps()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 08, 23), new LocalDate(2019, 10, 1));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = second.Overlaps(first);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeTrue();
                overlapsInverted.Should().BeTrue();
            }
        }

        [Fact]
        public void Overlaps_Starts()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2020, 03, 23));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = second.Overlaps(first);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeTrue();
                overlapsInverted.Should().BeTrue();
            }
        }

        [Fact]
        public void Overlaps_During()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2020, 03, 23));
            var second = new DateInterval(new LocalDate(2019, 09, 16), new LocalDate(2019, 10, 1));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = second.Overlaps(first);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeTrue();
                overlapsInverted.Should().BeTrue();
            }
        }

        [Fact]
        public void Overlaps_Finishes()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2020, 03, 23));
            var second = new DateInterval(new LocalDate(2019, 10, 1), new LocalDate(2020, 03, 23));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = second.Overlaps(first);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeTrue();
                overlapsInverted.Should().BeTrue();
            }
        }

        [Fact]
        public void Overlaps_Equal()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));

            // Act
            var overlaps = first.Overlaps(second);
            var overlapsInverted = second.Overlaps(first);

            // Assert
            using (new AssertionScope())
            {
                overlaps.Should().BeTrue();
                overlapsInverted.Should().BeTrue();
            }
        }

        #endregion Overlaps

        #region GetOverlapWith

        [Fact]
        public void Overlap_Before()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 10, 1), new LocalDate(2020, 03, 23));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = first.GetOverlapWith(second);

            // Assert
            using (new AssertionScope())
            {
                overlap.Should().BeNull();
                overlapInverted.Should().BeNull();
            }
        }

        [Fact]
        public void Overlap_Meets()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 09, 17), new LocalDate(2019, 10, 1));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = second.GetOverlapWith(first);

            // Assert
            using (new AssertionScope())
            {
                overlap.Should().BeNull();
                overlapInverted.Should().BeNull();
            }
        }

        [Fact]
        public void Overlap_Overlap()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 08, 23), new LocalDate(2019, 10, 1));
            var expected = new DateInterval(new LocalDate(2019, 08, 23), new LocalDate(2019, 09, 16));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = second.GetOverlapWith(first);

            // Assert
            using (new AssertionScope())
            {
                ((IEquatable<DateInterval>)overlap).Should().Be(expected);
                ((IEquatable<DateInterval>)overlapInverted).Should().Be(expected);
            }
        }

        [Fact]
        public void Overlap_Starts()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2020, 03, 23));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = second.GetOverlapWith(first);

            // Assert
            using (new AssertionScope())
            {
                ((IEquatable<DateInterval>)overlap).Should().Be(first);
                ((IEquatable<DateInterval>)overlapInverted).Should().Be(first);
            }
        }

        [Fact]
        public void Overlap_During()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2020, 03, 23));
            var second = new DateInterval(new LocalDate(2019, 09, 16), new LocalDate(2019, 10, 1));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = second.GetOverlapWith(first);

            // Assert
            using (new AssertionScope())
            {
                ((IEquatable<DateInterval>)overlap).Should().Be(second);
                ((IEquatable<DateInterval>)overlapInverted).Should().Be(second);
            }
        }

        [Fact]
        public void Overlap_Finishes()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2020, 03, 23));
            var second = new DateInterval(new LocalDate(2019, 10, 1), new LocalDate(2020, 03, 23));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = second.GetOverlapWith(first);

            // Assert
            using (new AssertionScope())
            {
                ((IEquatable<DateInterval>)overlap).Should().Be(second);
                ((IEquatable<DateInterval>)overlapInverted).Should().Be(second);
            }
        }

        [Fact]
        public void Overlap_Equal()
        {
            // Arrange
            var first = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));
            var second = new DateInterval(new LocalDate(2019, 08, 02), new LocalDate(2019, 09, 16));

            // Act
            var overlap = first.GetOverlapWith(second);
            var overlapInverted = second.GetOverlapWith(first);

            // Assert
            using (new AssertionScope())
            {
                ((IEquatable<DateInterval>)overlap).Should().Be(first);
                ((IEquatable<DateInterval>)overlapInverted).Should().Be(first);
            }
        }

        #endregion GetOverlapWith
    }
}