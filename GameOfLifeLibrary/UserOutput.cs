using GameOfLife;
using System;
using System.Reflection.Metadata.Ecma335;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains methods for all the text that appears as user output in console.
    /// </summary>
    public class UserOutput
    {
        /// <summary>
        /// Navigation menu at the start of the game.
        /// </summary>
        private static void ShowMenu()
        {
            var option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    ShowMenuStartANewGameCase();
                    break;
                case "2":
                    Console.WriteLine("Under Construction :)");
                    break;
                case "3":
                    //Console.WriteLine("You can stop application in any moment by pressing \'Esc\' key" + Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// Logic of the navigation's menu Case "1" - start a new game.
        /// </summary>
        private static void ShowMenuStartANewGameCase()
        {
            Console.WriteLine("Please enter the size of field.");
            WidthCheck();
            HeightCheck();
            if (GameOfLifeUI.width > 0 && GameOfLifeUI.height > 0)
            {
                GameOfLifeUI.InitializeRandomBoard();
                GameOfLifeUI.InitializeConsole();

                // Run the game until the Escape key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    RunGame();
                }

                ExitMenuMessage();
                ExitMenu();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        /// <summary>
        /// Shows a navigation menu message at the start of the game.
        /// </summary>
        public static void StartMenuMessage()
        {
            Console.WriteLine("Welcome to the Game Of Life!" + Environment.NewLine);
            //Console.WriteLine("After the game is launched You can save application in any moment by pressing \'Esc\' key." + Environment.NewLine);
            //Console.WriteLine("Would you like to start a new game or restore a previously saved game?" + Environment.NewLine + "Please choose from the options below: ");
            Console.WriteLine("Please choose from the options below: ");
            Console.WriteLine("1. Start a new game");
            Console.WriteLine("2. Load a previously saved game");
            Console.WriteLine("3. Exit");
            Console.WriteLine("You can stop application in any moment by pressing Esc key");
        }

        /// <summary>
        /// Shows a navigation menu message in the end of the game.
        /// </summary>
        public static void ExitMenuMessage()
        {
            Console.Clear();
            Console.WriteLine("1. Exit");
            Console.WriteLine("2. Save and exit");
        }

        /// <summary>
        /// Menu in the end of the game for saving and exiting the game.
        /// </summary>
        public static void ExitMenu()
        {
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Done");
                    break;
                case "2":
                    //SaveGame();
                    //GameOfLifeFileOperator.SaveInformationToFile();
                    Console.WriteLine("Game saved");
                    break;
            }
        }

        /// <summary>
        /// Checks if the user has entered correct input for the width and throws exception if the input is not valid.
        /// </summary>
        public static void WidthCheck()
        {
            Console.Write("Width: ");
            try
            {
                GameOfLifeUI.width = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                FormatExceptionMessage();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow exception, the number was too long for an int32");
            }
        }

        /// <summary>
        /// Checks if the user has entered correct input for the height and throws exception if the input is not valid.
        /// </summary>
        public static void HeightCheck()
        {
            Console.Write("Height: ");
            try
            {
                GameOfLifeUI.height = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                FormatExceptionMessage();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow exception, the number was too long for an int32");
            }
        }

        /// <summary>
        /// Shows a FormatException message for the invalid type of width and height input.
        /// </summary>
        public static void FormatExceptionMessage()
        {
            Console.WriteLine("Format exception, please enter the correct type next time.");
        }

        /// <summary>
        /// Runs the application: shows navigation menu and possibility for the user to select size of field, and shows the outcome in a Console window.
        /// </summary>
        public static void StartApp()
        {
            StartMenuMessage();
            ShowMenu();
        }

        /// <summary>
        /// Shows the game board with the iteration and live cell count.
        /// </summary>
        private static void RunGame()
        {
            GameOfLifeUI.DrawBoard();

            Console.Write($"Iterations: " + GameOfLifeUI.iterationCount.ToString());
            Console.Write($" Cells: " + BusinessLogic.CountAlive());

            BusinessLogic.UpdateBoard();
            //GameOfLifeFileOperator.SaveGrid(GameOfLifeFileOperator.filePath);

            // Wait for a bit between updates.
            Thread.Sleep(GameOfLifeUI.delay);
        }
    }
}
