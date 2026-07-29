class TicTacToe
{
    static char[] board = Enumerable.Repeat(' ', 9).ToArray();
    static Random rand = new Random();

    static void ShowBoard()
    {
        Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        Console.WriteLine();
    }

    static bool CheckWin(char player)
    {
        int[,] winningPositions = {
            {0,1,2},{3,4,5},{6,7,8}, // rows
            {0,3,6},{1,4,7},{2,5,8}, // columns
            {0,4,8},{2,4,6}          // diagonals
        };

        for (int i = 0; i < winningPositions.GetLength(0); i++)
        {
            if (board[winningPositions[i, 0]] == player &&
                board[winningPositions[i, 1]] == player &&
                board[winningPositions[i, 2]] == player)
            {
                return true;
            }
        }
        return false;
    }

    static bool BoardFull()
    {
        return !board.Contains(' ');
    }

    static void Play()
    {
        ShowBoard();

        while (true)
        {
            // Player move
            int move;
            while (true)
            {
                Console.Write("Enter your move (1-9): ");
                if (int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9)
                {
                    if (board[move - 1] == ' ')
                    {
                        board[move - 1] = 'X';
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That space is already taken.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 9.");
                }
            }

            ShowBoard();

            if (CheckWin('X'))
            {
                Console.WriteLine("You Win!");
                break;
            }
            if (BoardFull())
            {
                Console.WriteLine("It's a tie!");
                break;
            }

            // Computer move
            int[] emptyIndices = board.Select((v, i) => new { v, i })
                                      .Where(x => x.v == ' ')
                                      .Select(x => x.i)
                                      .ToArray();
            int computerMove = emptyIndices[rand.Next(emptyIndices.Length)];
            board[computerMove] = 'O';
            Console.WriteLine("Computer plays:");
            ShowBoard();

            if (CheckWin('O'))
            {
                Console.WriteLine("Computer Wins!");
                break;
            }
            if (BoardFull())
            {
                Console.WriteLine("It's a tie!");
                break;
            }
        }
    }

    static void Main()
    {
        Play();
    }
}
