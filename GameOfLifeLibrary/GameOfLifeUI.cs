using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
