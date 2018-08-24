using System;

namespace LINQExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new Writer
            {
                Name = "Timothy",
                Scope = ".NET Core",
                YearsOfExperience = 15
            };

            writer.Introduce1();
            writer.Introduce2();
            writer.Introduce3();
            writer.Write();

            var teacher = new Teacher {
                Name = "Teachy",
                Scope = "LINQ",
                YearsOfExperience = 10
            };

            teacher.Introduce1().Introduce2().Introduce3();
            teacher.Teach();
        }
    }
}
