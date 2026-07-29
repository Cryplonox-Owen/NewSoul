class lottery
    static void Main(string[] args)
{
    RunMenu();
}
static void RunMenu();
{
    int choices = 0;
    do
    {
        Console.WriteLine("Welcome to 6/49 lottery Draw";
        Console.WriteLine("[1]");
        Console.WriteLine("[2]");
        Console.Write("Please input your choice:");
        if (!int.TryParse(Console.ReadLine(), out choices)) || (choices != 1 && choices != 2)){
            Console.WriteLine("Invalid choices! Please try again. \n");
            continue;
        }
        if (choices == 1)
        {
            StartDraw();
        }
    } while (choices != 2);
    Console.WriteLine("Thank you for using 6/49 Lottery Draw Application!");
}
static void StartDraw()
{
    List<int> userNumbers = GetUserNumbers();
    List<int> winningNumbers = GenerateWinningNumbers();

    Console.WriteLine("\nWiining NUmbers:" + string.Join("", winningNumbers));
    int matchCount = CountMatches(userNumbers, winningNumbers);
    DisplayResult(matchCount, userNumbers, winningNumbers);
    Console.WriteLine();
}
static int[] check_user_input()


{
    while (true)
    {
        Console.WriteLine("Enter 6 numbers seperated by comma):");
        string input = Console.ReadLine();
        string[] user_numbers_strings = input.Split(',');

        if (user_numbers_strings.Length != 0)
        {
            Console.Write("Invalid input! You must enter excatly 6 numbers.");
            continue;
        }
        int[] user_number_int = new int[6];
        bool valid = true;

        for (int i = 0; i < 6; i++)
        {
            try
            {
                user_number_int[i] = Convert.ToInt32(user_numbers_strings[i]);
            }
            catch
            {
                valid = false;
                break;
            }
        }
        if (!valid)
        {
            Console.WriteLine("Invalid Input! All values must be numbers");
        }
    }
}

