using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Thread

            Console.WriteLine("*** PURE THREAD");
            Console.WriteLine("Main thread: starting a dedicated thread" + " " +
                              "to do asynchronous operation");

            var thread = new Thread(ComputeBoundOp);
            thread.Name = "My own Thread!";
            thread.Start(5);

            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(1000);

            thread.Join();
            #endregion

            #region Thread Pool

            Console.WriteLine(Environment.NewLine + "*** THREAD POOL THREAD");
            Console.WriteLine("Main thread: go on runnig" + " " +
                              "to do asynchronous operation");

            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);

            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(1000);

            #endregion

            #region Cancellation thread

            Console.WriteLine(Environment.NewLine + "*** CANCELLATION THREAD");
            var cancelletionTokeSurce = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(k => Count(cancelletionTokeSurce, 100));
            
            Console.WriteLine("Hit <ENTER> TO EXIT the program...");
            Console.ReadKey();

            cancelletionTokeSurce.Cancel();

            #endregion

            #region Linked cancellation

            Console.WriteLine(Environment.NewLine + "*** LINKED CANCELLATION");

            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("Token1 was cancelled!"));

            var cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("Token2 was cancelled!"));

            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("Linked token cancelled"));

            cts2.Cancel();

            Console.WriteLine("cts1 cancelled={0} | cts2 cancelled={1} | linkedCts={2}", cts1.IsCancellationRequested,
                cts2.IsCancellationRequested, linkedCts.IsCancellationRequested);

            #endregion

        }

        private static void ComputeBoundOp(Object state)
        {
            Console.WriteLine("In ComputeBondOp: state={0}", state);
            //Thread.Sleep(1000);
        }

        private static void Count(CancellationTokenSource token, int countFrom)
        {
            for (int i = countFrom; i >= 0; i--)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled!");
                    break;
                }

                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("Count is done!");
        }
    }
}
