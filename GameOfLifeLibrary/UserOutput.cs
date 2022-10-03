namespace GameOfLife.Library
{
    /// <summary>
    /// Contains methods for all the text that appears as user output in console.
    /// </summary>
    public class UserOutput
    {
        /// <summary>
        /// Shows a FormatException message for the invalid type of width and height input.
        /// </summary>
        public static void FormatExceptionMessage()
        {
            Console.WriteLine("Format exception, please enter the correct type next time.");
        }

        /// <summary>
        /// Shows OverFlowException message if the input is too long for an int32.
        /// </summary>
        public static void OverFlowExceptionMessage()
        {
            Console.WriteLine("Overflow exception, the number was too long for an int32");
        }

        /// <summary>
        /// Shows message that informs user to insert the height of the grid.
        /// </summary>
        public static void HeightMessage()
        {
            Console.Write("Height: ");
        }

        /// <summary>
        /// Represents count of iterations and count of live cells. 
        /// </summary>
        /// <param name="cellBoard" object of the CellBoard.></param>
        public static void IterationAndLiveCellInformation(CellBoard cellBoard)
        {
            Console.Write($"Iterations: " + cellBoard.iterationCount.ToString() + Environment.NewLine);
            Console.Write($"Live cells: " + cellBoard.aliveCount + Environment.NewLine) ;
        }

        /// <summary>
        /// Shows a navigation menu message at the start of the game.
        /// </summary>
        public static void StartMenuMessage()
        {
            Console.WriteLine("Welcome to the Game Of Life!" + Environment.NewLine);
            Console.WriteLine("After the game is launched You can save application in any moment by pressing \'Esc\' key." + Environment.NewLine);
            Console.WriteLine("Would you like to start a new game or restore a previously saved game?" + Environment.NewLine + "Please choose from the options below: ");
            Console.WriteLine("1. Start a new game");
            Console.WriteLine("2. Load a previously saved game");
            Console.WriteLine("3. Exit");
        }

        /// <summary>
        /// Shows message that informs user to insert the width of the grid.
        /// </summary>
        public static void WidthMessage()
        {
            Console.WriteLine("Please enter the size of field.");
            Console.Write("Width: ");
        }

        /// <summary>
        /// Shows a navigation menu message in the end of the game.
        /// </summary>
        public static void ExitMenuMessage()
        {
            //Console.Clear();
            Console.WriteLine("1. Exit");
            Console.WriteLine("2. Save and exit");
        }

        /// <summary>
        /// Shows the last message if the user decides to exit the game.
        /// </summary>
        public static void EndMessage()
        {
            Console.WriteLine("Hope you enjoyed the game. Come back soon!");
        }

        /// <summary>
        /// Informs the user that the game is successfully saved.
        /// </summary>
        public static void GameSavedMessage()
        {
            Console.WriteLine("Game saved");
        }

        /// <summary>
        /// Informs the user if the input is invalid.
        /// </summary>
        public static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input!");
        }
    }
}
