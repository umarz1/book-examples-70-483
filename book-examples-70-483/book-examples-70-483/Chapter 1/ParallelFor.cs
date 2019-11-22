using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace book_examples_70_483.Chapter_1
{
    public class ParallelFor
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: "+ item);
            Thread.Sleep(2000);
            Console.WriteLine("Finished working on: " + item);
        }
        public static void Example()
        {
            var items = Enumerable.Range(0, 500).ToArray();

            //3 params .. starting at 0, to--length of array, lambda expression
            //Same output as foreach
            //Tasks not completed same order they started

            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });

            Console.WriteLine("Finished processing. Press a key to end");
            

        }
    }
}
