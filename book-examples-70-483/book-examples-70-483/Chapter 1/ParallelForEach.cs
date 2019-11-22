using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace book_examples_70_483.Chapter_1
{
    public class ParallelForEach
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: "+ item);
            Thread.Sleep(2000);
            Console.WriteLine("Finished working on: " + item);
        }
        public static void Example()
        {
            var items = Enumerable.Range(0, 500);

            //Takes 2 params ..collection and action to be taken on each item
            //Tasks not completed same order they started

            Parallel.ForEach(items, item => WorkOnItem(item)); 
        }
    }
}
