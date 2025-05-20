using System;

class Program
{
    static void Main()
    {
        int counter = 22;
        do
        {
            Console.WriteLine("counter = " + counter);
            counter--;
        } while (counter > 1);

        Console.ReadLine();
    }
}