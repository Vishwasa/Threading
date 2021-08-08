using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class JoinAndSleep
    {
        internal static void Test()
        {
            MainMethod();
        }
        static void MainMethod()
        {
            Thread t = new Thread(Go);
            t.Start();
            Console.WriteLine("In Main "+Thread.CurrentThread.ThreadState);
            t.Join();
            Console.WriteLine("In Main " + Thread.CurrentThread.ThreadState);

            Console.WriteLine("Thread t has ended!");
        }

        static void Go()
        {
            Console.WriteLine(Thread.CurrentThread.ThreadState);

            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
}
