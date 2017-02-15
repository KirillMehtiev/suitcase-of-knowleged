using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public sealed class ComplexType
    {
        public ComplexType(int num) { }

        public ComplexType(double num) { }

        public int ToInt32()
        {
            return 0;
        }

        public double ToDouble()
        {
            return 0.0;
        }

        public static implicit operator ComplexType(int num)
        {
            return new ComplexType(num);
        }

        public static implicit operator ComplexType(double num)
        {
            return new ComplexType(num);
        }

        public static explicit operator Int32(ComplexType c)
        {
            return c.ToInt32();
        }

        public static explicit operator Double(ComplexType c)
        {
            return c.ToDouble();
        }
    }
}
