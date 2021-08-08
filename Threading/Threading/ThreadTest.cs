using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class ThreadTest
    {

        internal static void Test()
        {
            WriteXAndY();
        }
        static void WriteXAndY()
        {
            Thread t = new Thread(WriteY);          // Kick off a new thread
            t.Start();                               // running WriteY()
            //Consot.IsAlive;

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x-"+Thread.CurrentThread.IsAlive+";");
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) Console.Write("::y-"+Thread.CurrentThread.IsAlive+";");
        }
    }
}
