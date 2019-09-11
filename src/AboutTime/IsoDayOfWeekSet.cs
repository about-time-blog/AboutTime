using System;
using System.Collections;
using System.Collections.Generic;
using NodaTime;

namespace AboutTime
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public class IsoDayOfWeekSet : ICollection<IsoDayOfWeek>, IEquatable<IsoDayOfWeekSet>
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        private byte _days;

        public IsoDayOfWeekSet()
        {
        }

        public IsoDayOfWeekSet(IEnumerable<IsoDayOfWeek> daysOfWeek)
        {
            if (daysOfWeek is null)
            {
                throw new System.ArgumentNullException(nameof(daysOfWeek));
            }

            foreach (var dayOfWeek in daysOfWeek)
            {
                Add(dayOfWeek);
            }
        }

        public int Count => _days.CountNumberOfOnes();

        public bool IsReadOnly => false;

        public static IsoDayOfWeekSet WithAllDays() => new IsoDayOfWeekSet { _days = 0b11111110 };

        public IEnumerator<IsoDayOfWeek> GetEnumerator()
        {
            for (var day = IsoDayOfWeek.Monday; day <= IsoDayOfWeek.Sunday; ++day)
            {
                if (Contains(day))
                {
                    yield return day;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(IsoDayOfWeek item)
        {
            if (item < IsoDayOfWeek.Monday || IsoDayOfWeek.Sunday < item)
            {
                throw new ArgumentOutOfRangeException(nameof(item));
            }

            _days |= ToByte(item);
        }

        public void Clear() => _days = 0;

        public bool Contains(IsoDayOfWeek item) => (_days & ToByte(item)) > 0;

        public void CopyTo(IsoDayOfWeek[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new System.ArgumentNullException(nameof(array));
            }

            using (var enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    array[arrayIndex++] = enumerator.Current;
                }
            }
        }

        // TODO: Test
        public bool IntersectsWith(IsoDayOfWeekSet other)
        {
            if (other is null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }

            return (_days & other._days) > 0;
        }

        public bool Remove(IsoDayOfWeek item)
        {
            var result = Contains(item);
            _days &= (byte)~ToByte(item);
            return result;
        }

        public bool Equals(IsoDayOfWeekSet other) => !(other is null) && (ReferenceEquals(this, other) || _days == other._days);

        public override bool Equals(object obj) => !(obj is null) && (ReferenceEquals(this, obj) || (obj.GetType() == GetType() && Equals((IsoDayOfWeekSet)obj)));

        public override int GetHashCode() => _days.GetHashCode();

        private static byte ToByte(IsoDayOfWeek dayOfWeek) => (byte)(1 << (int)dayOfWeek);

        public static bool operator ==(IsoDayOfWeekSet left, IsoDayOfWeekSet right) => Equals(left, right);

        public static bool operator !=(IsoDayOfWeekSet left, IsoDayOfWeekSet right) => !Equals(left, right);
    }
}