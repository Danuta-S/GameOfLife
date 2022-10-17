using GameOfLife.Interfaces;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Contains methods and variables that are responsible the console.
    /// </summary>
    public class CellBoardUI
    {
        private readonly IFileOperator _fileOperator;
        private readonly IManager _manager;
        private readonly ICellBoardLogic _logic;

        public CellBoardUI(IFileOperator fileOperator, IManager manager, ICellBoardLogic logic)
        {
            _fileOperator = fileOperator;
            _manager = manager;
            _logic = logic;
        }

        // Displays how the dead cells will appear in console.
        public const char empty_block_char = ' ';

        // Displays how the live cells will appear in console.
        public const char full_block_char = '\u2588';

        // The delay in milliseconds between board updates, it is used for the game field to be updated by iteration each second.
        public const int delay = 1000;

        // Array of the selected 8 games that are visible on screen.
        public static int[] Draw8GamesByIndex = new int[8];

        /// <summary>
        /// Case 1 - start a new game - in the navigation menu at the start of the game.
        /// </summary>
        private void StartANewGameCase()
        {
            int width = WidthCheck();
            int height = HeightCheck();

            if (width > 0 && height > 0)
            {
                CellBoard game = _manager.CreateCellBoardObject(width, height);
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
        private void StartSavedGameCase()
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
        /// Case 3 - show selected up to 8 games on screen - in the navigation menu at the start of the game.
        /// </summary>
        private void StartUpTo1000GamesCase()
        {
            int count = CountCheck();
            int width = WidthCheck();
            int height = HeightCheck();

            if (width > 0 && height > 0)
            {
                //CellBoard game = CreateCellBoardObject(width, height);
                CellBoard[] games = _manager.CreateCellBoardObjectArray(width, height, count);

                int gameCount = GamesToShowCheck();
                SelectUpTo8GamesToShow(gameCount, games);
                Console.Clear();

                // Run the game until the Escape key is pressed.
                while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    RunMultipleGames(games, gameCount);
                }

                UserOutput.ExitMenuFor8SelectedGamesMessage();
                ExitMenu(games);
            }
            else
            {
                UserOutput.InvalidInputMessage();
            }
        }

        /// <summary>
        /// Case 4 - load the previously saved 1000 games and select up to 8 games to be shown on screen - in the navigation menu at the start of the game.
        /// </summary>
        private void StartUpTo1000SavedGameCase()
        {
            CellBoard[] games = _fileOperator.LoadPreviouslySavedGamesInArray();

            int gameCount = GamesToShowCheck();
            SelectUpTo8GamesToShow(gameCount, games);
            Console.Clear();
            // Run the game until the Escape key is pressed.
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                RunMultipleGames(games, gameCount);
            }
            UserOutput.ExitMenuFor8SelectedGamesMessage();
            ExitMenu(games);
        }

        /// <summary>
        /// Allows user to choose how many (1-8) games to show on the screen.
        /// </summary>
        /// <returns>count or 0 - user can decide how many games to see on the screen.</returns>
        private int GamesToShowCheck()
        {
            UserOutput.InputGamesToShowMessage();

            int.TryParse(Console.ReadLine(), out int count);
            if (count >= 1 & count <= 8)
            {
                return count;
            }
            else
            {
                UserOutput.OutOfRangeMessage();
                GamesToShowCheck();
            }

            return 8;
        }

        /// <summary>
        /// Allows user to select what exact 8 games will be visible on screen.
        /// </summary>
        /// <param name="gamesToShow">int number of games to show.</param>
        /// <param name="boards">Objects of the cellBoard array.</param>
        /// <returns>0, 1, 2, 3, 4, 5, 6, 7, 8 - numbers of the games.</returns>
        private int SelectUpTo8GamesToShow(int gamesToShow, CellBoard[] boards)
        {
            UserOutput.ProvideIndexMessage();
            UserOutput.FirstGameIndexMessage();
            CheckIndex(0, boards);
            if (gamesToShow == 1)
            {
                return 1;
            }

            UserOutput.SecondGameIndexMessage();
            CheckIndex(1, boards);
            if (gamesToShow == 2)
            {
                return 2;
            }

            UserOutput.ThirdGameIndexMessage();
            CheckIndex(2, boards);
            if (gamesToShow == 3)
            {
                return 3;
            }

            UserOutput.FourthGameIndexMessage();
            CheckIndex(3, boards);
            if (gamesToShow == 4)
            {
                return 4;
            }

            UserOutput.FifthGameIndexMessage();
            CheckIndex(4, boards);
            if (gamesToShow == 5)
            {
                return 5;
            }

            UserOutput.SixthGameIndexMessage();
            CheckIndex(5, boards);
            if (gamesToShow == 6)
            {
                return 6;
            }

            UserOutput.SeventhGameIndexMessage();
            CheckIndex(6, boards);
            if (gamesToShow == 7)
            {
                return 7;
            }

            UserOutput.EigthGameIndexMessage();
            CheckIndex(7, boards);
            if (gamesToShow == 8)
            {
                return 8;
            }

            return 0;
        }

        /// <summary>
        /// Shows 8 games on screen in 2 lines (4 games on each line).
        /// </summary>
        /// <param name="boards">Objects of the CellBoard array.</param>
        /// <param name="gamesToShow">int number of games to show.</param>
        private void Draw8Boards(CellBoard[] boards, int gamesToShow)
        {
            // One Console.Write call is much faster than writing each cell individually.
            StringBuilder builder = new();

            for (var row = 0; row < boards[0].height; row++)
            {
                DrawFirst4Boards(boards, gamesToShow, builder, row);
                builder.Append('\n');
            }

            //// Makes a gap between the first and second row of the games.
            builder.Append('\n' + Environment.NewLine + Environment.NewLine);

            for (var row = 0; row < boards[0].height; row++)
            {
                DrawNext4Boards(boards, gamesToShow, builder, row);
                builder.Append('\n');
            }

            // Write the string to the console.
            Console.SetCursorPosition(0, 0);
            Console.Write(builder.ToString());
        }

        /// <summary>
        /// Help method for Draw8Boards method. Places the second line of games to show on screen in Stringbuilder object, row by row.
        /// </summary>
        /// <param name="boards">Objects of the CellBoard array.</param>
        /// <param name="gamesToShow">int number of games to show.</param>
        /// <param name="builder">StringBuilder object.</param>
        /// <param name="row"></param>
        private void DrawNext4Boards(CellBoard[] boards, int gamesToShow, StringBuilder builder, int row)
        {
            for (var draw = 4; draw < gamesToShow; draw++)
            {
                DrawColumn(boards[Draw8GamesByIndex[draw]], builder, row);
                builder.Append('\u25A0');
            }
        }

        /// <summary>
        /// Help method for Draw8Boards method. Places the first line of games to show on screen in Stringbuilder object, row by row.
        /// </summary>
        /// <param name="boards">Objects of the CellBoard array.</param>
        /// <param name="gamesToShow">int number of games to show.</param>
        /// <param name="builder">StringBuilder object.</param>
        /// <param name="row"></param>
        private void DrawFirst4Boards(CellBoard[] boards, int gamesToShow, StringBuilder builder, int row)
        {
            for (var draw = 0; draw < gamesToShow; draw++)
            {
                DrawColumn(boards[Draw8GamesByIndex[draw]], builder, row);
                builder.Append('\u25A0');
                if (draw == 3)
                {
                    break;
                };
            }
        }

        /// <summary>
        /// Draws the board to the console.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        private void DrawBoard(CellBoard cellBoard)
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
        /// Menu in the end for saving and exiting the game after launching up to 1000 games.
        /// </summary>
        /// <param name="cellBoards">object of the array CellBoard array.</param>
        private void ExitMenu(CellBoard[] cellBoards)
        {
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    _fileOperator.JSONSerilaize(cellBoards);
                    UserOutput.GamesSavedMessage();
                    break;
                case "3":
                    int gameCount = GamesToShowCheck();
                    SelectUpTo8GamesToShow(gameCount, cellBoards);
                    Console.Clear();
                    while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
                    {
                        RunMultipleGames(cellBoards, gameCount);
                    }
                    UserOutput.ExitMenuFor8SelectedGamesMessage();
                    ExitMenu(cellBoards);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Menu in the end of the game for saving and exiting the game.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        private void ExitMenu(CellBoard cellBoard)
        {
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    _fileOperator.JSONSerilaize(cellBoard);
                    UserOutput.GameSavedMessage();
                    break;
            }
        }

        /// <summary>
        /// Navigation menu at the start of the game.
        /// </summary>
        private void ShowMenu()
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
                    StartUpTo1000GamesCase();
                    break;
                case "4":
                    StartUpTo1000SavedGameCase();
                    break;
                case "5":
                    break;
            }
        }

        /// <summary>
        /// Draws the columns to the console.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="builder">object of a Stringbuilder.</param>
        /// <param name="row">describes the rows of the grid.</param>
        private void DrawColumn(CellBoard cellBoard, StringBuilder builder, int row)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                char c = cellBoard.board[column, row] ? CellBoardUI.full_block_char : CellBoardUI.empty_block_char;

                // Each cell is two characters wide.
                builder.Append(c);
                builder.Append(c);
            }
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
        /// Shows the game board with the iteration and live cell count.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        private void RunGame(CellBoard cellBoard)
        {
            DrawBoard(cellBoard);
            UserOutput.IterationAndLiveCellInformation(cellBoard);
            _logic.UpdateBoard(cellBoard);

            // Wait for a bit between updates.
            Thread.Sleep(CellBoardUI.delay);
        }

        /// <summary>
        /// Executes up to 1000 games and shows real-time statistic of the iterations, live games and live cells in total.
        /// </summary>
        /// <param name="boards">Objects of the CellBoard array.</param>
        /// <param name="gamesToShow">int number of games to show.</param>
        private void RunMultipleGames(CellBoard[] boards, int gamesToShow)
        {
            var count = _logic.CountAliveBoardsInArray(boards);
            Draw8Boards(boards, gamesToShow);
            Console.WriteLine(Constants.Messages.SelectedGamesIndex + String.Join(", ", SelectedGamesIndexes(Draw8GamesByIndex, gamesToShow)));
            Console.Write(Constants.Messages.Iterations + boards[0].iterationCount.ToString() + Environment.NewLine);
            Console.WriteLine(Constants.Messages.AliveGames + count);
            Console.WriteLine(Constants.Messages.CellsInTotal + _logic.CountAliveCellsInArray(boards));

            _logic.UpdateAllBoardsInArray(boards);

            // Wait for a bit between updates.
            Thread.Sleep(CellBoardUI.delay);
        }

        /// <summary>
        /// Checks user's input of index.
        /// </summary>
        /// <param name="index">Indexes of the array.</param>
        /// <param name="boards">Objects of the CellBoard array.</param>
        private void CheckIndex(int index, CellBoard[] boards)
        {
            int.TryParse(Console.ReadLine(), out var id);

            if (id < boards.Length)
            {
                Draw8GamesByIndex[index] = id;
            }
            else
            {
                UserOutput.IndexOutOfRange();
                Draw8GamesByIndex[index] = 0;
            }
        }

        /// <summary>
        /// Filters the indexes of games to be shown on screen from the Draw8GamesByIndex array.
        /// </summary>
        /// <param name="Draw8GamesByIndex">array of the indexes chosen by the user.</param>
        /// <param name="gamesToShow">int number of games to show.</param>
        /// <returns>shownGameIndexes - indexes of the games that the user has chosen.</returns>
        private int[] SelectedGamesIndexes(int[] Draw8GamesByIndex, int gamesToShow)
        {
            int[] shownGameIndexes = new int[gamesToShow];
            ; for (int iterator = 0; iterator < gamesToShow; iterator++)
            {
                shownGameIndexes[iterator] = Draw8GamesByIndex[iterator];
            }
            return shownGameIndexes;
        }

        /// <summary>
        /// Checks if the user has entered correct input when choosing how many (1-1000) games to be executed in parallel.
        /// </summary>
        /// <returns>count or 1000 - count of the games executed in parallel.</returns>
        private int CountCheck()
        {
            UserOutput.CountMessage();
            int.TryParse(Console.ReadLine(), out int count);

            if (count >= 1 && count <= 1000)
            {
                return count;
            }
            else
            {
                UserOutput.OutOfRangeMessage();
                CountCheck();
            }

            return 1000;
        }

        /// <summary>
        /// Checks if the user has entered correct input for the width.
        /// </summary>
        /// <returns>width or 0 - width dimension of the board in cells.</returns>
        private int WidthCheck()
        {
            UserOutput.WidthMessage();

            int.TryParse(Console.ReadLine(), out int width);
            if (width > 0)
            {
                return width;
            }
            else
            {
                UserOutput.InvalidInputMessage();
                WidthCheck();
            }

            return 0;
        }

        /// <summary>
        /// Checks if the user has entered correct input for the height.
        /// </summary>
        /// <returns>height or 0 - height dimension of the board in cells.</returns>
        private int HeightCheck()
        {
            UserOutput.HeightMessage();

            int.TryParse(Console.ReadLine(), out int height);
            if (height > 0)
            {
                return height;
            }
            else
            {
                UserOutput.InvalidInputMessage();
                HeightCheck();
            }

            return 0;
        }
    }
}
