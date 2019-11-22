using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace book_examples_70_483.Chapter_1
{
   public class ParallelInvoke
    {
        public static void Example()
        {
            //Invoke takes action delegates
            //Action delegate is an encapuslation of a method that accepts no parameters and does not return a result >>
            //can also be replaced by a lambda expression

            //Starts at once with a number of tasks at the same time
            //No control of order
            //No control on which processor they are assigned to

            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("Finished processing. Press a key to end");
        }
        public static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 2 ending");
        }
    }
}
