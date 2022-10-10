using GameOfLife.Library.Interfaces;

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
            Console.WriteLine(Constants.Messages.FormatException);
        }

        /// <summary>
        /// Shows OverFlowException message if the input is too long for an int32.
        /// </summary>
        public static void OverFlowExceptionMessage()
        {
            Console.WriteLine(Constants.Messages.OverflowException);
        }

        /// <summary>
        /// Shows message that informs user to insert the height of the grid.
        /// </summary>
        public static void HeightMessage()
        {
            Console.Write(Constants.Messages.Height);
        }

        /// <summary>
        /// Represents count of iterations and count of live cells. 
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        public static void IterationAndLiveCellInformation(CellBoard cellBoard)
        {
            Console.Write(Constants.Messages.Iterations + cellBoard.iterationCount.ToString() + Environment.NewLine);
            Console.Write(Constants.Messages.LiveCells + cellBoard.aliveCount.ToString() + Environment.NewLine);
        }

        /// <summary>
        /// Shows a navigation menu message at the start of the game.
        /// </summary>
        public static void StartMenuMessage()
        {
            Console.WriteLine(Constants.Messages.Welcome + Environment.NewLine);
            Console.WriteLine(Constants.Messages.SaveInfo + Environment.NewLine);
            Console.WriteLine(Constants.Messages.StartOrRestore + Environment.NewLine + Constants.Messages.ChooseOptions);
            Console.WriteLine(Constants.Messages.StartGame);
            Console.WriteLine(Constants.Messages.LoadGame);
            Console.WriteLine(Constants.Messages.Start1000Games);
            Console.WriteLine(Constants.Messages.Load1000Games);
            Console.WriteLine(Constants.Messages.Exit);
        }

        /// <summary>
        /// Shows message that informs user to insert the width of the grid.
        /// </summary>
        public static void WidthMessage()
        {
            Console.WriteLine(Constants.Messages.EnterSize);
            Console.Write(Constants.Messages.Width);
        }

        /// <summary>
        /// Shows a navigation menu message in the end of the game.
        /// </summary>
        public static void ExitMenuFor1GameMessage()
        {
            Console.WriteLine(Environment.NewLine + Constants.Messages.Exit1);
            Console.WriteLine(Constants.Messages.SaveExit);
        }

        /// <summary>
        /// Shows a navigation menu message in the end after selecting 8 games to be shown on screen.
        /// </summary>
        public static void ExitMenuFor8SelectedGamesMessage()
        {
            Console.WriteLine(Environment.NewLine + Constants.Messages.Exit1);
            Console.WriteLine(Constants.Messages.SaveExit);
            Console.WriteLine(Constants.Messages.ChangeGames);
        }

        /// <summary>
        /// Shows the last message if the user decides to exit the game.
        /// </summary>
        public static void EndMessage()
        {
            Console.WriteLine(Constants.Messages.ComeBack);
        }

        /// <summary>
        /// Informs the user that the game is successfully saved.
        /// </summary>
        public static void GameSavedMessage()
        {
            Console.WriteLine(Constants.Messages.GameSaved);
        }

        /// <summary>
        /// Informs the user that the games are successfully saved.
        /// </summary>
        public static void GamesSavedMessage()
        {
            Console.WriteLine(Constants.Messages.GamesSaved);
        }

        /// <summary>
        /// Informs the user if the input is invalid.
        /// </summary>
        public static void InvalidInputMessage()
        {
            Console.WriteLine(Constants.Messages.InvalidInput);
        }

        /// <summary>
        /// Asks the user to enter the index.
        /// </summary>
        public static void ProvideIndexMessage()
        {
            Console.WriteLine(Environment.NewLine + Constants.Messages.ProvideIndex);
        }

        /// <summary>
        /// Asks the user to enter the index of the first game.
        /// </summary>
        public static void FirstGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index1);
        }

        /// <summary>
        /// Asks the user to enter the index of the second game.
        /// </summary>
        public static void SecondGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index2);
        }

        /// <summary>
        /// Asks the user to enter the index of the third game.
        /// </summary>
        public static void ThirdGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index3);
        }

        /// <summary>
        /// Asks the user to enter the index of the fourth game.
        /// </summary>
        public static void FourthGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index4);
        }

        /// <summary>
        /// Asks the user to enter the index of the fifth game.
        /// </summary>
        public static void FifthGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index5);
        }

        /// <summary>
        /// Asks the user to enter the index of the sixth game.
        /// </summary>
        public static void SixthGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index6);
        }

        /// <summary>
        /// Asks the user to enter the index of the seventh game.
        /// </summary>
        public static void SeventhGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index7);
        }

        /// <summary>
        /// Asks the user to enter the index of the eigth game.
        /// </summary>
        public static void EigthGameIndexMessage()
        {
            Console.Write(Constants.Messages.Index8);
        }

    }
}
