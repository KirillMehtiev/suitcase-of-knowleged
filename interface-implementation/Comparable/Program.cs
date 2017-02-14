using System;

namespace Comparable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Point p1 = new Point(10, 10);
            Point p2 = new Point(20, 20);

            Console.WriteLine(p1.CompareTo(p2));
        }
    }
}
