using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class SharingDataBetweenThreads
    {
        internal static void Test()
        {
            SharingDataBetweenThreadsPossibleAsaRef();
        }
        bool done;

        static void SharingDataBetweenThreadsPossibleAsaRef()
        {
            SharingDataBetweenThreads tt = new SharingDataBetweenThreads();   // Create a common instance
            var thread = new Thread(tt.Go);
            thread.Name = "child";
            thread.Start();
            Thread.Sleep(1000);//with this line child executes go once; without this main thread executes once;
            //In any case Go method will be executed only once.
            tt.Go();

        }

        // Note that Go is now an instance method
        void Go()
        {
            //Threadsafety: Below line demonstrates the issues with threadsafety, both threds can access below if no sleep is there on any threads.
            //if (!done) { Console.WriteLine("Done with " + Thread.CurrentThread.Name); done = true; }

            if (!done) { done = true; Console.WriteLine("Done with "+Thread.CurrentThread.Name); }
        }
    }
}
