using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class ThreadSafeGoMethod
    {
        static bool done;
        static readonly object locker = new object();

        internal static void Test()
        {
            MainMethod();
        }
        static void MainMethod()
        {
            Thread.CurrentThread.Name = "Main Thread";
            var thread = new Thread(Go);
            thread.Name = "ChildThread";
            thread.Start();
            //Thread.Sleep(1000); //use this line to switch between child thread and main thread.
            Go();

        }

        static void Go()
        {
            lock (locker)
            {
                //Check method in SharingDataBetweenThreds to see the problem which is overcomed using lock
                if (!done) { Console.WriteLine("Done " + Thread.CurrentThread.Name); done = true; }
            }
        }
    }
}
