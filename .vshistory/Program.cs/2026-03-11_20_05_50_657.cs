
using System.Diagnostics;
using System.Text;

namespace TicTacToe
{
    /*
     * Programming 2 - Assignment 3 – Winter 2026 
     * Created by:      Alison Cunningham, 1370596
     * Tested by:       TESTER NAME
     * Relationship:    colleague/father/mother/etc
     * Date:            March 11, 2026
     *
     * Description: This program creates a two-player Tic-Tac-Toe game.
     * Players alternate choosing positions on a 3x3 game board until a player wins or the game ends in a tie.
     * The game validates input, tracks game statistics like rounds, wins, and ties, and saves the game results to a text file.
     */

    public class TicTacToe
    {
        static void Main()
        {
            string filePath = "../../../output.txt";                  //relative path of the output file
            string playerInput;                                       //stores user's response to play again prompt

            char[,] gameBoard = new char[3, 3];                      // 3x3 TicTacToe board

            char currentPlayer;                                      // current player symbol (starts with X)
            char outcome;

            ushort rounds = 1, xWins = 0, oWins = 0, ties = 0;      //various game statistics

            bool playAgain = false;                                //controls game replay loop

            StringBuilder sb = new StringBuilder();               //holds screen output
            StringBuilder final = new StringBuilder();            //stores all game results for writing to file

            try
            {
                do
                {
                    currentPlayer = 'X';                //Player X always goes first
                    PopulateArray(gameBoard);           //initializes the game board
                    
                    //runs a single round of TicTacToe
                    outcome = GameLoop(currentPlayer, gameBoard, ref xWins, ref oWins, ref ties, ref rounds, sb);

                    //display result message depending on outcome
                    if (outcome == 'T')                                     
                        sb.AppendLine($"\nTie! Nobody wins.");
                    else                                                    // if not a tie, a player won
                        sb.AppendLine($"\nCongratulations! Player {outcome} wins!");

                    final.Append(sb);           //store the completed round output
                    PrintToScreen(sb);          //display final round screen

                    //ask the user if they want to play another round
                    Console.Write($"\nDo you want to play again? (y/n) ");
                    playerInput = Console.ReadLine();

                    if (playerInput.ToLower() == "y")
                        playAgain = true;
                    else
                        playAgain = false;

                } while (playAgain);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");       //handles unexpected errors
            }

            WriteToFile(final, filePath);           //write all game results to the output file

            Console.Clear();
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
            Process.Start("notepad.exe", filePath);         //open the results file in Notepad
        }

        /* 
         * the PopulateArray method initializes the TicTacToe game board.
         * It receives the 2D array gameBoard and fills it with numbers 1 through 9 representing available board spaces.
         * 
         * Algorithm:
         * The method creates a temporary array containing characters '1' to '9'.
         * It then iterates through each row and column of the game board and assigns the corresponding value from the temporary array. 
         * 
         * PSEUDOCODE:
         * DECLARE colCount = number of columns in gameBoard
         * DECLARE rowCount as number of rows in gameBoard
         * DECLARE gameSpaces as char array
         * ASSIGN gameSpaces as numbers 1 to 9
         *
         * FOR EACH row index FROM 0 to LESS THAN rowCount
		 *  	FOR EACH column index FROM 0 to LESS THAN colCount
		 *		    ASSIGN gameBoard index as gameSpaces index
		 *	    END FOR
		 * END FOR
         */
        static void PopulateArray(char[,] dGameBoard)
        {
            int colCount = 3, rowCount = 3;         //number of rows and columns in gameBoard

            char[] gameSpaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };    //temporary array representing board positions
            int index = 0;          //tracks current position in the gameSpaces array

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    dGameBoard[r, c] = gameSpaces[index];       //assign the next board position number to the current cell
                    index++;        //move to the next value in the gameSpaces array
                }
            }
        }

        /*
         * The DrawScreen method builds the game display inside of a StringBuilder.
         * It includes the title, game board, game statistics, and the input prompt or game results
         * 
         * Algorithm:
         * The method first clears the StringBuilder to remove previous content.
         * It then appends the game title and current game statistics.
         * Next, it adds the TicTacToe board using values stored in the gameBoard array.
         * 
         * Pseudocode:
         * APPEND game title and author
         * APPEND game scores and metrics: Round #, X wins, Y wins, and Ties
         * APPEND top of board: -------------
         * APPEND row 1 of gameBoard, separated by |
         * APPEND |---|---|---|
         * APPEND row 2 of gameBoard, separated by |
         * APPEND |---|---|---|
         * APPEND row 3 of gameBoard, separated by |
         * APPEND bottom of board: ------------
         * APPEND currentPlayer, and prompt for user input 
         */
        static void DrawScreen(char[,] dGameBoard, char dCurrentPlayer, ushort xWins, ushort oWins, ushort ties, ushort rounds, bool dWinner, StringBuilder sb)
        {

            sb.Clear();         //remove previous screen contents

            //append program title and information
            sb.AppendLine("************************************");
            sb.AppendLine("Welcome to Programming 2 - Assignment 3 – Winter 2026");
            sb.AppendLine("Created by Alison Cunningham 1370596 on March 11, 2026");
            sb.AppendLine($"************************************\n");

            //append current game statistics
            sb.AppendLine($"Round #:\t{rounds}");
            sb.AppendLine($"X wins:\t\t{xWins}");
            sb.AppendLine($"O wins:\t\t{oWins}");
            sb.AppendLine($"Ties:\t\t{ties}\n");

            //draw the TicTacToe board using values stored in the array
            sb.AppendLine("-------------");
            sb.AppendLine($"| {dGameBoard[0, 0]} | {dGameBoard[0, 1]} | {dGameBoard[0, 2]} |");
            sb.AppendLine("|---|---|---|");
            sb.AppendLine($"| {dGameBoard[1, 0]} | {dGameBoard[1, 1]} | {dGameBoard[1, 2]} |");
            sb.AppendLine("|---|---|---|");
            sb.AppendLine($"| {dGameBoard[2, 0]} | {dGameBoard[2, 1]} | {dGameBoard[2, 2]} |");
            sb.AppendLine("-------------");

            //display input prompt if the game has not ended
            if (!dWinner)
                sb.Append($"Player {dCurrentPlayer}, enter a position (1-9): ");

        }

        /*
         * PrintToScreen is a method that receives the filled StringBuilder and prints it to screen.
         * First, the screen is cleared to remove old output, then the formatted game screen inside the StringBuilder is printed to the console.
         * 
         * Algorithm:
         * The method clears the console window and then outputs the entire contents of the StringBuilder.
         * 
         * Pseudocode:
         * CLEAR the console screen
         * CONVERT the StringBuilder to a string
         * OUTPUT the string to the console
         */
        static void PrintToScreen(StringBuilder sb)
        {

            Console.Clear();        //clear the screen before printing new output

            Console.WriteLine(sb.ToString());       //convert to string and print out contents
        }
        /*
         * The WriteToFile method writes the contents of a StringBuilder object to a text file.
         * The method opens a file using the provided file path, writes the game results stored in a StringBuilder, and then closes the file.
         * 
         * Algorithm:
         * The method creates a StreamWriter instance to open the file.
         * The contents of the StringBuilder are written to the file.
         * If an error occurs in the writing process, an exception message is displayed.
         * Finally, the file is closed.
         * 
         * Pseudocode:
         * DECLARE StreamWriter instance writer and ASSIGN it null
         * TRY
         *      ASSIGN writer as a new StreamWriter using filePath
         *      CONVERT StringBuilder to a string
         *      WRITE string to file
         * CATCH exception
         *      OUTPUT error message
         * FINALLY
         *      IF writer is not NULL
         *          CLOSE writer
         *      END IF
         * END TRY
         */
        static void WriteToFile(StringBuilder sb, string filePath)
        {
            StreamWriter writer = null;         //StreamWriter used to write to file

            try
            {
                writer = new StreamWriter(filePath);        //open the file for writing using the given path
                writer.Write(sb.ToString());                //convert StringBuilder to string and write contents to the file
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");         //display error message if file writing fails
            }
            finally
            {
                if (writer is not null)         //ensure the writer was successfully created
                    writer.Close();             //close the file
            }
        }

        /* The method GameLoop manages the flow of the game for a single round of TicTacToe.
         * It repeatedly prompts the player for input, updates the board, checks for a win or tie, and switches players.
         * 
         * Algorithm:
         * The method runs a loop where each player takes a turn entering a board position.
         * After each move, the board is updated and the program checks whether the current player has won or if all positions have been filled.
         * If neither condition is met, it switches players and continues the loop.
         * 
         * Pseudocode:
         * DECLARE winner as bool
         * ASSIGN winner as FALSE
         * DECLARE input as char
         * DECLARE turns as 1
         * DECLARE maxTurns as 9
         * 
         * DO WHILE winner is false
         *      CALL DrawScreen to display the current board and game stats\
         *      CALL PrintToScreen to output the screen contents
	     *      CALL GetInput
	     *      CALL UpdateArray
	     * 
	     *      IF turns > 4
		 *          CALL CheckWin
		 *	        IF winner is TRUE
		 *		        CurrentPlayer score + 1
		 *		        BREAK and return currentPlayer
		 *	        END IF
		 *	        ELSE IF turns = maxTurns
		 *		        ASSIGN tie +1
		 *		        BREAK and return currentPlayer
		 *	        END ELSE IF
		 *	    END IF
		 *	    turns + 1
	     *      CALL SwitchPlayer
         * END DO WHILE
         * 
         * RETURN currentPlayer
         */
        static char GameLoop(char currentPlayer, char[,] gameBoard, ref ushort xWins, ref ushort oWins, ref ushort ties, ref ushort rounds, StringBuilder sb)
        {
            bool winner = false;            //tracks if a player has won
            char input;                     //stores the player's chosen board position
            char itsATie = 'T';             //character that is returned to Main() if the round ends in a tie
            byte turns = 1, maxTurns = 9;   //tracks the current turn and the max number of possible turns before the board is full

            do
            {
                //build the screen and output it to console
                DrawScreen(gameBoard, currentPlayer, xWins, oWins, ties, rounds, winner, sb);
                PrintToScreen(sb);

                //get a valid position from the current player and place the symbol on the board
                input = GetInput(gameBoard);  
                UpdateArray(input, gameBoard, currentPlayer);  

                if (turns > 4)          //a win is only possible after 5th turn
                {
                    winner = CheckWin(gameBoard, currentPlayer);        //check if current player has won

                    if (winner)
                    {
                        if (currentPlayer == 'X')
                            xWins++;                //update score for player X if they've won
                        else
                            oWins++;                //update score for player O if they've won

                        //draw final game board, increment round counter, and return the winning player
                        DrawScreen(gameBoard, currentPlayer, xWins, oWins, ties, rounds, winner, sb);
                        rounds++;
                        return currentPlayer;
                    }
                    else if (turns == maxTurns)         //if all positions are filled and there is no winner
                    {
                        //update tie counter, build final game board, increment round counter, and return 'T' for tie
                        ties++;                      
                        DrawScreen(gameBoard, currentPlayer, xWins, oWins, ties, rounds, winner, sb);
                        rounds++;
                        return itsATie;
                    }
                }

                //move to next turn and switch current player
                turns++;           
                SwitchPlayer(ref currentPlayer);

            } while (!winner);

            return currentPlayer;
        }

        /* GetInput is a method that prompts the user to enter a position on the game board.
         * The method validates that the input is a number between 1 and 9, and that the chosen position is still available on the game board.
         * 
         * Algorithm:
         * The method repeatedly asks the user for input until a valid and available position is entered.
         * First, the input is checked to ensure it can be converted to a character between '1' and '9'.
         * Then the board is searched to determine if the space is available.
         * If the input is invalid or the position is already occupied, an error message is displayed and the user is prompted again.
         * 
         * Pseudocode:
         * DECLARE char userPosition
         * DECLARE isValid as a bool and ASSIGN it FALSE
         * DECLARE smallestSpace as '1'
         * DECLARE largestSpace as '9'
         * 
         * DO WHILE isValid is FALSE
	     *   PROMPT user for input
	     *   IF input can be converted to a character AND input is between '1' AND '9'
		 *       FOR each space in gameBoard
		 *          IF space = userPosition
		 *              ASSIGN isValid as TRUE
		 *              BREAK
		 *          END IF
		 *       END FOR
		 *       IF isValid is FALSE
		 *          DISPLAY message that position is taken
		 *       END IF
		 *       ELSE
		 *          DISPLAY error message for invalid input
		 *       END ELSE
	     * END DO WHILE
	     * 
	     * RETURN userPosition
         */
        static char GetInput(char[,] gameBoard)
        {
            char userPosition = '0';            //stores the position entered by the user
            char smallestSpace = '1', largestSpace = '9';       //valid range of board positions
            bool isValid = false;               //tracks whether input is valid and space is available

            do
            {           //check if input is valid and within given range
                if (char.TryParse(Console.ReadLine(), out userPosition) && userPosition >= smallestSpace && userPosition <= largestSpace)
                {
                    foreach (char space in gameBoard)
                    {
                        if (space == userPosition)      //checks if space is taken
                        {
                            isValid = true;             //if available, isValid is true
                            break;
                        }
                    }
                    if (!isValid)           //keep prompting as long as input is invalid or unavailable
                        Console.WriteLine($"That spot is already taken. Please choose another.\n");
                }
                else
                    Console.WriteLine($"Error: please enter a number from 1 - 9.\n");

            } while (!isValid);

            return userPosition;        //return the validated board position
        }

        /* 
         * The UpdateArray method places the player's symbol on the board.
         * It searches the game board for the position matching the user input.
         * It then replaces that position with the current player's symbol.
         * 
         * Algorithm:
         * The method iterates through each cell of the 2D array gameBoard until it finds the matching position entered by the user.
         * 
         * Pseudocode:
         * FOR each row from 0 to LESS THAN rowCount
         *      FOR each column from 0 to LESS THAN colCount
		 *          IF userPosition = gameBoard
		 *	            ASSIGN gameBoard index as currentPlayer
		 *	            BREAK
		 *          END IF
		 *      END FOR
	     * END FOR
         */
        static void UpdateArray(char dInput, char[,] dGameBoard, char dCurrentPlayer)
        {
            int colCount = 3, rowCount = 3;             //number of columns and rows in the game board

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (dGameBoard[r, c] == dInput)             //check if the cell matches the player's input
                    {
                        dGameBoard[r, c] = dCurrentPlayer;      //replace the number with the player symbol
                        break;
                    }

                }

            }

        }

        /* 
         * SwitchPlayer is the method responsible for changing the currentPlayer symbol.
         * If the current player is 'X', it switches to 'O'.
         * If the current player is 'O', it switches to 'X'.
         * 
         * Algorithm:
         * The method checks the current player symbol and assigns it the opposite symbol, before returning the updated value.
         * 
         * Pseudocode:
         * IF currentPlayer is 'X'
		 *      ASSIGN currentPlayer 'O'
	     * ELSE currentPlayer is 'O'
		 *       ASSIGN currentPlayer 'X'
         */
        public static void SwitchPlayer(ref char dCurrentPlayer)
        {

            if (dCurrentPlayer == 'X')      //If current player is X, switch to O
                dCurrentPlayer = 'O';
            else                            //otherwise the player must be O, so switch to X
                dCurrentPlayer = 'X';

        }

        /* 
         * The CheckWin method checks whether the current player has won the game.
         * A player wins when three of their symbols appear in a consecutive row, column, or diagonal on the board.
         * 
         * Algorithm:
         * The method checks every possible winning combination on the board.
         * First it checks each row to see if all three positions contain the current player's symbol.
         * Then it checks each column. Finally, the method checks both diagonals.
         * If any of the conditions are met, the method returns TRUE. Otherwise, it returns FALSE.
         * 
         * Pseudocode:
         * DECLARE int colCount as number of columns in gameBoard
	     * DECLARE int rowCount as number of rows in gameBoard
	     * DECLARE winner as bool	
	     *   
	     * FOR row FROM 0 to LESS THAN rowCount
		 *      ASSIGN winner = TRUE
         *      FOR column FROM 0 to LESS THAN colCount
		 *	        IF gameBoard[row,column] != currentPlayer
		 *		        ASSIGN winner = FALSE
		 *		        BREAK
		 *	        END IF
		 *      END FOR
		 *      IF winner = TRUE
		 *	        RETURN winner
		 *      END IF
	     * END FOR
         *
         * FOR column FROM 0 to LESS THAN colCount
	     *      ASSIGN winner = TRUE
		 *      FOR row FROM 0 to LESS THAN rowCount
		 *	        IF gameBoard[row,column] != currentPlayer
		 *		        ASSIGN winner = FALSE
		 *		        BREAK
		 *	        END IF			
		 *       END FOR
		 *       IF winner = TRUE
		 *	        RETURN winner
		 *       END IF
	     * END FOR
         *
	     * ASSIGN winner = TRUE
         * FOR i FROM 0 to LESS THAN colCount
         *       IF gameBoard[i,i] != currentPlayer
		 *	        ASSIGN winner = FALSE
		 *	        BREAK
		 *       END IF			
         * END FOR
         * IF winner = TRUE
	     *       RETURN winner
         * END IF
         *
	     * ASSIGN winner = TRUE
         * FOR i FROM 0 TO rowCount – 1
         *       IF gameBoard[i, colCount – 1 - i] != currentPlayer
		 *	        ASSIGN winner = FALSE
		 *	        BREAK
		 *       END IF			
         * END FOR
         * 
         * RETURN winner
         */
        public static bool CheckWin(char[,] dGameBoard, char dCurrentPlayer)
        {
            int colCount = 3, rowCount = 3;         //number of columns and rows in the game board
            bool winner = false;                    //tracks whether the current player has won

            //Check for row win
            for (int r = 0; r < rowCount; r++)
            {
                winner = true;              //assume the row is a winning row

                for (int c = 0; c < colCount; c++)
                {
                    if (dGameBoard[r, c] != dCurrentPlayer)
                    {
                        winner = false;     //if a cell does not match the current player symbol, it is not a winning row
                        break;              //don't check the rest of the row
                    }
                }
                if (winner)         //if all cells match the current player, there is a winner
                    return winner;  //don't bother checking other win combinations, just return with true
            }

            //Check for column win
            for (int c = 0; c < colCount; c++)
            {
                winner = true;              //assume the column is a win

                for (int r = 0; r < rowCount; r++)
                {
                    if (dGameBoard[r, c] != dCurrentPlayer)
                    {
                        winner = false;         //if a cell does not match the current player, it is not a winning column
                        break;                  //do not check the rest of the column
                    }
                }
                if (winner)             //if all cells match the current player, there is a win
                    return winner;      //do not check other combinations, just return true
            }

            //Check for diagonal win
            winner = true;          //assume a win

            for (int i = 0; i < colCount; i++)          //loop through the top-left to bottom-right diagonal
            {
                if (dGameBoard[i, i] != dCurrentPlayer)
                {
                    winner = false;     //diagonal is not a win
                    break;              //stop checking
                }
            }
            if (winner)                 //if the loop finishes without being proven false, it's a win
                return winner;          //return true, do not continue

            winner = true;          //assume a win

            for (int i = 0; i < rowCount; i++)          //loop through the opposite diagonal
            {
                if (dGameBoard[i, colCount - 1 - i] != dCurrentPlayer)
                {
                    winner = false;     //if a cell does not match, it is not a win
                    break;              //stop checking
                }
            }

            return winner;          //return final result
        }
    }

}
