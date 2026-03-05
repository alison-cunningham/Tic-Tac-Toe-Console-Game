
namespace TicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            char[,] gameBoard = new char[3, 3];

            char currentPlayer = 'X';

            int rounds = 0, xWins = 0, yWins = 0, ties = 0;

            bool playAgain = true;

            do
            {
                PopulateArray(gameBoard);
                DrawScreen(gameBoard, currentPlayer);
                GameLoop(currentPlayer, gameBoard, xWins, yWins, ties, rounds);
                //results of game
                //output: playagain? (y/n)


            } while (playAgain == true);

            //thanks for playing message
        }

        static void PopulateArray(char[,] dGameBoard)
        {
            byte colCount = 3, rowCount = 3;

            char[] gameSpaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            byte index = 0;

            for (int c = 0; c < colCount; c++)
            {
                for (int r = 0; r < rowCount; r++)
                {
                    dGameBoard[r, c] = gameSpaces[index];
                    index++;
                }
            }
        }

        static void DrawScreen(char[,] dGameBoard, char dCurrentPlayer)
        {
            Console.Clear();

            Console.WriteLine("-------------");
            Console.WriteLine($"| {dGameBoard[0, 0]} | {dGameBoard[0, 1]} | {dGameBoard[0, 2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {dGameBoard[1, 0]} | {dGameBoard[1, 1]} | {dGameBoard[1, 2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {dGameBoard[2, 0]} | {dGameBoard[2, 1]} | {dGameBoard[2, 2]} |");
            Console.WriteLine("-------------");

            Console.Write($"\nPlayer {dCurrentPlayer}, enter a position (1-9): ");
        }

        static void GameLoop(char currentPlayer, char[,] gameBoard, int xWins, int yWins, int ties, int rounds)
        {
            bool winner = false;
            char input;

            do
            {
                input = GetInput(gameBoard);
                UpdateArray(input, gameBoard, currentPlayer);
                DrawScreen(gameBoard, currentPlayer);

                if (rounds > 4)
                {
                    winner = CheckWin(gameBoard, currentPlayer);

                    if (winner == true)
                    {
                        if (currentPlayer == 'X')
                        {
                            xWins++;
                        }
                        else
                        {
                            yWins++;
                        }
                    }
                    else if (rounds == 9)
                    {
                        ties++;
                    }
                }

                currentPlayer = SwitchPlayer(currentPlayer);

            } while (winner == false);

        }

        static char GetInput(char[,] gameBoard)
        {
            char userPosition;
            bool isValid = false;

            do
            {

                if (byte.TryParse(Console.ReadLine(), out userPosition) && userPosition < 10)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"\nError: please input a number form 1 - 9");
                }         

                foreach (char space in gameBoard)
                {
                    if (space == userPosition)
                    {
                        isValid = true;
                        break;
                    }

                }

            } while (isValid == false);

            return userPosition;
        }

        static void UpdateArray(byte dInput, char[,] dGameBoard, char dCurrentPlayer)
        {
            byte colCount = 3, rowCount = 3;

            for (int c = 0; c < colCount; c++)
            {
                for (int r = 0; r < rowCount; r++)
                {
                    if (dGameBoard[r, c] == dInput)
                    {
                        dGameBoard[r, c] = dCurrentPlayer;
                        break;
                    }

                }

            }
        }

        public static char SwitchPlayer(char dCurrentPlayer)
        {
            if (dCurrentPlayer == 'X')
                dCurrentPlayer = 'O';
            else
                dCurrentPlayer = 'X';


            return dCurrentPlayer;
        }

        public static bool CheckWin(char[,] dGameBoard, char dCurrentPlayer)
        {

            return false;
        }
    }

}
