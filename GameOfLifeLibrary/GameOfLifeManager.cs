using GameOfLife;
using GameOfLife.Library;
using System.Text;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains the methods that are responsible for launching the game.
    /// </summary>
    public class GameOfLifeManager : IGameOfLifeManager
    {
        private readonly IGameOfLifeManager _gameOfLifeManager;
        private readonly IGameOfLifeUI _gameOfLifeUI;
        private readonly IGameOfLifeFileOperator _fileOperator;
        private readonly IGameOfLifeLogic _lifeLogic;

        public GameOfLifeManager()
        {
        }

        public GameOfLifeManager(IGameOfLifeUI gameOfLifeUI, IGameOfLifeManager gameOfLifeManager, IGameOfLifeFileOperator fileOperator, IGameOfLifeLogic lifeLogic) =>
        (_gameOfLifeUI, _gameOfLifeManager, _fileOperator, _lifeLogic) = (gameOfLifeUI, gameOfLifeManager, fileOperator, lifeLogic);

        /// <summary>
        /// Creates object of the CellBoard.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <returns>cellBoard object of the CellBoard.</returns>
        public CellBoard CreateCellBoardObject(int width, int height)
        {
            CellBoard cellBoard = new CellBoard();
            cellBoard.width = width;
            cellBoard.height = height;
            cellBoard.iterationCount = 0;
            cellBoard.aliveCount = 0;
            cellBoard.canLoopEdges = true;
            _gameOfLifeManager.InitializeRandomBoard(cellBoard);
            return cellBoard;
        }

        /// <summary>
        /// Runs the application: shows navigation menu and possibility for the user to select size of field, and shows the outcome in a Console window.
        /// </summary>
        public void StartApp()
        {
            UserOutput.StartMenuMessage();
            _gameOfLifeManager.ShowMenu();
        }

        /// <summary>
        /// Case 1 - start a new game - in the navigation menu at the start of the game.
        /// </summary>
        public void StartANewGameCase()
        {
            int width = WidthCheck();
            int height = _gameOfLifeManager.HeightCheck();

            if (width > 0 && height > 0)
            {
                CellBoard game = _gameOfLifeManager.CreateCellBoardObject(width, height);
                Console.Clear();

                // Run the game until the Escape key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    _gameOfLifeManager.RunGame(game);
                }

                UserOutput.ExitMenuMessage();
                _gameOfLifeUI.ExitMenu(game);
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
            CellBoard game = _fileOperator.JSONSDeserilaize();
            Console.Clear();
            // Run the game until the Escape key is pressed.
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    _gameOfLifeManager.RunGame(game);
                }
            UserOutput.ExitMenuMessage();
            _gameOfLifeUI.ExitMenu(game);
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
            _lifeLogic.UpdateBoard(cellBoard);

            // Wait for a bit between updates.
            Thread.Sleep(GameOfLifeUI.delay);
        }

        /// <summary>
        /// Draws the board to the console.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
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
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="builder">object of a Stringbuilder.</param>
        /// <param name="row">describes the rows of the grid.</param>
        public void DrawColumn(CellBoard cellBoard, StringBuilder builder, int row)
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
        /// <param name="cellBoard">object of the CellBoard.</param>
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
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="random">random object.</param>
        /// <param name="row">describes the rows of the grid.</param>
        public void GenerateRandomColumn(CellBoard cellBoard, Random random, int row)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                // Equal probability of being true or false.
                cellBoard.board[column, row] = random.Next(2) == 0;
            }
        }

        /// <summary>
        /// Navigation menu at the start of the game.
        /// </summary>
        public void ShowMenu()
        {
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _gameOfLifeManager.StartANewGameCase();
                    break;
                case "2":
                    _gameOfLifeManager.StartSavedGameCase();
                    break;
                case "3":
                    UserOutput.EndMessage();
                    break;
            }
        }

        /// <summary>
        /// Menu in the end of the game for saving and exiting the game.
        /// </summary>
        public void ExitMenu(CellBoard cellBoard)
        {
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    UserOutput.EndMessage();
                    break;
                case "2":
                    Console.Clear();
                    _fileOperator.JSONSerilaize(cellBoard);
                    UserOutput.GameSavedMessage();
                    break;
            }
        }
    }
}
