using NodaTime;

namespace AboutTime.Dummy
{
    public class NodaTimeDataStructure
    {
        public NodaTimeDataStructure()
        {
            IClock clock = SystemClock.Instance;
            DateTimeZone = DateTimeZoneProviders.Tzdb["Europe/Copenhagen"];
            Instant = clock.GetCurrentInstant();

            ZonedDateTime = Instant.InZone(DateTimeZone);
            OffsetDateTime = ZonedDateTime.ToOffsetDateTime();
            OffsetDate = OffsetDateTime.ToOffsetDate();
            OffsetTime = OffsetDateTime.ToOffsetTime();
            Offset = OffsetDateTime.Offset;
            LocalDateTime = ZonedDateTime.LocalDateTime;
            LocalDate = LocalDateTime.Date;
            LocalTime = LocalDateTime.TimeOfDay;
            IsoDayOfWeek = LocalDateTime.DayOfWeek;
            Duration = Duration.FromDays(2) + Duration.FromHours(14) + Duration.FromMinutes(39) + Duration.FromSeconds(17);

            var periodBuilder = new PeriodBuilder
            {
                Months = 2,
                Days = 1,
                Hours = 4,
                Minutes = 5
            };
            Period = periodBuilder.Build();

            Interval = new Interval(Instant, Instant + Duration);

            DateInterval = new DateInterval(LocalDate, LocalDate + Period.FromDays(5));
        }

        public DateInterval DateInterval { get; set; }
        public DateTimeZone DateTimeZone { get; set; }
        public Duration Duration { get; set; }
        public Instant Instant { get; set; }
        public Interval Interval { get; set; }
        public IsoDayOfWeek IsoDayOfWeek { get; set; }
        public LocalDate LocalDate { get; set; }
        public LocalDateTime LocalDateTime { get; set; }
        public LocalTime LocalTime { get; set; }
        public Offset Offset { get; set; }
        public OffsetDate OffsetDate { get; set; }
        public OffsetDateTime OffsetDateTime { get; set; }
        public OffsetTime OffsetTime { get; set; }
        public Period Period { get; set; }
        public ZonedDateTime ZonedDateTime { get; set; }

        #region Nullable With Values

        public Duration? NullableDuration => Duration;
        public Instant? NullableInstant => Instant;
        public Interval? NullableInterval => Interval;
        public IsoDayOfWeek? NullableIsoDayOfWeek => IsoDayOfWeek;
        public LocalDate? NullableLocalDate => LocalDate;
        public LocalDateTime? NullableLocalDateTime => LocalDateTime;
        public LocalTime? NullableLocalTime => LocalTime;
        public Offset? NullableOffset => Offset;
        public OffsetDate? NullableOffsetDate => OffsetDate;
        public OffsetDateTime? NullableOffsetDateTime => OffsetDateTime;
        public OffsetTime? NullableOffsetTime => OffsetTime;
        public ZonedDateTime? NullableZonedDateTime => ZonedDateTime;

        #endregion

        #region Nullable With Default Values

        public DateInterval NullDateInterval => default;
        public DateTimeZone NullDateTimeZone => default;
        public Duration? NullDuration => default;
        public Instant? NullInstant => default;
        public Interval? NullInterval => default;
        public IsoDayOfWeek? NullIsoDayOfWeek => default;
        public LocalDate? NullLocalDate => default;
        public LocalDateTime? NullLocalDateTime => default;
        public LocalTime? NullLocalTime => default;
        public Offset? NullOffset => default;
        public OffsetDate? NullOffsetDate => default;
        public OffsetDateTime? NullOffsetDateTime => default;
        public OffsetTime? NullOffsetTime => default;
        public Period NullPeriod => default;
        public PeriodBuilder NullPeriodBuilder => default;
        public ZonedDateTime? NullZonedDateTime => default;

        #endregion
    }
}
