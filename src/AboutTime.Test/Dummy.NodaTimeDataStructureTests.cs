using System;
using AboutTime.Dummy;
using FluentAssertions;
using FluentAssertions.Execution;
using NodaTime;
using Xunit;

namespace AboutTime.Test
{
    public class NodaTimeDataStructureTests
    {
        [Fact]
        public void Dummy()
        {
            // Arrange
            var dummy = new NodaTimeDataStructure();

            // Assert
            using (new AssertionScope())
            {
                ((IEquatable<DateInterval>) dummy.DateInterval).Should().NotBe(default(DateInterval));
                dummy.DateTimeZone.Should().NotBe(default(DateTimeZone));
                dummy.Duration.Should().NotBe(default(Duration));
                dummy.Instant.Should().NotBe(default(Instant));
                dummy.Interval.Should().NotBe(default(Interval));
                dummy.IsoDayOfWeek.Should().NotBe(default(IsoDayOfWeek));
                dummy.LocalDate.Should().NotBe(default(LocalDate));
                dummy.LocalDateTime.Should().NotBe(default(LocalDateTime));
                dummy.LocalTime.Should().NotBe(default(LocalTime));
                dummy.Offset.Should().NotBe(default(Offset));
                dummy.OffsetDate.Should().NotBe(default(OffsetDate));
                dummy.OffsetDateTime.Should().NotBe(default(OffsetDateTime));
                dummy.OffsetTime.Should().NotBe(default(OffsetTime));
                dummy.Period.Should().NotBe(default(Period));
                dummy.ZonedDateTime.Should().NotBe(default(ZonedDateTime));

                dummy.NullableDuration.Should().NotBe(default(Duration));
                dummy.NullableInstant.Should().NotBe(default(Instant));
                dummy.NullableInterval.Should().NotBe(default(Interval));
                dummy.NullableIsoDayOfWeek.Should().NotBe(default(IsoDayOfWeek));
                dummy.NullableLocalDate.Should().NotBe(default(LocalDate));
                dummy.NullableLocalDateTime.Should().NotBe(default(LocalDateTime));
                dummy.NullableLocalTime.Should().NotBe(default(LocalTime));
                dummy.NullableOffset.Should().NotBe(default(Offset));
                dummy.NullableOffsetDate.Should().NotBe(default(OffsetDate));
                dummy.NullableOffsetDateTime.Should().NotBe(default(OffsetDateTime));
                dummy.NullableOffsetTime.Should().NotBe(default(OffsetTime));
                dummy.NullableZonedDateTime.Should().NotBe(default(ZonedDateTime));

                ((IEquatable<DateInterval>)dummy.NullDateInterval).Should().BeNull();
                dummy.NullDateTimeZone.Should().BeNull();
                dummy.NullDuration.Should().BeNull();
                dummy.NullInstant.Should().BeNull();
                dummy.NullInterval.Should().BeNull();
                dummy.NullIsoDayOfWeek.Should().BeNull();
                dummy.NullLocalDate.Should().BeNull();
                dummy.NullLocalDateTime.Should().BeNull();
                dummy.NullLocalTime.Should().BeNull();
                dummy.NullOffset.Should().BeNull();
                dummy.NullOffsetDate.Should().BeNull();
                dummy.NullOffsetDateTime.Should().BeNull();
                dummy.NullOffsetTime.Should().BeNull();
                dummy.NullPeriod.Should().BeNull();
                dummy.NullZonedDateTime.Should().BeNull();
            }
        }
    }
}
