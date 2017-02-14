using System;
using System.Collections.Generic;

namespace Equality
{
    enum CarColor
    {
        Red,
        Green,
        Blue
    }

    class Car : IEquatable<Car>
    {
        public readonly Guid Id;
        public readonly CarColor Color;
        public readonly DateTime Manufactured;

        public Car(CarColor color, DateTime manufactured)
        {
            Id = Guid.NewGuid();
            Color = color;
            Manufactured = manufactured;
        }

        // implement IEquatable<>
        public bool Equals(Car other)
        {
            if (Object.ReferenceEquals(null, other))
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            return Color == other.Color && DateTime.Equals(Manufactured, other.Manufactured);
        }

        // override object.Equals
        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            return Equals((Car)other);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                // choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Color.GetHashCode();
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Manufactured) ? Manufactured.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(Car left, Car right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (Object.ReferenceEquals(null, left))
            {
                return false;
            }

            return left.Equals(right);

        }

        public static bool operator !=(Car left, Car right)
        {
            return !(left == right);
        }

    }
}
