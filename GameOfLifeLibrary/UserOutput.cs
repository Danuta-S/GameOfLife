using GameOfLife;
using System.Reflection.Metadata.Ecma335;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains methods for all the text that appears as user output in console.
    /// </summary>
    public class UserOutput
    {
        /// <summary>
        /// Shows a Welcome message and information how to stop the game.
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Game Of Life!" + Environment.NewLine);
            Console.WriteLine("(You can stop application in any moment by pressing S key)" + Environment.NewLine);
            Console.WriteLine("Please enter the size of field.");
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
                Console.WriteLine("Format exception, please enter the correct type next time.");
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
                Console.WriteLine("Format exception, please enter the correct type next time.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow exception, the number was too long for an int32");
            }
        }

        /// <summary>
        /// Shows navigation menu and possibility for the user to select size of field, and shows the outcome in a Console window.
        /// </summary>
        public static void StartApp()
        {
            WelcomeMessage();
            WidthCheck();
            HeightCheck();

            if (GameOfLifeUI.width > 0 && GameOfLifeUI.height > 0)
            {
                GameOfLifeUI.InitializeRandomBoard();
                GameOfLifeUI.InitializeConsole();

                // Run the game until the S key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.S)
                {
                    GameOfLifeUI.DrawBoard();
                    BusinessLogic.UpdateBoard();

                    // Wait for a bit between updates.
                    Thread.Sleep(GameOfLifeUI.delay);
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
