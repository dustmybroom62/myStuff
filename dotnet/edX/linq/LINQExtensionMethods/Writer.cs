using System;

public class Writer : IWorker {
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public string Scope { get; set; }
        public void Write() { Console.WriteLine($"Writer:: Name({Name}), Years({YearsOfExperience}), Scope({Scope})"); }
    }
