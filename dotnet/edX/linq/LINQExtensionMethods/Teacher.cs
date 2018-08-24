using System;

public class Teacher : IWorker {
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public string Scope { get; set; }
        public void Teach() { Console.WriteLine($"Teacher:: Name({Name}), Years({YearsOfExperience}), Scope({Scope})"); }
    }