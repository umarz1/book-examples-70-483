using book_examples_70_483.Chaper_3;
using book_examples_70_483.Chapter_1;
using book_examples_70_483.Chapter_3;
using System;
using System.Diagnostics;
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
            //ParallelLINQ.ExampleAsSequential();

            //AESEncryption.Example1();
            //RSAEncryption.Example1();

            //JsonExample.ProcessJsonDeserialize();
            //JsonExample.JsonExceptionExample();
            //XmlExample.SerializeString();

            CopyConstructorExample.CopyConstructorExample1(); 


            //PerformanceCounter performanceCounter = new PerformanceCounter(
            //    categoryName:"Processor Information",
            //    counterName: "% Processor Time",
            //    instanceName:"_Total");

            //Console.WriteLine("Press any key to stop");

            //while (true)
            //{
            //    Console.WriteLine("Processor time {0}", performanceCounter.NextValue());
            //    Thread.Sleep(500);

            //    if (Console.KeyAvailable)
            //        break;
            //}




            //var date = new DateTime();
            //double temp = 26.452;

            //Console.WriteLine(string.Format("Temperature at: {0:t} on {0:d} : {1:N2}", date, temp));


            Console.ReadKey();
        }


    }
}
