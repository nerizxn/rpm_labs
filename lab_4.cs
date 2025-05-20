using System;

class Program
{
    public class Smartphone
        {
            public string Brand;
            public string Model;
            public int RAM;
            public int Storage;
            public int YearReleased;
        
            public void PowerOn()
            {
                Console.WriteLine($"{Brand} {Model} включен.");
            }
        
            public void PowerOff()
            {
                Console.WriteLine($"{Brand} {Model} выключен.");
            }
        
            public void DisplaySpecs()
            {
                Console.WriteLine($"Характеристики: {RAM} ГБ RAM, {Storage} ГБ памяти, год выпуска: {YearReleased}.");
            }
        }

    static void Main()
    {
        Smartphone phone1 = new Smartphone();
        phone1.Brand = "Samsung";
        phone1.Model = "Galaxy S21";
        phone1.RAM = 8;
        phone1.Storage = 128;
        phone1.YearReleased = 2021;

        Console.WriteLine("=== Первый смартфон ===");
        phone1.PowerOn();
        phone1.DisplaySpecs();
        phone1.PowerOff();
        Console.WriteLine();

        Smartphone phone2 = new Smartphone();
        phone2.Brand = "Apple";
        phone2.Model = "iPhone 13";
        phone2.RAM = 6;
        phone2.Storage = 256;
        phone2.YearReleased = 2021;

        Console.WriteLine("=== Второй смартфон ===");
        phone2.PowerOn();
        phone2.DisplaySpecs();
        phone2.PowerOff();
        Console.WriteLine();

        phone1 = phone2;
        Console.WriteLine("=== После переназначения ссылки ===");
        Console.WriteLine($"phone1 теперь ссылается на: {phone1.Brand} {phone1.Model}");
        Console.WriteLine();

        phone1 = null;
        Console.WriteLine("=== После присвоения null ===");
        Console.WriteLine("Ссылка phone1 больше не указывает на объект.");

        Console.ReadLine();
    }
}