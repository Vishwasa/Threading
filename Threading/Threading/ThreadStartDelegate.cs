using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    //public delegate void ThreadStart();
    class ThreadStartDelegate
    {
        public static void Test()
        {
            MainMethod();
            UsingAnonymousFunction();
        }
        static void UsingAnonymousFunction()
        {
            Thread t = new Thread(() => Console.WriteLine("Hello!"));
            t.Start();
        }
        static void MainMethod()
        {
            Thread t = new Thread(new ThreadStart(Go));

            t.Start();   // Run Go() on the new thread.
            Go();        // Simultaneously run Go() in the main thread.
        }

        static void Go()
        {
            Console.WriteLine("hello!");
        }
    }
}
