using System;

class NumberSystemConverter
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== UNIVERSAL NUMBER SYSTEM CONVERTER ===");
            Console.WriteLine("1. Decimal to Binary, Octal, Hexadecimal");
            Console.WriteLine("2. Binary to Decimal, Octal, Hexadecimal");
            Console.WriteLine("3. Octal to Decimal, Binary, Hexadecimal");
            Console.WriteLine("4. Hexadecimal to Decimal, Binary, Octal");
            Console.WriteLine("5. Mix Mode (Auto Detect and Convert)");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1–6): ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    DecimalConvert();
                    break;
                case "2":
                    BinaryConvert();
                    break;
                case "3":
                    OctalConvert();
                    break;
                case "4":
                    HexConvert();
                    break;
                case "5":
                    MixMode();
                    break;
                case "6":
                    Console.WriteLine("Goodbye! 👋");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please choose 1–6.");
                    break;
            }
        }
    }

    static void DecimalConvert()
    {
        Console.Write("Enter a Decimal number: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int dec))
        {
            Console.WriteLine($"Binary: {Convert.ToString(dec, 2)}");
            Console.WriteLine($"Octal: {Convert.ToString(dec, 8)}");
            Console.WriteLine($"Hexadecimal: {Convert.ToString(dec, 16).ToUpper()}");
        }
        else
        {
            Console.WriteLine("Invalid Decimal input!");
        }
    }

    static void BinaryConvert()
    {
        Console.Write("Enter a Binary number: ");
        string? binary = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(binary))
        {
            Console.WriteLine("Invalid Binary input!");
            return;
        }

        try
        {
            int dec = Convert.ToInt32(binary, 2);
            Console.WriteLine($"Decimal: {dec}");
            Console.WriteLine($"Octal: {Convert.ToString(dec, 8)}");
            Console.WriteLine($"Hexadecimal: {Convert.ToString(dec, 16).ToUpper()}");
        }
        catch
        {
            Console.WriteLine("Invalid Binary input!");
        }
    }

    static void OctalConvert()
    {
        Console.Write("Enter an Octal number: ");
        string? oct = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(oct))
        {
            Console.WriteLine("Invalid Octal input!");
            return;
        }

        try
        {
            int dec = Convert.ToInt32(oct, 8);
            Console.WriteLine($"Decimal: {dec}");
            Console.WriteLine($"Binary: {Convert.ToString(dec, 2)}");
            Console.WriteLine($"Hexadecimal: {Convert.ToString(dec, 16).ToUpper()}");
        }
        catch
        {
            Console.WriteLine("Invalid Octal input!");
        }
    }

    static void HexConvert()
    {
        Console.Write("Enter a Hexadecimal number: ");
        string? hex = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(hex))
        {
            Console.WriteLine("Invalid Hexadecimal input!");
            return;
        }

        try
        {
            int dec = Convert.ToInt32(hex, 16);
            Console.WriteLine($"Decimal: {dec}");
            Console.WriteLine($"Binary: {Convert.ToString(dec, 2)}");
            Console.WriteLine($"Octal: {Convert.ToString(dec, 8)}");
        }
        catch
        {
            Console.WriteLine("Invalid Hexadecimal input!");
        }
    }

    static void MixMode()
    {
        Console.WriteLine("Enter any number (Decimal, Binary, Octal, or Hexadecimal): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Invalid input! Input cannot be empty.");
            return;
        }

        try
        {
            int decValue;

            // Auto-detect number type
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
            Console.WriteLine("❌ Invalid input! Could not detect number system.");
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