using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace book_examples_70_483.Chapter_1
{
    public class ParallelLoopStateExample
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

            ParallelLoopResult result = Parallel.For(0, items.Length, (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                {
                    //Doesn't guarentee that iterations lower than 200 are performed. Break does.
                    loopState.Stop();
                }
                WorkOnItem(items[i]);
            });
        }
    }
}
