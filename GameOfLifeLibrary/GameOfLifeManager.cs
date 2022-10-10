using GameOfLife.Library.Interfaces;
using System.ComponentModel;
using System.Text;

namespace GameOfLife.Library
{
    /// <summary>
    /// Contains the methods that are responsible for launching the game.
    /// </summary>
    public class GameOfLifeManager : IGameOfLifeManager
    {
        private readonly IGameOfLifeFileOperator _fileOperator;
        private readonly IGameOfLifeLogic _lifeLogic;

        public GameOfLifeManager(IGameOfLifeFileOperator fileOperator, IGameOfLifeLogic lifeLogic)
        {
            _fileOperator = fileOperator;
            _lifeLogic = lifeLogic;
        }

        // Array of the selected 8 games that are visible on screen.
        public int[] Draw8GamesByIndex = new int[8];

        // Array of the executed 1000 games.
        public CellBoard[] CellBoardArray = new CellBoard[1000];

        /// <summary>
        /// Creates array of the CellBoard objects.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <returns>CellBoardArray array of the cellBoard objects</returns>
        public CellBoard[] CreateCellBoardObjectArray(int width, int height)
        {
            var i = 0;
            for (i = 0; i < CellBoardArray.Length; i++)
            {
                CellBoard cellBoard = new()
                {
                    index = i,
                    width = width,
                    height = height,
                    iterationCount = 0,
                    aliveCount = 0,
                    canLoopEdges = true,
                    isAlive = true
                };
                InitializeRandomBoard(cellBoard);
                CellBoardArray[i] = cellBoard;
            }
            return CellBoardArray;
        }

        /// <summary>
        /// Creates object of the CellBoard.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <returns>cellBoard object of the CellBoard.</returns>
        public CellBoard CreateCellBoardObject(int width, int height)
        {
            CellBoard cellBoard = new()
            {
                width = width,
                height = height,
                iterationCount = 0,
                aliveCount = 0,
                canLoopEdges = true
            };
            InitializeRandomBoard(cellBoard);
            return cellBoard;
        }

        /// <summary>
        /// Runs the application: shows navigation menu and possibility for the user to select size of field, and shows the outcome in a Console window.
        /// </summary>
        public void Start()
        {
            UserOutput.StartMenuMessage();
            ShowMenu();
        }

        /// <summary>
        /// Case 1 - start a new game - in the navigation menu at the start of the game.
        /// </summary>
        public void StartANewGameCase()
        {
            int width = WidthCheck();
            int height = HeightCheck();

            if (width > 0 && height > 0)
            {
                CellBoard game = CreateCellBoardObject(width, height);
                Console.Clear();

                // Run the game until the Escape key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    RunGame(game);
                }

                UserOutput.ExitMenuFor1GameMessage();
                ExitMenu(game);
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
                RunGame(game);
            }
            UserOutput.ExitMenuFor1GameMessage();
            ExitMenu(game);
        }

        /// <summary>
        /// Case 4 - load the previously saved 1000 games and select 8 games to be shown on screen - in the navigation menu at the start of the game.
        /// </summary>
        public void Start1000SavedGameCase()
        {
            CellBoard[] games = _fileOperator.LoadPreviouslySavedGamesInArray();
            Select8GamesToShow();
            Console.Clear();
            // Run the game until the Escape key is pressed.
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                RunMultipleGames(games);
            }
            UserOutput.ExitMenuFor8SelectedGamesMessage();
            ExitMenu(games);
        }

        /// <summary>
        /// Checks user input index and throws Exception if the index is invalid.
        /// </summary>
        /// <param name="index">Indexes of the array.</param>
        /// <exception cref="Exception">Invalid game index Exception</exception>
        public void CheckIndex(int index)
        {
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                Draw8GamesByIndex[index] = id;
            }
            else
            {
                throw new Exception("Invalid game index");
            }
        }

        /// <summary>
        /// Case 3 - show selected 8 games on screen - in the navigation menu at the start of the game.
        /// </summary>
        /// <exception cref="Exception">Invalid game id exception</exception>
        public void ShowSelected8GamesCase()
        {
            int width = WidthCheck();
            int height = HeightCheck();

            if (width > 0 && height > 0)
            {
                //CellBoard game = CreateCellBoardObject(width, height);
                CellBoard[] games = CreateCellBoardObjectArray(width, height);

                Select8GamesToShow();

                // Run the game until the Escape key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    RunMultipleGames(games);
                }

                _fileOperator.JSONSerilaize(games);
                UserOutput.ExitMenuFor8SelectedGamesMessage();
                ExitMenu(games);
            }
            else
            {
                UserOutput.InvalidInputMessage();
            }
        }

        /// <summary>
        /// Allows user to select what exact 8 games will be visible on screen.
        /// </summary>
        private void Select8GamesToShow()
        {
            UserOutput.ProvideIndexMessage();
            UserOutput.FirstGameIndexMessage();
            CheckIndex(0);
            UserOutput.SecondGameIndexMessage();
            CheckIndex(1);
            UserOutput.ThirdGameIndexMessage();
            CheckIndex(2);
            UserOutput.FourthGameIndexMessage();
            CheckIndex(3);
            UserOutput.FifthGameIndexMessage();
            CheckIndex(4);
            UserOutput.SixthGameIndexMessage();
            CheckIndex(5);
            UserOutput.SeventhGameIndexMessage();
            CheckIndex(6);
            UserOutput.EigthGameIndexMessage();
            CheckIndex(7);
            Console.Clear();
        }

        /// <summary>
        /// Checks if the user has entered correct input for the width and throws exception if the input is not valid.
        /// </summary>
        /// <returns>width or 0</returns>
        public int WidthCheck()
        {
            //IConstants constants;
            UserOutput.WidthMessage();
            try
            {
                int width = int.Parse(Console.ReadLine()!);
                return width;
            }
            catch (FormatException)
            {
                //(Constants.Messages.FormatException);
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
        /// Checks if the user has entered correct input for the height and throws exception if the input is not valid.
        /// </summary>
        /// <returns>height or 0</returns>
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
        /// <param name="cellBoard">object of the CellBoard.</param>
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
        /// Moves all the CellBoards in array to the next state based on Conway's rules.
        /// </summary>
        /// <param name="CellBoardArray">Array of the cellBoard objects.</param>
        public void UpdateAllBoardsInArray(CellBoard[] CellBoardArray)
        {
            foreach (CellBoard cellBoard in CellBoardArray)
            {
                if (cellBoard != null)
                {
                    _lifeLogic.UpdateBoard(cellBoard);
                }
            }
        }

        /// <summary>
        /// Counts how many live games we have in total.
        /// </summary>
        /// <param name="CellBoardArray">Array of the cellBoard objects.</param>
        /// <returns>count - Count of live games in total.</returns>
        public int CountAliveBoardsInArray(CellBoard[] CellBoardArray)
        {
            int count = 0;
            foreach (CellBoard cellBoard in CellBoardArray)
            {
                if (cellBoard != null)
                {
                    count += cellBoard.isAlive == true ? 1 : 0;
                }
            }
            return count;
        }

        /// <summary>
        /// Counts how many live cells we have in total.
        /// </summary>
        /// <param name="CellBoardArray">Array of the cellBoard objects.</param>
        /// <returns>count - Count of live cells in total.</returns>
        public int CountAliveCellsInArray(CellBoard[] CellBoardArray)
        {
            int count = 0;
            foreach (CellBoard cellBoard in CellBoardArray)
            {
                if (cellBoard != null)
                {
                    count += _lifeLogic.CountAlive(cellBoard);
                }
            }
            return count;
        }

        /// <summary>
        /// Executes 1000 games and shows real-time statistic of the iterations, live games and live cells in total.
        /// </summary>
        /// <param name="boards">Objects of the CellBoard array.</param>
        public void RunMultipleGames(CellBoard[] boards)
        {
            Draw8Boards(boards);
            Console.WriteLine("Indexes of the selected games: " + String.Join(", ", Draw8GamesByIndex));
            Console.Write($"Iterations: " + boards[0].iterationCount.ToString() + Environment.NewLine);
            Console.WriteLine("Alive game count: " + CountAliveBoardsInArray(boards));
            Console.WriteLine("Live cells in total: " + CountAliveCellsInArray(boards));

            UpdateAllBoardsInArray(boards);

            // Wait for a bit between updates.
            Thread.Sleep(GameOfLifeUI.delay);
        }

        /// <summary>
        /// Shows 8 games on screen in 2 lines (4 games on each line).
        /// </summary>
        /// <param name="boards">Objects of the CellBoard array.</param>
        public void Draw8Boards(CellBoard[] boards)
        {
            // One Console.Write call is much faster than writing each cell individually.
            StringBuilder builder = new();

            for (var row = 0; row < boards[0].height; row++)
            {
                DrawColumn(boards[Draw8GamesByIndex[0]], builder, row);
                builder.Append('\u25A0');

                DrawColumn(boards[Draw8GamesByIndex[1]], builder, row);
                builder.Append('\u25A0');

                DrawColumn(boards[Draw8GamesByIndex[2]], builder, row);
                builder.Append('\u25A0');

                DrawColumn(boards[Draw8GamesByIndex[3]], builder, row);
                builder.Append('\u25A0');

                builder.Append('\n');
            }

            // Makes a gap between the first and second row of the games.
            builder.Append('\n' + Environment.NewLine + Environment.NewLine);

            for (var row = 0; row < boards[0].height; row++)
            {
                DrawColumn(boards[Draw8GamesByIndex[4]], builder, row);
                builder.Append('\u25A0');

                DrawColumn(boards[Draw8GamesByIndex[5]], builder, row);
                builder.Append('\u25A0');

                DrawColumn(boards[Draw8GamesByIndex[6]], builder, row);
                builder.Append('\u25A0');

                DrawColumn(boards[Draw8GamesByIndex[7]], builder, row);
                builder.Append('\u25A0');

                builder.Append('\n');
            }

            // Write the string to the console.
            Console.SetCursorPosition(0, 0);
            Console.Write(builder.ToString());
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
                    StartANewGameCase();
                    break;
                case "2":
                    StartSavedGameCase();
                    break;
                case "3":
                    ShowSelected8GamesCase();
                    break;
                case "4":
                    Start1000SavedGameCase();
                    break;
                case "5":
                    UserOutput.EndMessage();
                    break;
            }
        }

        /// <summary>
        /// Menu in the end of the game for saving and exiting the game.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
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

        /// <summary>
        /// Menu in the end for saving and exiting the game after launching 1000 games.
        /// </summary>
        /// <param name="cellBoards">object of the array CellBoard[].</param>
        public void ExitMenu(CellBoard[] cellBoards)
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
                    _fileOperator.JSONSerilaize(cellBoards);
                    UserOutput.GamesSavedMessage();
                    break;
                case "3":
                    Select8GamesToShow();
                    while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                    {
                        RunMultipleGames(cellBoards);
                    }
                    UserOutput.ExitMenuFor8SelectedGamesMessage();
                    ExitMenu(cellBoards);
                    break;
            }
        }
    }
}
