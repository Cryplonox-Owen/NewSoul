class Program
{
    static void Main()
    {
        int choice;

        Console.WriteLine("=== MENU ===");
        Console.WriteLine("[1] Vowel Frequency Counter");
        Console.WriteLine("[2] Palindrome Checker");
        Console.Write("Enter your choice: ");

        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.WriteLine();

        switch (choice)
        {
            case 1:
                CountVowels();
                break;

            case 2:
                CheckPalindrome();
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // ==========================
    // 1. VOWEL FREQUENCY METHOD
    // ==========================
    static void CountVowels()
    {
        Console.Write("Enter a word/phrase/sentence: ");
        string input = Console.ReadLine().ToLower();

        int a = 0, e = 0, i = 0, o = 0, u = 0;

        foreach (char c in input)
        {
            if (c == 'a') a++;
            else if (c == 'e') e++;
            else if (c == 'i') i++;
            else if (c == 'o') o++;
            else if (c == 'u') u++;
        }

        Console.WriteLine("\nVowel Frequency:");
        Console.WriteLine($"A = {a}");
        Console.WriteLine($"E = {e}");
        Console.WriteLine($"I = {i}");
        Console.WriteLine($"O = {o}");
        Console.WriteLine($"U = {u}");
    }
    //==========================
    // 2. PALINDROME CHECKER
    // ==========================
    static void CheckPalindrome()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine().ToLower().Replace(" ", "");

        string reversed = "";

        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed += word[i];
        }

        if (word == reversed)
            Console.WriteLine("The word is a palindrome.");
        else
            Console.WriteLine("The word is NOT a palindrome.");
    }
}











