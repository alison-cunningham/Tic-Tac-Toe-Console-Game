
namespace TicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            char[,] gameBoard;

            char currentPlayer = 'X';

            int rounds, xWins, yWins, ties;

            bool playAgain = true;

            do
            {
                PopulateArray();
                DrawScreen();
                GameLoop;
                //results of game
                //output: playagain? (y/n)


            } while (playAgain = true);

            //thanks for playing message
        }

        static void PopulateArray(char[,] dGameBoard)
        {
            byte colCount = 3, rowCount = 3;

            char[] gameSpaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (byte c = 0; c < colCount; c++)
            {
                for (byte r = 0; r < rowCount; r++)
                {

                }
            }
        }

    }

}
