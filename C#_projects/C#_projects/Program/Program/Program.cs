using System;
class Program
{
    static void Main()
    {
        //1 find the sum, difference, as well as product, quotient 3 and 5
        int c = 3;
        int d = 5;
        int sum = c + d;
        int difference = c - d;
        int product = c * d;
        double quotient = (double)c / d;
        Console.WriteLine($"the sum of:" + sum);
        Console.WriteLine($"the difference of:" + difference);
        Console.WriteLine($"product: {product}");
        Console.WriteLine($"quotient: {quotient}");
        //2 ----------------
        int A = 32;
        int B = 27;
        Console.WriteLine($"before the swap:A = {A}, B = {B}");
        int temp = A;
        A = B;
        B = temp;
        Console.WriteLine($"after the swap: A = {A}, B = {B}");
        //3 ------------
        int number = 347257;
        int firstdigit = number;
        while (firstdigit >= 10)
        {
            firstdigit /= 10;
        }
        int lastdigit = number % 10;
        int sumfirstlast = firstdigit + lastdigit;
        Console.WriteLine($"first digit: {firstdigit}, lastdigit: {lastdigit}");

        //4______
        double quizzes = 82;
        double assigntment = 89;
        double activities = 92;
        double midterm = 88;
        double final = 93;
        double weightedaverage = (quizzes * 0.1) + (assigntment * 0.1) + (activities * 0.2) + (midterm * 0.1) + (final * 0.3);
        Console.WriteLine($"weighted average: {weightedaverage}");





    }

}