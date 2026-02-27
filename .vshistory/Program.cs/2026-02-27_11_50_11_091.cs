
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
            
        }

    }

}
