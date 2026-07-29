using System;  // Imports basic system functionalities (e.g., input/output)

namespace Owens
{
    class NumberSystemConverter
    {
        // Main entry point of the program
        static void Main()
        {
            // Start an infinite loop to allow multiple conversions until user chooses to exit
            while (true)
            {
                // Display welcome message and prompt for number input
                Console.WriteLine("\nWelcome to the Number System Converter!");
                Console.Write("Please enter a number to convert (or type 'exit' to quit): ");
                string input = Console.ReadLine() ?? string.Empty;  // Read user input and ensure it's not null

                // Exit condition
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                // Input validation – empty input check
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("\nError: Input cannot be empty.");
                    continue; // Return to the top of the loop
                }

                // Ask user for the current base of the input number
                Console.WriteLine("\nWhat is the current base of this number?");
                Console.WriteLine("(1) Binary");
                Console.WriteLine("(2) Decimal");
                Console.WriteLine("(3) Octal");
                Console.WriteLine("(4) Hexadecimal");
                Console.Write("Enter your choice (1–4): ");
                string baseChoice = Console.ReadLine() ?? string.Empty;

                // Ask user for the target base to convert to
                Console.WriteLine("\nWhat base would you like to convert to?");
                Console.WriteLine("(1) Decimal");
                Console.WriteLine("(2) Octal");
                Console.WriteLine("(3) Hexadecimal");
                Console.Write("Enter your choice (1–3): ");
                string convertChoice = Console.ReadLine() ?? string.Empty;

                try
                {
                    int decimalValue;  // Holds the value of input converted to decimal

                    // Handle input conversion based on the original base
                    switch (baseChoice)
                    {
                        case "1": // Binary to Decimal
                            if (!IsValidBinary(input))
                                throw new FormatException("Binary numbers may only contain 0 and 1.");
                            decimalValue = Convert.ToInt32(input, 2); // Convert binary to decimal
                            break;

                        case "2": // Decimal
                            if (!int.TryParse(input, out decimalValue)) // Try parsing to int
                                throw new FormatException("Invalid decimal number.");
                            break;

                        case "3": // Octal
                            if (!IsValidOctal(input))
                                throw new FormatException("Octal numbers may only contain digits 0–7.");
                            decimalValue = Convert.ToInt32(input, 8); // Convert octal to decimal
                            break;

                        case "4": // Hexadecimal
                            if (!IsValidHex(input))
                                throw new FormatException("Hexadecimal numbers may only contain digits 0–9 and letters A–F.");
                            decimalValue = Convert.ToInt32(input, 16); // Convert hex to decimal
                            break;

                        default:
                            throw new ArgumentException("Invalid base selection."); // Handle invalid input
                    }

                    // Convert the decimal value into the selected target base
                    string result = convertChoice switch
                    {
                        "1" => decimalValue.ToString(),                         // Decimal output
                        "2" => Convert.ToString(decimalValue, 8),              // Octal output
                        "3" => Convert.ToString(decimalValue, 16).ToUpper(),   // Hex output (uppercase)
                        _ => throw new ArgumentException("Invalid conversion selection.") // Error for invalid target base
                    };

                    // Get readable base names for display
                    string fromBase = GetBaseName(baseChoice, false);  // Original base name
                    string toBase = GetBaseName(convertChoice, true);  // Target base name

                    // Show the result
                    Console.WriteLine($"\nThe {fromBase} number {input} is equal to the {toBase} number {result}.");
                }
                catch (FormatException ex)  // Handles wrong formats in user input (e.g., letters in binary)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (ArgumentException ex)  // Handles wrong base selections
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (Exception)  // General fallback for unexpected errors
                {
                    Console.WriteLine("\nError: Unexpected input or conversion problem occurred.");
                }

                // Ask user if they want to perform another conversion
                Console.WriteLine("\nWould you like to perform another conversion? (y/n): ");
                string again = Console.ReadLine() ?? string.Empty;
                if (!again.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Program terminated.");
                    break;  // Exit loop
                }
            }
        }

        // Helper method to get base names based on choice number (for display)
        static string GetBaseName(string choice, bool outputBase)
        {
            return outputBase
                ? choice switch
                {
                    "1" => "decimal",
                    "2" => "octal",
                    "3" => "hexadecimal",
                    _ => "unknown"
                }
                : choice switch
                {
                    "1" => "binary",
                    "2" => "decimal",
                    "3" => "octal",
                    "4" => "hexadecimal",
                    _ => "unknown"
                };
        }

        // Validates if the input string contains only binary digits (0 and 1)
        static bool IsValidBinary(string input)
        {
            foreach (char c in input)
                if (c != '0' && c != '1') return false;
            return true;
        }

        // Validates if the input string contains only octal digits (0 to 7)
        static bool IsValidOctal(string input)
        {
            foreach (char c in input)
                if (c < '0' || c > '7') return false;
            return true;
        }

        // Validates if the input string is a valid hexadecimal (0-9, A-F, a-f)
        static bool IsValidHex(string input)
        {
            foreach (char c in input)
            {
                if (!Uri.IsHexDigit(c))  // Built-in method to check if character is hex digit
                    return false;
            }
            return true;
        }
    }
}

