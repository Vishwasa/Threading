using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        private static Semaphore _producerSignal = new Semaphore(1, 1);
        private static Semaphore _consumerSignal = new Semaphore(1, 1);
        static void Main(string[] args)
        {
            //List<int> BlockingQueue = new List<int>(4);
            //Thread t = new Thread(()=>Producer(BlockingQueue));
            //t.Start();
            //----------------------------

            //ThreadTest.Test();
            //ItsOwnMemoryStackForLocalVars.DemonstrtingThreadsOwnMemoryStackTest();
            //SharingDataBetweenThreads.Test();
            //ThreadSafeGoMethod.Test();
            //JoinAndSleep.Test();
            //ThreadStartDelegate.Test();
            //PassingDataToThread.Test();

            //UnisexBathroom bathRoom = new UnisexBathroom(3);
            UnisexBathroom.Test();
            Console.ReadLine();
        }

        private static void Producer(List<int> BlockingQueue)
        {
            _producerSignal.WaitOne();
            for (int i = 0; i < 50; i++)
            {
                Random r = new Random(5000);
                Thread.Sleep(r.Next());
                BlockingQueue.Add(i);
            }
            _producerSignal.Release();
        }
        private static void Consumer(List<int> BlockingQueue)
        {
            _consumerSignal.WaitOne();
            for (int i = 0; i < 50; i++)
            {
                Random r = new Random(5000);
                Thread.Sleep(r.Next());
                BlockingQueue.Add(i);
            }
            _consumerSignal.Release();
        }
    }
}
