using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {

            A a1 = new A();
            A a2 = a1;

            Console.WriteLine(a1 == a2); // True

            a2 = a1.ShallowCopy();

            Console.WriteLine(a1 == a2); // False


            // *** Extention methods in use

            "Amazing".ShowItem();

            new[] { "Test", "Array" }.ShowItem();

            Action<object> a = (obj) => Console.WriteLine(obj.GetType());   // Throw NullReferenceExeption
            a.InvokeAndCatch<NullReferenceException>(null);                 // Swallows NullReferenceExeption

            Action b = "Kirik".ShowItem;
            b();

            // *** Partial Methods
            Base mBase = new Base();

            Console.WriteLine(mBase.Name);

            mBase.Name = "Kirill";

            Console.WriteLine(mBase.Name);

            // *** Recursion methods
            var result = CalcMethods.FacultyRecursion(0);
            Console.WriteLine(result);

            var stopwatch = new Stopwatch();
            uint num = 40;

            stopwatch.Start();
            CalcMethods.FibonacciRecursive(num);
            stopwatch.Stop();
            
            Console.WriteLine($"Fibonacci for {num} using recursion: elapsed time = {stopwatch.Elapsed.Seconds}");
            stopwatch.Reset();

            stopwatch.Start();
            CalcMethods.FibonacciNonRecursive(num);
            stopwatch.Stop();

            Console.WriteLine($"Fibonacci for {num} using nonrecursive method: elapsed time = {stopwatch.Elapsed.Seconds}");
            stopwatch.Reset();
        }
    }

    class A
    {
        public A ShallowCopy()
        {
            return MemberwiseClone() as A;
        }
    }
}
