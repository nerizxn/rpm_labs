using System;

class Program
{
    static void Main()
    {
        int counterWhile = 1;
        while (counterWhile <= 6)
        {
            Console.WriteLine("counter = " + counterWhile);
            counterWhile++;
        }

        for (int counterFor = 1; counterFor <= 6; counterFor++)
        {
            Console.WriteLine("counter = " + counterFor);
        }

        Console.ReadLine();
    }
}