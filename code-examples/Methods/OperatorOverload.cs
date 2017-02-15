using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Point
    {
        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Operator overload for Add operation.
        /// Possible Exeptions: 
        ///     StackOverflowException
        /// </summary>
        /// <param name="p1">First point to add</param>
        /// <param name="p2">Second point to add</param>
        /// <returns>Result of adding the two points</returns>
        public static Point operator +(Point p1, Point p2)
        {
            int x, y;

            checked
            {
                x = p1._x + p2._x;
                y = p1._y + p2._y;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// Operator overload for Subtract operation.
        /// Possible Exeptions: 
        ///     StackOverflowException
        /// </summary>
        /// <param name="p1">First point to add</param>
        /// <param name="p2">Second point to add</param>
        /// <returns>Result of subtracting the two points</returns>
        public static Point operator -(Point p1, Point p2)
        {
            int x, y;

            checked
            {
                x = p1._x - p2._x;
                y = p1._y - p2._y;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// Operator overload for Add operation.
        /// Possible Exeptions: 
        ///     StackOverflowException
        /// </summary>
        /// <param name="p1">First point to add</param>
        /// <param name="p2">Second point to add</param>
        /// <returns>Result of adding the two points</returns>
        public static Point Add(Point p1, Point p2)
        {
            return p1 + p2;
        }

        /// <summary>
        /// Operator overload for Subtract operation.
        /// Possible Exeptions: 
        ///     StackOverflowException
        /// </summary>
        /// <param name="p1">First point to add</param>
        /// <param name="p2">Second point to add</param>
        /// <returns>Result of subtracting the two points</returns>
        public static Point Subtract(Point p1, Point p2)
        {
            return p1 - p2;
        }
    }
}
