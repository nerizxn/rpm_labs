using System;

class Program
{
    static void Main()
    {
        int smallNumber = 660;
        int bigNumber = 675;

        if (bigNumber > smallNumber)
        {
            Console.WriteLine(bigNumber + " больше, чем " + smallNumber);
        }
        else
        {
            Console.WriteLine(bigNumber + " меньше, чем " + smallNumber);
        }

        Console.ReadLine();
    }
}
