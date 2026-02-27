
namespace TicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            char[,] gameBoard = new char[3,3];

            char currentPlayer = 'X';

            int rounds, xWins, yWins, ties;

            bool playAgain = true;

            do
            {
                PopulateArray(gameBoard);
                DrawScreen(gameBoard, currentPlayer);
                GameLoop();
                //results of game
                //output: playagain? (y/n)


            } while (playAgain = true);

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
            Console.WriteLine("-------------");
            Console.WriteLine($"|{dGameBoard[0, 0]} | {dGameBoard[0, 1]} | {dGameBoard[0, 2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"|{dGameBoard[1, 0]} | {dGameBoard[1, 1]} | {dGameBoard[1, 2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"|{dGameBoard[2, 0]} | {dGameBoard[2, 1]} | {dGameBoard[2, 2]} |");
            Console.WriteLine("-------------");

            Console.WriteLine($"{dCurrentPlayer}, enter a position (1-9):");
        }

        static void GameLoop()
        {

        }
    }

}
