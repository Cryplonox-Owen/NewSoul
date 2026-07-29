using System;          // Import the System namespace (for Console and other basic classes)
using System.Linq;     // Import System.Linq for easy array operations like counting and filtering

class Program
{
    static void Main()
    {
        // ============================
        // PART 1: EVEN AND ODD NUMBERS
        // ============================

        // Declare and initialize an integer array with given numbers
        int[] numbers = { 1, 2, 8, 10, 9, 3, 11, 21, 33, 22, 16, 19, 18 };

        // Display a header for even numbers
        Console.Write("Even: ");

        // Loop through each element in the array using foreach
        foreach (int num in numbers)
        {
            // Check if the number is even using modulus operator (%)
            // If the remainder when divided by 2 is zero, it's even
            if (num % 2 == 0)
            {
                // Print the even number followed by a space
                Console.Write(num + " ");
            }
        }

        // Move to the next line after displaying even numbers
        Console.WriteLine();

        // Display a header for odd numbers
        Console.Write("Odd: ");

        // Loop again through the same array to find odd numbers
        foreach (int num in numbers)
        {
            // Check if the number is odd (remainder when divided by 2 is NOT zero)
            if (num % 2 != 0)
            {
                // Print the odd number followed by a space
                Console.Write(num + " ");
            }
        }

        // Move to the next line to separate the outputs
        Console.WriteLine("\n");


        // ============================
        // PART 2: UNIQUE NUMBERS
        // ============================

        // Declare and initialize another integer array with repeated numbers
        int[] array2 = { 3, 4, 5, 6, 7, 5, 1, 3, 9, 4, 7 };

        // Display a header for the unique numbers
        Console.WriteLine("Unique numbers in the array:");

        // Loop through each element in the array
        foreach (int num in array2)
        {
            // Use LINQ's Count() method to count how many times the number appears in the array
            int count = array2.Count(x => x == num);

            // If the number appears only once (count == 1), it is unique
            if (count == 1)
            {
                // Print the unique number
                Console.WriteLine(num);
            }
        }

        // End of program
        Console.WriteLine("\nProgram finished.");
    }
}
