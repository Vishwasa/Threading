using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class PassingDataToThread
    {
        internal static void Test()
        {
            MainMethod();
            MultipleArgsUsingLambda();
        }
        static void MainMethod()
        {
            Thread t = new Thread(() => Print("Hello from t!"));
            t.Start();
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        //you can pass in any number of arguments to the method.
        //You can even wrap the entire implementation in a multi-statement lambda
        public static void MultipleArgsUsingLambda()
        {
            new Thread(() =>
            {
                Console.WriteLine("I'm running on another thread!");
                Console.WriteLine("This is so easy!");
            }).Start();

            new Thread(() => PrintArgs("Hello Vishwas", ", How are you doing?")).Start();
        }
        static void PrintArgs(string message, string msg2)
        {
            Console.WriteLine(message);
            Console.WriteLine(msg2);
        }

        //One more way to pass args using thread start method.
        //The limitation of ParameterizedThreadStart is that it accepts only one argument.
        //And because it’s of type object, it usually needs to be cast.
        static void MainMethod2()
        {
            Thread t = new Thread(Print);
            t.Start("Hello from t!");
        }

        static void Print(object messageObj)
        {
            string message = (string)messageObj;   // We need to cast here
            Console.WriteLine(message);
        }

    }
}
