
namespace TicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            char[,] gameBoard = new char;

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

            for (byte c = 0; c < colCount; c++)
            {
                for (byte r = 0; r < rowCount; r++)
                {
                    dGameBoard[r, c] = gameSpaces[index];
                    index++;
                }
            }
        }

        static void DrawScreen(char[,] dGameBoard, char dCurrentPlayer)
        {

        }

        static void GameLoop()
        {

        }
    }

}
