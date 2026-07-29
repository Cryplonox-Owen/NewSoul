using System;

class NumberSystemConverter
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== UNIVERSAL NUMBER SYSTEM CONVERTER ===");
            Console.WriteLine("1. Decimal");
            Console.WriteLine("2. Binary");
            Console.WriteLine("3. Octal");
            Console.WriteLine("4. Hexadecimal");
            Console.WriteLine("5. Mix Mode (Auto Detect)");
            Console.WriteLine("6. Exit");
            Console.Write("Choose your source number system (1–6): ");

            string? sourceChoice = Console.ReadLine();
            if (sourceChoice == "6")
            {
                Console.WriteLine("Goodbye! 👋");
                return;
            }

            if (sourceChoice == "5")
            {
                MixMode();
                continue;
            }

            Console.WriteLine("\nConvert to:");
            Console.WriteLine("1. Decimal");
            Console.WriteLine("2. Binary");
            Console.WriteLine("3. Octal");
            Console.WriteLine("4. Hexadecimal");
            Console.Write("Choose your target system (1–4): ");
            string? targetChoice = Console.ReadLine();

            Console.Write("\nEnter your number: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("❌ Invalid input!");
                continue;
            }

            try
            {
                int decimalValue = ConvertToDecimal(input, sourceChoice);
                string result = ConvertFromDecimal(decimalValue, targetChoice);
                Console.WriteLine($"\n✅ Result: {result}");
            }
            catch
            {
                Console.WriteLine("❌ Conversion failed! Check your input format.");
            }
        }
    }

    static int ConvertToDecimal(string input, string? sourceChoice)
    {
        return sourceChoice switch
        {
            "1" => int.Parse(input),                   // Decimal
            "2" => Convert.ToInt32(input, 2),          // Binary
            "3" => Convert.ToInt32(input, 😎,          // Octal
            "4" => Convert.ToInt32(input, 16),         // Hexadecimal
            _ => throw new Exception("Invalid source system!")
        };
    }

    static string ConvertFromDecimal(int decimalValue, string? targetChoice)
    {
        return targetChoice switch
        {
            "1" => decimalValue.ToString(),                 // Decimal
            "2" => Convert.ToString(decimalValue, 2),       // Binary
            "3" => Convert.ToString(decimalValue, 😎,       // Octal
            "4" => Convert.ToString(decimalValue, 16).ToUpper(), // Hexadecimal
            _ => throw new Exception("Invalid target system!")
        };
    }

    static void MixMode()
    {
        Console.Write("\nEnter any number (supports 0b for binary, 0x for hex, 0 for octal): ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Invalid input!");
            return;
        }

        try
        {
            int decValue;
            if (input.StartsWith("0b", StringComparison.OrdinalIgnoreCase))
                decValue = Convert.ToInt32(input.Substring(2), 2);
            else if (input.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                decValue = Convert.ToInt32(input.Substring(2), 16);
            else if (input.StartsWith("0") && input.Length > 1)
                decValue = Convert.ToInt32(input, 8);
            else if (IsBinary(input))
                decValue = Convert.ToInt32(input, 2);
            else
                decValue = int.Parse(input);

            Console.WriteLine($"\nDetected Decimal: {decValue}");
            Console.WriteLine($"Binary: {Convert.ToString(decValue, 2)}");
            Console.WriteLine($"Octal: {Convert.ToString(decValue, 8)}");
            Console.WriteLine($"Hexadecimal: {Convert.ToString(decValue, 16).ToUpper()}");
        }
        catch
        {
            Console.WriteLine("❌ Invalid format! Unable to detect number system.");
        }
    }

    static bool IsBinary(string s)
    {
        foreach (char c in s)
        {
            if (c != '0' && c != '1')
                return false;
        }
        return true;
    }
}
