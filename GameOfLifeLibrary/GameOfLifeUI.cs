using System;
using System.Data.Common;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Contains methods and variables that are responsible for the look of the cell board.
    /// </summary>
    public class GameOfLifeUI
    {
        // The delay in milliseconds between board updates.
        public const int delay = 1000;

        // The cell colors.
        public const ConsoleColor dead_color = ConsoleColor.Black;
        public const ConsoleColor live_color = ConsoleColor.Blue;

        // The color of the cells that are off of the board.
        public const ConsoleColor extra_color = ConsoleColor.Gray;

        public const char empty_block_char = ' ';
        public const char full_block_char = '\u2588';

        // Holds the current state of the board.
        public static bool[,] board;

        // The dimensions of the board in cells.
        public static int width;
        public static int height;

        // True if cell rules can loop around edges.
        public static bool loopEdges = true;

        // Iteration counter represemts count of iterations.
        public static int iterationCount=0;

        /// <summary>
        /// Sets up the Console.
        /// </summary>
        public static void InitializeConsole()
        {
            Console.BackgroundColor = extra_color;
            Console.Clear();

            Console.CursorVisible = false;

            // Each cell is two characters wide.
            // Using an extra row on the bottom to prevent scrolling when drawing the board.
            int width = Math.Max(GameOfLifeUI.width, 8) * 2 + 1;
            int height = Math.Max(GameOfLifeUI.height, 8) + 1;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            Console.BackgroundColor = dead_color;
            Console.ForegroundColor = live_color;
        }

        /// <summary>
        /// Creates the initial board with a random state.
        /// </summary>
        public static void InitializeRandomBoard()
        {
            var random = new Random();

            board = new bool[width, height];
            for (var row = 0; row < height; row++)
            {
                GenerateRandomColumn(random, row);
            }
        }

        /// <summary>
        /// Creates the initial columns with a random state.
        /// </summary>
        /// <param name="random" random object.></param>
        /// <param name="row" describes the rows of the grid.></param>
        private static void GenerateRandomColumn(Random random, int row)
        {
            for (var column = 0; column < width; column++)
            {
                // Equal probability of being true or false.
                board[column, row] = random.Next(2) == 0;
            }
        }

        //public static void InitializeSavedBoard()
        //{
        //    board = new bool[width, height];
        //    for (var row = 0; row < height; row++)
        //    {
        //        GenerateRandomColumn(random, row);
        //    }
        //}

        /// <summary>
        /// Draws the board to the console.
        /// </summary>
        public static void DrawBoard()
        {
            // One Console.Write call is much faster than writing each cell individually.
            StringBuilder builder = new();

            for (var row = 0; row < height; row++)
            {
                DrawColumn(builder, row);
                builder.Append('\n');
            }

            // Write the string to the console.
            Console.SetCursorPosition(0, 0);
            Console.Write(builder.ToString());
        }

        /// <summary>
        /// Draws the columns to the console.
        /// </summary>
        /// <param name="builder" object of a Stringbuilder.></param>
        /// <param name="row" describes the rows of the grid.></param>
        private static void DrawColumn(StringBuilder builder, int row)
        {
            for (var column = 0; column < width; column++)
            {
                char c = board[column, row] ? full_block_char : empty_block_char;

                // Each cell is two characters wide.
                builder.Append(c);
                builder.Append(c);
            }
        }
    }
}
