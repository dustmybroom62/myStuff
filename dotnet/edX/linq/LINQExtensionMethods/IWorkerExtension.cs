using System;

public static class IWorkerExtension {
    public static IWorker Introduce1(this IWorker worker) {
        Console.WriteLine($"Hi, my name is {worker.Name}.");
        return worker;
    }

    public static IWorker Introduce2(this IWorker worker) {
        Console.WriteLine($"My major scope is {worker.Scope}.");
        return worker;
    }

    public static IWorker Introduce3(this IWorker worker) {
        Console.WriteLine($"I have {worker.YearsOfExperience} years experience.");
        return worker;
    }
}