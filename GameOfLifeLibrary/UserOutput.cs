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
        /// <param name="cellBoard">object of the CellBoard.</param>
        public static void IterationAndLiveCellInformation(CellBoard cellBoard)
        {
            Console.Write($"Iterations: " + cellBoard.iterationCount.ToString() + Environment.NewLine);
            Console.Write($"Live cells: " + cellBoard.aliveCount.ToString() + Environment.NewLine);
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
            Console.WriteLine("3. Start 1000 games and select 8 games to show on screen");
            Console.WriteLine("4. Load 1000 previously saved games and select 8 games to show on screen");
            Console.WriteLine("5. Exit");
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
        public static void ExitMenuFor1GameMessage()
        {
            Console.WriteLine(Environment.NewLine + "1. Exit");
            Console.WriteLine("2. Save and exit");
        }

        /// <summary>
        /// Shows a navigation menu message in the end after selecting 8 games to be shown on screen.
        /// </summary>
        public static void ExitMenuFor8SelectedGamesMessage()
        {
            Console.WriteLine(Environment.NewLine + "1. Exit");
            Console.WriteLine("2. Save and exit");
            Console.WriteLine("3. Change what exact games will be iterating on screen");
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
        /// Informs the user that the games are successfully saved.
        /// </summary>
        public static void GamesSavedMessage()
        {
            Console.WriteLine("Games are saved");
        }

        /// <summary>
        /// Informs the user if the input is invalid.
        /// </summary>
        public static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input!");
        }

        /// <summary>
        /// Asks the user to enter the index.
        /// </summary>
        public static void ProvideIndexMessage()
        {
            Console.WriteLine(Environment.NewLine + "Please provide index (from 0 to 999) of 8 games that you would like to see on screen.");
        }

        /// <summary>
        /// Asks the user to enter the index of the first game.
        /// </summary>
        public static void FirstGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 1: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the second game.
        /// </summary>
        public static void SecondGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 2: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the third game.
        /// </summary>
        public static void ThirdGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 3: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the fourth game.
        /// </summary>
        public static void FourthGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 4: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the fifth game.
        /// </summary>
        public static void FifthGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 5: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the sixth game.
        /// </summary>
        public static void SixthGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 6: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the seventh game.
        /// </summary>
        public static void SeventhGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 7: ");
        }

        /// <summary>
        /// Asks the user to enter the index of the eigth game.
        /// </summary>
        public static void EigthGameIndexMessage()
        {
            Console.Write("Please enter index of the game Nr. 8: ");
        }
    }
}
