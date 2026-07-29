class Calculator
{
    // Part 1
    static double add(double a, double b)
    {
        return a + b;
    }
    static double subtract(double a, double b)
    {
        return a - b;
    }
    static double Multiply(double a, double b)
    {
        return a * b;
    }
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error cannot be devided!");
            return double.NaN;
        }
        return a / b;
    }
    // part 2
    static int Add(int a, int b)
    {
        return a = b;
    }
    static double Add(double a, double b, double c)
    {
        return a + b + c;
    }
    static int Add(int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }
    // part 3
    static void DisplayResult(double result, string operation)
    {
        Console.WriteLine($"Result of {operation}: {result:F2}");
    }
    // part 4
    static bool TryGetNumber(string prompt, out double number)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        return double.TryParse(input, out number);
    }
    // part 5 main body/program
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nBasic Calculator");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divided");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option");
            string choice = Console.ReadLine();
            if (choice == "5")
            {
                Console.WriteLine("Exiting calculator...");
                running = false;
                continue;
            }
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("Invalid menu choice!");
                continue;
            }
            double num1, num2;
            if (!TryGetNumber("Enter first number:", out num1))
            {
                Console.WriteLine("Invalid Input for the first number!");
                continue;
            }
            if (!TryGetNumber("Enter first number:", out num2))
            {
                Console.WriteLine("Invalid Input for the second number!");
                continue;
            }
            switch (choice)
            {
                case "1":
                    DisplayResult(add(num1, num2), "addition");
                    break;
                case "2":
                    DisplayResult(subtract(num1, num2), "subtraction");
                    break;
                case "3":
                    DisplayResult(Multiply(num1, num2), "Multiplycation");
                    break;
                case "4":
                    double result = Divide(num1, num2);
                    if (!double.IsNaN(result))
                    {
                        DisplayResult(result, "Division");
                    }
                    break;
            }
        }
    }
}
