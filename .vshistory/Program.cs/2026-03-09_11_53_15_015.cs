
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            string filePath = "output.txt";

            char[,] gameBoard = new char[3, 3];

            char currentPlayer = 'X';
            char outcome;

            int rounds = 1, xWins = 0, yWins = 0, ties = 0;

            bool playAgain = false;

            StringBuilder sb = new StringBuilder();

            do
            {
                PopulateArray(gameBoard);
                outcome = GameLoop(currentPlayer, gameBoard, ref xWins, ref yWins, ref ties, ref rounds, sb);

                if (outcome == 'T')
                    sb.AppendLine($"\nTie! Nobody wins.");
                else
                    sb.AppendLine($"\nCongratulations! Player {outcome} wins!");

                WriteToFile(sb, filePath);
                PrintToScreen(sb);

                Console.Write($"\nDo you want to play again? (y/n) ");

                if (Console.ReadLine() == "y")
                    playAgain = true;
                else
                    playAgain = false;

            } while (playAgain == true);

            Console.Clear();
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
            Process.Start("notepad.exe", filePath);
        }

        static void PopulateArray(char[,] dGameBoard)
        {
            byte colCount = 3, rowCount = 3;

            char[] gameSpaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int index = 0;

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    dGameBoard[r, c] = gameSpaces[index];
                    index++;
                }
            }
        }

        static void DrawScreen(char[,] dGameBoard, char dCurrentPlayer, int xWins, int yWins, int ties, int rounds, bool dWinner, StringBuilder sb)
        {
            sb.Clear();

            sb.AppendLine($"Tic-Tac-Toe - Created by Alison Cunningham\n");

            sb.AppendLine($"Round #:\t{rounds}");
            sb.AppendLine($"X wins:\t\t{xWins}");
            sb.AppendLine($"Y wins:\t\t{yWins}");
            sb.AppendLine($"Ties:\t\t{ties}\n");

            sb.AppendLine("-------------");
            sb.AppendLine($"| {dGameBoard[0, 0]} | {dGameBoard[0, 1]} | {dGameBoard[0, 2]} |");
            sb.AppendLine("|---|---|---|");
            sb.AppendLine($"| {dGameBoard[1, 0]} | {dGameBoard[1, 1]} | {dGameBoard[1, 2]} |");
            sb.AppendLine("|---|---|---|");
            sb.AppendLine($"| {dGameBoard[2, 0]} | {dGameBoard[2, 1]} | {dGameBoard[2, 2]} |");
            sb.AppendLine("-------------");

            if(!dWinner)
            sb.Append($"Player {dCurrentPlayer}, enter a position (1-9): ");
        }

        static void PrintToScreen(StringBuilder sb)
        {
            Console.Clear();

            Console.WriteLine(sb.ToString());
        }

        static void WriteToFile(StringBuilder sb, string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath, true);

            try
            {
                writer.Write(sb.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
            finally
            {
                writer.Close();
            }
        }

        static char GameLoop(char currentPlayer, char[,] gameBoard, ref int xWins, ref int yWins, ref int ties, ref int rounds, StringBuilder sb)
        {
            bool winner = false;
            char input;
            char itsATie = 'T';
            byte turns = 1, maxTurns = 9;

            do
            {
                DrawScreen(gameBoard, currentPlayer, xWins, yWins, ties, rounds, winner, sb);
                PrintToScreen(sb);

                input = GetInput(gameBoard);
                UpdateArray(input, gameBoard, currentPlayer);


                if (turns > 4)
                {
                    winner = CheckWin(gameBoard, currentPlayer);

                    if (winner == true)
                    {
                        if (currentPlayer == 'X')
                            xWins++;
                        else
                            yWins++;
                        DrawScreen(gameBoard, currentPlayer, xWins, yWins, ties, rounds, winner, sb);
                        return currentPlayer;
                    }
                    else if (turns == maxTurns)
                    {
                        ties++;
                        DrawScreen(gameBoard, currentPlayer, xWins, yWins, ties, rounds, winner, sb);
                        return itsATie;
                    }
                }

                turns++;
                currentPlayer = SwitchPlayer(currentPlayer);

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
