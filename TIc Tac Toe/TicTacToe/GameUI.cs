using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameUI
    {
        public static void PrintWelcome()
        {
            Console.Write("Welcome to the game of ");
            Console.WriteLine("Tic Tac Toe", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("Mission: ", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.WriteLine("Get your opponent to have a strike!{0}Developed by Tiran and Matan.{0}", Environment.NewLine);
        }

        public static void InitiateBoard(Game i_CurrentGame)
        {
            int boardSize = 0;

            Console.WriteLine("Choose size of board: the size can be between 3 and 9.");
            while (boardSize < 3 || boardSize > 9)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out boardSize);
                if (isNumber)
                {
                    if (boardSize < 3 || boardSize > 9)
                    {
                        Console.WriteLine("Incorrect size!");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }
            }

            i_CurrentGame.GameBoard = new string[boardSize, boardSize];
        }

        public static void InitiateNextPlayer(Player i_Player)
        {
            string userInput = string.Empty;
            Console.WriteLine("Play VS. friend: Press '1'{0}Play VS. AI: press '2'", Environment.NewLine);
            userInput = Console.ReadLine();

            while (userInput != "1" && userInput != "2")
            {
                Console.WriteLine("Incorrect input! Try again");
                userInput = Console.ReadLine();
            }

            if (userInput == "2")
            {
                i_Player.AI = true;
                Console.WriteLine("Difficulty:{0}     Easy:   '1'{0}     Medium: '2'{0}     Hard:   '3'", Environment.NewLine);
                userInput = Console.ReadLine();

                while (userInput != "1" && userInput != "2" && userInput != "3")
                {
                    Console.WriteLine("Incorrect input! Try again");
                    userInput = Console.ReadLine();
                }

                AI.Difficulty = (AI.eDifficulty)Convert.ToInt32(userInput);
            }
        }

        public static string InitiatePlayerName()
        {
            Console.WriteLine("What is your name?");
            string userInput = Console.ReadLine();
            while (userInput.Length < 1)
            {
                Console.WriteLine("Invalid name! Try again");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public static void GameMenu(Game i_CurrentGame)
        {
            string userInput = string.Empty;
            bool isValidInput = true;

            while (userInput != "Q")
            {
                Ex02.ConsoleUtils.Screen.Clear();

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid Input!{0}", Environment.NewLine);
                    isValidInput = true;
                }

                drawBoard(i_CurrentGame);
                printTurn(i_CurrentGame);

                if (i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].AI) // AI's turn
                {
                    isValidInput = AI.ComputeMove(i_CurrentGame);

                    if (!isValidInput)
                    {
                        throw new Exception("Something went wrong with AI");
                    }
                }
                else // Human turn
                {
                    Console.Write("Row: ");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "m":
                        case "M":
                            mainMenu(i_CurrentGame);
                            break;
                        case "q":
                        case "Q":
                            Environment.Exit(0);
                            break;
                        default:
                            isValidInput = inputmove(i_CurrentGame, userInput);
                            break;
                    }
                }

                if (isValidInput)
                {
                    betweenTurns(i_CurrentGame);
                }
            }
        }

        private static void printMenu()
        {
            Console.WriteLine("Press '1' to continue game{0}Press '2' to start a new game{0}Press '3' to show high scores{0}Press 'Q' to quit game{0}", Environment.NewLine);
        }

        private static void printDraw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}The game is a DRAW!", Environment.NewLine);
            Console.ResetColor();
            Console.WriteLine("Press 'Q' to quit or any other key for a new game{0}", Environment.NewLine);
            userChoiseAfterMessage(Console.ReadLine());
        }

        private static void printWinner(Player i_CurrentPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{1}{0} is the WINNER!", i_CurrentPlayer.Name, Environment.NewLine);
            Console.ResetColor();
            Console.WriteLine("Press 'Q' to quit or any other key for a new game{0}", Environment.NewLine);
            userChoiseAfterMessage(Console.ReadLine());
        }

        private static void printHighScores(Game i_CurrentGame)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("{0} wins: {1}{5}{2} wins: {3}{5}Draws: {4}{5}Press any key to continue.{5}",
                i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].Name,
                i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].WinCount,
                i_CurrentGame.Players[i_CurrentGame.NextPlayerTurn].Name,
                i_CurrentGame.Players[i_CurrentGame.NextPlayerTurn].WinCount,
                i_CurrentGame.DrawCount,
                Environment.NewLine);
            Console.ReadLine();
        }

        private static void userChoiseAfterMessage(string i_UserInput)
        {
            switch (i_UserInput)
            {
                case "q":
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void drawBoard(Game i_CurrentGame)
        {
            for (int i = 0; i < i_CurrentGame.BoardSize; i++)
            {
                Console.Write("{0,4:D}", i + 1);
            }

            Console.WriteLine();

            for (int i = 0; i < i_CurrentGame.BoardSize; i++)
            {
                Console.Write("{0}|", i + 1);
                for (int j = 0; j < i_CurrentGame.BoardSize; j++)
                {
                    switch (i_CurrentGame.GameBoard[i, j])
                    {
                        case "X":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("{0,2:D}", i_CurrentGame.GameBoard[i, j]);
                            goto XO;
                        case "O":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("{0,2:D}", i_CurrentGame.GameBoard[i, j]);
                            goto XO;
                        XO:
                            Console.ResetColor();
                            Console.Write(" |");
                            break;
                        default:
                            Console.Write("{0,2:D} |", i_CurrentGame.GameBoard[i, j]);
                            break;
                    }
                }

                Console.Write("{1} {0}{1}", string.Concat(Enumerable.Repeat("=", (i_CurrentGame.BoardSize * 4) + 1)), Environment.NewLine);
            }
        }

        private static void printTurn(Game i_CurrentGame)
        {
            string message = i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].AI ? "is computing its move..." : "make your move!";

            Console.WriteLine("{2}{0} {1}{2}{2}Press 'M' to go to Main Menu or 'Q' to quit{2}",
                i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].Name,
                message,
                Environment.NewLine);
        }

        private static void betweenTurns(Game i_CurrentGame)
        {
            Game.eGameOver result = i_CurrentGame.CheckGameOver();

            if (result == Game.eGameOver.nextTurn)
            {
                i_CurrentGame.TurnManager(); // Setup next move
            }
            else
            {
                Ex02.ConsoleUtils.Screen.Clear();
                drawBoard(i_CurrentGame);

                if (result == Game.eGameOver.win)
                {
                    printWinner(i_CurrentGame.Players[i_CurrentGame.NextPlayerTurn]);
                }
                else
                {
                    printDraw();
                }

                i_CurrentGame.NewGameSetUp();
            }
        }

        private static bool inputmove(Game i_CurrentGame, string i_UserInput)
        {
            int row, col;
            bool isValidInput = false, isRowNumber, isColNumber;

            Console.Write("Col: ");
            isRowNumber = int.TryParse(i_UserInput, out row);
            isColNumber = int.TryParse(Console.ReadLine(), out col);

            if (isRowNumber && isColNumber)
            {
                Move move = new Move(row, col);
                isValidInput = move.InsertMove(i_CurrentGame);
            }

            return isValidInput;
        }

        private static void mainMenu(Game i_CurrentGame)
        {
            string userInput = string.Empty;

            while (userInput != "Q")
            {
                Ex02.ConsoleUtils.Screen.Clear();
                printMenu();
                userInput = Console.ReadLine();

                switch (userInput) // didn't use enum since there is both numbers and letters.
                {
                    case "1":
                        GameMenu(i_CurrentGame);
                        break;
                    case "2":
                        i_CurrentGame.NewGameSetUp();
                        GameMenu(i_CurrentGame);
                        break;
                    case "3":
                        printHighScores(i_CurrentGame);
                        break;
                    case "q":
                    case "Q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input!, try again:{0}", Environment.NewLine);
                        break;
                }
            }
        }
    }
}