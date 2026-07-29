class TicTacToe
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char currentPlayer = 'X';

    static void Main()
    {
        int moves = 0;
        bool gameWon = false;

        while (!gameWon && moves < 9)
        {
            Console.Clear();
            DrawBoard();

            Console.Write($"\nPlayer {currentPlayer}, choose your move (1-9): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > 9)
            {
                Console.WriteLine("Invalid input! Press Enter to try again...");
                Console.ReadLine();
                continue;
            }

            if (!PlaceMove(choice))
            {
                Console.WriteLine("Spot already taken! Press Enter to try again...");
                Console.ReadLine();
                continue;
            }

            moves++;
            gameWon = CheckWin();

            if (!gameWon)
                SwitchPlayer();
        }

        Console.Clear();
        DrawBoard();

        if (gameWon)
            Console.WriteLine($"\n🎉 Player {currentPlayer} WINS!");
        else
            Console.WriteLine("\nIt's a tie!");

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.WriteLine("Tic-Tac-Toe\n");
        Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
    }

    static bool PlaceMove(int choice)
    {
        int row = (choice - 1) / 3;
        int col = (choice - 1) % 3;

        if (board[row, col] == 'X' || board[row, col] == 'O')
            return false;

        board[row, col] = currentPlayer;
        return true;
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool CheckWin()
    {
        // Check rows & columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer &&
                board[i, 1] == currentPlayer &&
                board[i, 2] == currentPlayer)
                return true;

            if (board[0, i] == currentPlayer &&
                board[1, i] == currentPlayer &&
                board[2, i] == currentPlayer)
                return true;
        }

        // Check diagonals
        if (board[0, 0] == currentPlayer &&
            board[1, 1] == currentPlayer &&
            board[2, 2] == currentPlayer)
            return true;

        if (board[0, 2] == currentPlayer &&
            board[1, 1] == currentPlayer &&
            board[2, 0] == currentPlayer)
            return true;

        return false;
    }
}
