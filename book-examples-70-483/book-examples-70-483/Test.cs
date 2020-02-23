using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Nancy.Json;

namespace book_examples_70_483
{
    public class Test
    {
        public class Animal
        {
            public string Colour { get; set; }
            public string Name { get; set; }
        }

        private static IEnumerable<Animal> GetAnimals(string sqlConnectionString)
        {
            var animals = new List<Animal>();
            var sqlConnection = new SqlConnection("Connection string");

            using (sqlConnection)
            {
                var sqlCommand = new SqlCommand("Select * from Whatever");

                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        var animal = new Animal();
                        animal.Colour = (string)sqlDataReader["Colour"];
                        animal.Name = (string)sqlDataReader["Name"];
                    }
                }
            }

            return animals;
        }



        public class LoanCollection : IEnumerable
        {

            public class Loan
            {

            }

            private readonly Loan[] _loanCollection;

            public LoanCollection(Loan[] loanArray)
            {
                _loanCollection = new Loan[loanArray.Length];

                for (int i = 0; i < loanArray.Length; i++)
                {
                    _loanCollection[i] = loanArray[i];
                }
            }
            public IEnumerator GetEnumerator()
            {
                return _loanCollection.GetEnumerator();
            }
        }


        public IEnumerable<decimal> LoanAmounts()
        {
            decimal[] loanAmounts = { 303m, 1000m, 86679, 501.51m, 603m, 1200m, 400m, 22m };

            var loanQueryResult = from amount in loanAmounts
                                  where amount % 2 == 0
                                  orderby amount ascending
                                  select amount;
            return loanQueryResult;
        }



        public class Name
        {
            public int[] Values { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public static Name ConvertToName(string json)
            {
                var ser = new JavaScriptSerializer();

                return ser.Deserialize<Name>(json);
            }
        }

        public enum Compass
        {
            North,
            South,
            East,
            West
        }

        [DataContract]
        public class Location
        {
            [DataMember]
            public string Label { get; set; }

            [DataMember]
            public Compass Direction { get; set; }

            void DoWork()
            {
                var location = new Location { Label = "Test", Direction = Compass.West };
               // Console.WriteLine(WriteObject(location))
            }
       }

        public interface IDataContainer
        {
           string Data { get; set; }
        }


        void DoWork(object obj)
        {
            var dataContainer = (IDataContainer)obj;

            if(dataContainer != null)
            {
                Console.WriteLine(dataContainer.Data);
            }
        }


        public static void Save<T>(T target) where T : Animal, new()
        {
            var animalColour = target.Colour;

        }

        public interface IOutputFormatter<T>
        {
            string GetOutput(IEnumerable<T> iterator, int recordSize);
        }

        public class TabDelimiterFormatter : IOutputFormatter<string>
        {
            readonly Func<int, char> suffix = col => col % 2 == 0 ? '\n' : '\t';

            public string GetOutput(IEnumerable<string> iterator, int recordSize)
            {
                //use string builder
                var output = new StringBuilder();
                return "";
            }
        }

       public static void Question()
        {
            var animal = new Animal();
            animal.Colour = "blue";

            var colour = animal.GetType().GetProperties().First(
                prop => prop.Name == "blue").GetValue("Colour").ToString();
             
        }


        public delegate void AddUserCallBack(int i);
        public class User
        {
            public User(string name)
            {
                Name = name;

            }
            public string Name { get; set; }
        }
        public class UserTracker
        {
            List<User> users = new List<User>();
            
            public void AddUser(string name, AddUserCallBack callBack)
            {
                users.Add(new User(name));
                callBack(users.Count);
            }
        }

        public class Runner
        {
            UserTracker tracker = new UserTracker();
            public void Add(string name)
            {
                tracker.AddUser(name, delegate (int i)
                {

                });
            }
        }


        public void Collections()
        {
            //var testInt = int.TryParse()
        }

    }


    public static class ExtensionMethods
    {
        public static bool IsUrl(this String str)
        {
            var regex = new Regex("");

            return regex.IsMatch(str);
        }

    }

}
