
namespace TicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            char[,] gameBoard = new char[3, 3];

            char currentPlayer = 'X';
            char outcome;

            int rounds = 1, xWins = 0, yWins = 0, ties = 0;

            bool playAgain = false;

            do
            {
                PopulateArray(gameBoard);
                DrawScreen(gameBoard, currentPlayer, xWins, yWins, ties, rounds);
                outcome = GameLoop(currentPlayer, gameBoard, ref xWins, ref yWins, ref ties, ref rounds);

                if (outcome == 'T')
                    Console.WriteLine($"\nTie! Nobody wins.");
                else
                    Console.WriteLine($"\nCongratulations! Player {outcome} wins!");

                Console.WriteLine($"\nDo you want to play again? (y/n)\t");

                if(Console.ReadLine() == "y")
                    playAgain = true;

            } while (playAgain == true);

            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }

        static void PopulateArray(char[,] dGameBoard)
        {
            byte colCount = 3, rowCount = 3;

            char[] gameSpaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            byte index = 0;

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    dGameBoard[r, c] = gameSpaces[index];
                    index++;
                }
            }
        }

        static void DrawScreen(char[,] dGameBoard, char dCurrentPlayer, int xWins, int yWins, int ties, int rounds)
        {
            Console.Clear();

            Console.WriteLine($"Tic-Tac-Toe - Created by Alison Cunningham\n");

            Console.WriteLine($"Round #:\t{rounds}");
            Console.WriteLine($"X wins:\t\t{xWins}");
            Console.WriteLine($"Y wins:\t\t{yWins}");
            Console.WriteLine($"Ties:\t\t{ties}\n");

            Console.WriteLine("-------------");
            Console.WriteLine($"| {dGameBoard[0, 0]} | {dGameBoard[0, 1]} | {dGameBoard[0, 2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {dGameBoard[1, 0]} | {dGameBoard[1, 1]} | {dGameBoard[1, 2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {dGameBoard[2, 0]} | {dGameBoard[2, 1]} | {dGameBoard[2, 2]} |");
            Console.WriteLine("-------------");

            Console.Write($"\nPlayer {dCurrentPlayer}, enter a position (1-9): ");
        }

        static char GameLoop(char currentPlayer, char[,] gameBoard, ref int xWins, ref int yWins, ref int ties, ref int rounds)
        {
            bool winner = false;
            char input;
            byte turns = 1;

            do
            {
                input = GetInput(gameBoard);
                UpdateArray(input, gameBoard, currentPlayer);
                DrawScreen(gameBoard, currentPlayer, xWins, yWins, ties, rounds);

                if (turns > 4)
                {
                    winner = CheckWin(gameBoard, currentPlayer);

                    if (winner == true)
                    {
                        if (currentPlayer == 'X')
                            xWins++;
                        else
                            yWins++;
                        return currentPlayer;
                    }
                    else if (turns == 9)
                    {
                        ties++;
                        return 'T';
                    }
                }

                turns++;
                currentPlayer = SwitchPlayer(currentPlayer);
                DrawScreen(gameBoard, currentPlayer, xWins, yWins, ties, rounds);

            } while (winner == false);

            rounds++;
            return currentPlayer;
        }

        static char GetInput(char[,] gameBoard)
        {
            char userPosition;
            bool isValid = false;

            do
            {
                if (char.TryParse(Console.ReadLine(), out userPosition) && userPosition > '0' && userPosition <= '9')
                {
                    foreach (char space in gameBoard)
                    {
                        if (space == userPosition)
                        {
                            isValid = true;
                            break;
                        }
                    }
                    if (!isValid)
                        Console.WriteLine($"That spot is already taken. Please choose another.\n");
                }
                else
                    Console.WriteLine($"Error: please enter a number from 1 - 9.\n");

            } while (!isValid);

            return userPosition;
        }

        static void UpdateArray(char dInput, char[,] dGameBoard, char dCurrentPlayer)
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
            int colCount = 3, rowCount = 3;
            bool winner = false;

            //Check for row win

            for(int r = 0; r < rowCount; r++)
            {
                winner = true;

                for(int c = 0; c < colCount; c++)
                {
                    if(dGameBoard[r, c] != dCurrentPlayer)
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner == true)
                    return winner;
            }

            //Check for column win

            for(int c = 0; c < colCount; c++)
            {
                winner = true;

                for(int r = 0; r < rowCount; r++)
                {
                    if (dGameBoard[r, c] != dCurrentPlayer)
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner == true)
                    return winner;
            }

            //Check for diagonal win

            winner = true;

            for(int i = 0; i < colCount; i++)
            {
                if (dGameBoard[i,i] != dCurrentPlayer)
                {
                    winner = false;
                    break;
                }
            }
            if (winner == true)
                return winner;

            winner = true;

            for(int i = 0; i < rowCount; i++)
            {
                if (dGameBoard[i,colCount-1-i] != dCurrentPlayer)
                {
                    winner = false;
                    break;
                }
            }

            return winner;
        }
    }

}
