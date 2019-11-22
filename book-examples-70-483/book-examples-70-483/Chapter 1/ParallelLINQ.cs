using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace book_examples_70_483.Chapter_1
{
    public class ParallelLINQ
    {
        //AsParallel method checks query to see if parallel version would speed it up
        //If so query is broken down in chunks and ran concurrently
        //If not >> not parallel


        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(2000);
            Console.WriteLine("Finished working on: " + item);
        }
        public static void Example()
        {

            var people = new Person[]
            {
                new Person {Name = "Test1", City = "Test city1" },
                new Person { Name = "Test2", City = "Test city2" }
            };

            var result = from person in people.AsParallel()
                         where person.City == "Test city1"
                         select person;

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }
        }


        public static void ExampleInformingParallelism()
        {

            var people = new Person[]
            {
                new Person {Name = "Test1", City = "Test city1" },
                new Person { Name = "Test2", City = "Test city2" },
                new Person { Name = "Test3", City = "Test city3" },
                new Person { Name = "Test4", City = "Test city4" },
                new Person { Name = "Test5", City = "Test city4" }
            };


            //Max 4 concurrently executing tasks

            var result = from person in people.AsParallel()
                         .WithDegreeOfParallelism(4)
                         .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Test city4"
                         select person;

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }
        }

        public static void ExampleAsOrdered()
        {

            var people = new Person[]
            {
                new Person {Name = "Test1", City = "Test city1" },
                new Person { Name = "Test2", City = "Test city2" },
                new Person { Name = "Test3", City = "Test city3" },
                new Person { Name = "Test4", City = "Test city4" },
                new Person { Name = "Test5", City = "Test city4" },
                new Person { Name = "Test6", City = "Test city4" },
                new Person { Name = "Test7", City = "Test city4" },
            };


            //AsOrdered doesn't prevent parallization of the query
            //it organises the output so that it is in he same order as the input
            //Can slow down query
            //Sorts order of output but doesn't run queries in order

            var result = from person in people.AsParallel().AsOrdered()
                         where person.City == "Test city4"
                         select person;

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }
        }

        public static void ExampleAsSequential()
        {

            var people = new Person[]
            {
                new Person {Name = "Test1", City = "Test city1" },
                new Person { Name = "Test2", City = "Test city2" },
                new Person { Name = "Test3", City = "Test city3" },
                new Person { Name = "Test4", City = "Test city4" },
                new Person { Name = "Test5", City = "Test city4" },
                new Person { Name = "Test6", City = "Test city4" },
                new Person { Name = "Test7", City = "Test city4" },
            };


            //AsSequential doesn't prevent parallization of the query

            var result = (from person in people.AsParallel()
                          where person.City == "Test city4"
                          orderby (person.Name)
                          select new
                          {
                              Name = person.Name,

                          }).AsSequential().Take(4);
                         

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }
        }



        public class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }
    }
}
