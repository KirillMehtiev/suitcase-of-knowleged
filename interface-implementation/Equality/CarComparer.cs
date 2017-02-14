using System;
using System.Collections.Generic;

namespace Equality
{
    class CarComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x == y;
        }

        // Exceptions:
        //   System.ArgumentNullException:
        //      The type of obj is a reference type and obj is null.
        public int GetHashCode(Car obj)
        {
            if (Object.ReferenceEquals(obj, null))
                throw new ArgumentNullException();

            return obj.GetHashCode();
        }
    }
}