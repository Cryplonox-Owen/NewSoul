using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 8, 10, 9, 3, 11, 21, 33, 22, 16, 19, 18 };

        Console.WriteLine("Even: ");
        foreach (int num in numbers)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine(num + " ");

            }
        }
        Console.WriteLine();
        Console.WriteLine("Odd: ");
        foreach (int num in numbers)
        {
            if (num % 2 != 0)
            {
                Console.WriteLine(num + " ");
            }
        }
        Console.WriteLine("n/");
        int[] array2 = { 3, 4, 5, 6, 7, 5, 1, 3, 9, 4, 7 };
        Console.WriteLine("Unique numbers in the array:");

        foreach (int num in array2)
        {
            int count = array2.Count(x => x == num);
            if (count == 1)
            {
                Console.WriteLine(num);
            }
        }
        Console.WriteLine("\nProgram Finished");
    }
}