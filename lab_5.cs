using System;

public class Computer
{
    public string ProcessorModel;
    public int RAM;
    public int Storage;
    public int YearManufactured; 

    public int CalculateAge(int currentYear)
    {
        return currentYear - YearManufactured;
    }

    public double CalculatePerformance(double basePerformance)
    {
        int age = CalculateAge(DateTime.Now.Year);
        return basePerformance * Math.Pow(0.95, age);
    }

    public bool CanRunProgram(int requiredRAM, int requiredStorage)
    {
        return RAM >= requiredRAM && Storage >= requiredStorage;
    }
}

class Program
{
    static void Main()
    {
        Computer myPC = new Computer();
        myPC.ProcessorModel = "Intel Core i7-10700K";
        myPC.RAM = 16;
        myPC.Storage = 512;
        myPC.YearManufactured = 2020;
        
        int age = myPC.CalculateAge(2023);
        double performance = myPC.CalculatePerformance(1000);
        bool canRun = myPC.CanRunProgram(8, 256);
        
        Console.WriteLine("=== Характеристики компьютера ===");
        Console.WriteLine($"Процессор: {myPC.ProcessorModel}");
        Console.WriteLine($"Возраст: {age} лет");
        Console.WriteLine($"Текущая производительность: {performance:F2} усл. ед.");
        Console.WriteLine($"Может запустить программу (требуется 8 ГБ RAM и 256 ГБ SSD): {(canRun ? "Да" : "Нет")}");

        Console.ReadLine();
    }
}