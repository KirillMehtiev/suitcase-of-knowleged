using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: starting a dedicated thread" +
                "to do asynchronous operation");
            var thread = new Thread(ComputeBoundOp);
            thread.Start(5);

            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000);

            thread.Join();
            Console.WriteLine("Hit <Enter> to exit the program...");
            Console.ReadKey();
        }

        private static void ComputeBoundOp(Object state)
        {
            Console.WriteLine("In ComputeBondOp: state={0}", state);
            //Thread.Sleep(1000);
        }
    }
}
