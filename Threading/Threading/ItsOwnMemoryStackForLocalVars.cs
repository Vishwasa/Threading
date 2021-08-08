using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class ItsOwnMemoryStackForLocalVars
    {
        internal static void DemonstrtingThreadsOwnMemoryStackTest()
        {
            DemonstrtingThreadsOwnMemoryStack();
        }
        static void DemonstrtingThreadsOwnMemoryStack()
        {
            new Thread(Go).Start();      // Call Go() on a new thread
            Go();                         // Call Go() on the main thread
        }

        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write(cycles);
        }
    }
}
