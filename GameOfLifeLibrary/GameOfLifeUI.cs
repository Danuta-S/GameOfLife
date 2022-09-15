using System.Text;

namespace GameOfLife
{
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
        public static int width = 32;
        public static int height = 32;

        // True if cell rules can loop around edges.
        public static bool loopEdges = true;

        /// <summary>
        /// Sets up the Console.
        /// </summary>
        public static void InitializeConsole()
        {
            Console.BackgroundColor = GameOfLifeUI.extra_color;
            Console.Clear();

            Console.CursorVisible = false;

            // Each cell is two characters wide.
            // Using an extra row on the bottom to prevent scrolling when drawing the board.
            int width = Math.Max(GameOfLifeUI.width, 8) * 2 + 1;
            int height = Math.Max(GameOfLifeUI.height, 8) + 1;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            Console.BackgroundColor = GameOfLifeUI.dead_color;
            Console.ForegroundColor = GameOfLifeUI.live_color;
        }

        /// <summary>
        /// Creates the initial board with a random state.
        /// </summary>
        public static void InitializeRandomBoard()
        {
            var random = new Random();

            GameOfLifeUI.board = new bool[GameOfLifeUI.width, GameOfLifeUI.height];
            for (var y = 0; y < GameOfLifeUI.height; y++)
            {
                for (var x = 0; x < GameOfLifeUI.width; x++)
                {
                    // Equal probability of being true or false.
                    GameOfLifeUI.board[x, y] = random.Next(2) == 0;
                }
            }
        }

        /// <summary>
        /// Draws the board to the console.
        /// </summary>
        public static void DrawBoard()
        {
            // One Console.Write call is much faster than writing each cell individually.
            var builder = new StringBuilder();

            for (var y = 0; y < GameOfLifeUI.height; y++)
            {
                for (var x = 0; x < GameOfLifeUI.width; x++)
                {
                    char c = GameOfLifeUI.board[x, y] ? GameOfLifeUI.full_block_char : GameOfLifeUI.empty_block_char;

                    // Each cell is two characters wide.
                    builder.Append(c);
                    builder.Append(c);
                }
                builder.Append('\n');
            }

            // Write the string to the console.
            Console.SetCursorPosition(0, 0);
            Console.Write(builder.ToString());
        }
    }
}
