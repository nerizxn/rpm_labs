using System;

class Program
{
    static void Main()
    {
        int[] myValues = { 9, 4, 7, 83, -9 };
        foreach (int counter in myValues)
        {
            Console.WriteLine("counter = " + counter);
        }

        Console.ReadLine();
    }
}