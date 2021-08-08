using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class UnisexBathroom
    {
        static internal void Test()
        {
            UnisexBathroom bathRoom = new UnisexBathroom(3);
            for (int i = 0; i < 15; i++)
            {
                var x = i;
                //new Thread(() => { bathRoom.useBathroom(Sex.Male, "F" + i); }).Start();
                Random r = new Random();
                //Thread.Sleep(r.Next(200, 897));
                //ThreadPool.QueueUserWorkItem();
                if (i%7==0)
                {
                    Thread.Sleep(10000);
                }
                new Thread(() => { bathRoom.useBathroom((Sex)r.Next(0, 2), x.ToString()); }).Start();
            }
            Thread.Sleep(60000);
            for (int i = 15; i < 30; i++)
            {
                var x = i;
                //new Thread(() => { bathRoom.useBathroom(Sex.Male, "F" + i); }).Start();
                Random r = new Random();
                //Thread.Sleep(r.Next(200, 897));
                //ThreadPool.QueueUserWorkItem();
                new Thread(() => { bathRoom.useBathroom((Sex)r.Next(0, 2), x.ToString()); }).Start();
            }
        }

        Semaphore maxAllowedPeople;
        Sex currentlyOccupied = Sex.None;
        int totalOccupied = 0;
        
        public UnisexBathroom(int maxCapacity)
        {
            maxAllowedPeople = new Semaphore(maxCapacity, maxCapacity);
        }

        public void useBathroom(Sex sex, string name)
        {
            while (!(currentlyOccupied == sex || currentlyOccupied == Sex.None))
            {
                Thread.Sleep(10);
            }
            {
                //Console.WriteLine($"hi {name} is {sex}");
                maxAllowedPeople.WaitOne();
                currentlyOccupied = sex;
                totalOccupied++;
                Console.WriteLine($"{name} with {sex} has entered");
                Random r = new Random();
                Thread.Sleep(3000 + 1500 * r.Next(9));
                Console.WriteLine($"{name} with {sex} has left");
                totalOccupied--;
                if (totalOccupied == 0)
                {
                    currentlyOccupied = Sex.None;
                }
                maxAllowedPeople.Release();
            }

        }
    }

    enum Sex
    {
        Male,
        Female,
        None
    }
}
