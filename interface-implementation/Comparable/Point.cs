using System;

namespace Comparable
{
    struct Point : IComparable
    {
        private int m_x, m_y;

        public Point(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public override string ToString()
        {
            return $"{m_x} , {m_y}";
        }

        public int CompareTo(object obj)
        {
            if (GetType() != obj.GetType())
            {
                throw new ArgumentException("obj is not a Point");
            }

            return CompareTo((Point)obj);
        }

        public int CompareTo(Point other)
        {
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y) - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
        }
    }
}