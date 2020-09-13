using System.Collections.Generic;

namespace AlgorithmAnalysis
{
    public class Algorithms3
    {
        //Do not alter method signatures or types
        public static List<string> SortByLastNameThenFirstName()
        {
            // Write code to return a list of strings sorted by last name, 
            // then first name, then age. Use the format: "{LastName} - {FirstName} - {Age}"
            //
            // Example string: Burgundy - Ron - 43
            return new List<string>();
        }

        public static List<string> CountsByFirstName()
        {
            // Write code to return a list of strings string with a count of the number of times each first name occurs, ordered by occurence.
            // Use this format: "{name}, {count}" When printed the output should 
            // look like this:
            //
            // Example string: Ron, 2
            return new List<string>();
        }

        public static List<Person> _People =
            new List<Person> {
                new Person { FirstName = "Amy", LastName="Monroe", Age = 54},
                new Person { FirstName = "Amy", LastName="Duval", Age = 54},
                new Person { FirstName = "Joe", LastName="Conrad", Age = 14},
                new Person { FirstName = "Amy", LastName="Jenkins", Age = 34},
                new Person { FirstName = "Bill", LastName="Monroe", Age = 34},
                new Person { FirstName = "Amy", LastName="Smith", Age = 34},
                new Person { FirstName = "Joe", LastName="Johnson", Age = 14}};

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}
