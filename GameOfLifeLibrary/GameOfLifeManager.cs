using GameOfLife;
using GameOfLife.Library;
using System.Text;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains the methods that are responsible for launching the game.
    /// </summary>
    public class GameOfLifeManager
    {
        private static readonly GameOfLifeLogic Logic = new();
        private static readonly GameOfLifeFileOperator FileOperator = new();
        private static readonly GameOfLifeManager Manager = new();
        private static readonly GameOfLifeUI lifeUI = new();

        /// <summary>
        /// Creates object of the CellBoard.
        /// </summary>
        /// <param name="width" The width dimensions of the board in cells.></param>
        /// <param name="height" The height dimensions of the board in cells.></param>
        /// <returns>cellBoard object of the CellBoard.</returns>
        public CellBoard CreateCellBoardObject(int width, int height)
        {
            CellBoard cellBoard = new CellBoard();
            cellBoard.width = width;
            cellBoard.height = height;
            cellBoard.iterationCount = 0;
            cellBoard.aliveCount = 0;
            cellBoard.loopEdges = true;
            Manager.InitializeRandomBoard(cellBoard);
            return cellBoard;
        }

        /// <summary>
        /// Runs the application: shows navigation menu and possibility for the user to select size of field, and shows the outcome in a Console window.
        /// </summary>
        public void StartApp()
        {
            UserOutput.StartMenuMessage();
            lifeUI.ShowMenu();
        }

        /// <summary>
        /// Case 1 - start a new game - in the navigation menu at the start of the game.
        /// </summary>
        public void StartANewGameCase()
        {
            int width = WidthCheck();
            int height = Manager.HeightCheck();

            if (width > 0 && height > 0)
            {
                CellBoard game = Manager.CreateCellBoardObject(width, height);
                Console.Clear();

                // Run the game until the Escape key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    Manager.RunGame(game);
                }

                UserOutput.ExitMenuMessage();
                lifeUI.ExitMenu(game);
            }
            else
            {
                UserOutput.InvalidInputMessage();
            }
        }

        /// <summary>
        /// Case 2 - load the previously saved game - in the navigation menu at the start of the game.
        /// </summary>
        public void StartSavedGameCase()
        {
            CellBoard game = FileOperator.JSONSDeserilaize();
            Console.Clear();
            // Run the game until the Escape key is pressed.
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    Manager.RunGame(game);
                }
            UserOutput.ExitMenuMessage();
            lifeUI.ExitMenu(game);
        }

        /// <summary>
        /// Checks if the user has entered correct input for the width and throws exception if the input is not valid.
        /// </summary>
        public int WidthCheck()
        {
            UserOutput.WidthMessage();
            try
            {
                int width = int.Parse(Console.ReadLine()!);
                return width;
            }
            catch (FormatException)
            {
                UserOutput.FormatExceptionMessage();
                return 0;
            }
            catch (OverflowException)
            {
                UserOutput.OverFlowExceptionMessage();
                return 0;
            }
        }

        // <summary>
        // Checks if the user has entered correct input for the height and throws exception if the input is not valid.
        // </summary>
        public int HeightCheck()
        {
            UserOutput.HeightMessage();
            try
            {
                int height = int.Parse(Console.ReadLine()!);
                return height;
            }
            catch (FormatException)
            {
                UserOutput.FormatExceptionMessage();
                return 0;
            }
            catch (OverflowException)
            {
                UserOutput.OverFlowExceptionMessage();
                return 0;
            }
        }

        /// <summary>
        /// Shows the game board with the iteration and live cell count.
        /// </summary>
        public void RunGame(CellBoard cellBoard)
        {
            //Console.Clear();
            DrawBoard(cellBoard);
            UserOutput.IterationAndLiveCellInformation(cellBoard);
            Logic.UpdateBoard(cellBoard);

            // Wait for a bit between updates.
            Thread.Sleep(GameOfLifeUI.delay);
        }

        /// <summary>
        /// Draws the board to the console.
        /// </summary>
        /// <param name="cellBoard" object of the CellBoard.></param>
        public void DrawBoard(CellBoard cellBoard)
        {
            // One Console.Write call is much faster than writing each cell individually.
            StringBuilder builder = new();

            for (var row = 0; row < cellBoard.height; row++)
            {
                DrawColumn(cellBoard, builder, row);
                builder.Append('\n');
            }

            // Write the string to the console.
            Console.SetCursorPosition(0, 0);
            Console.Write(builder.ToString());
        }

        /// <summary>
        /// Draws the columns to the console.
        /// </summary>
        /// <param name="cellBoard" object of the CellBoard.></param>
        /// <param name="builder" object of a Stringbuilder.></param>
        /// <param name="row" describes the rows of the grid.></param>
        private void DrawColumn(CellBoard cellBoard, StringBuilder builder, int row)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                char c = cellBoard.board[column, row] ? GameOfLifeUI.full_block_char : GameOfLifeUI.empty_block_char;

                // Each cell is two characters wide.
                builder.Append(c);
                builder.Append(c);
            }
        }

        /// <summary>
        /// Creates the initial board with a random state.
        /// </summary>
        /// <param name="cellBoard" object of the CellBoard.></param>
        public void InitializeRandomBoard(CellBoard cellBoard)
        {
            //var board = new CellBoard();
            var random = new Random();

            cellBoard.board = new bool[cellBoard.width, cellBoard.height];
            for (var row = 0; row < cellBoard.height; row++)
            {
                GenerateRandomColumn(cellBoard, random, row);
            }
        }

        /// <summary>
        /// Creates the initial columns with a random state.
        /// </summary>
        /// <param name="cellBoard" object of the CellBoard.></param>
        /// <param name="random" random object.></param>
        /// <param name="row" describes the rows of the grid.></param>
        public void GenerateRandomColumn(CellBoard cellBoard, Random random, int row)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                // Equal probability of being true or false.
                cellBoard.board[column, row] = random.Next(2) == 0;
            }
        }
    }
}
