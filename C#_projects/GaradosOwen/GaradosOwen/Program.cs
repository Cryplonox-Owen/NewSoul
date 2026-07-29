class Program
{
    static void Main()
    {
        // Ask the user for input
        Console.Write("Enter a word/phrase/sentence: ");
        string input = Console.ReadLine();

        // Convert to lowercase
        string lowerInput = input.ToLower();

        // Vowel counters
        int aCount = 0, eCount = 0, iCount = 0, oCount = 0, uCount = 0;

        // Count vowels using FOR loop
        for (int i = 0; i < lowerInput.Length; i++)
        {
            char c = lowerInput[i];

            if (c == 'a') aCount++;
            else if (c == 'e') eCount++;
            else if (c == 'i') iCount++;
            else if (c == 'o') oCount++;
            else if (c == 'u') uCount++;
        }

        // LANDSCAPE vowel output
        Console.WriteLine("\nVOWEL FREQUENCY (LANDSCAPE):");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("A\tE\tI\tO\tU");
        Console.WriteLine($"{aCount}\t{eCount}\t{iCount}\t{oCount}\t{uCount}");
        Console.WriteLine("--------------------------------------------");

        // Clean string for palindrome check
        string clean = "";
        for (int i = 0; i < lowerInput.Length; i++)
        {
            if (Char.IsLetterOrDigit(lowerInput[i]))
            {
                clean += lowerInput[i];
            }
        }

        // Reverse using FOR loop
        string reverse = "";
        for (int i = clean.Length - 1; i >= 0; i--)
        {
            reverse += clean[i];
        }

        // FINAL PALINDROME OUTPUT (No extra text)
        Console.WriteLine(clean == reverse ? "Palindrome" : "Not Palindrome");
    }
}