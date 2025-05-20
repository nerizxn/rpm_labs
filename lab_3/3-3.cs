using System;

class Program
{
    static void Main()
    {
        int myInt1 = 20313;
        int myInt2 = 20682;
        float myFloat = 1234.56789f;

        Console.WriteLine("myInt1 = {0, 6}, myInt2 = {1, 6}", myInt1, myInt2);
        Console.WriteLine("myFloat в формате 10:f4 = {0, 10:f4}", myFloat);
        
        Console.ReadLine();
    }
}