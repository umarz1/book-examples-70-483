using book_examples_70_483.Chapter_1;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace book_examples_70_483
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //ParallelInvoke.Example();
            //ParallelForEach.Example();
            //ParallelFor.Example();
            //ParallelLoopStateExample.Example();
            //ParallelLINQ.Example();
            //ParallelLINQ.ExampleInformingParallelism();
            //ParallelLINQ.ExampleAsOrdered();
            ParallelLINQ.ExampleAsSequential();
            Console.ReadKey();
        }


    }
}
