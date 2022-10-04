using DocumentFormat.OpenXml.ExtendedProperties;
using GameOfLife.Library;
using GameOfLifeLibrary;

namespace GameOfLife
{
    /// <summary>
    /// Contains methods and variables that are responsible for the look of the cell board.
    /// </summary>
    public class GameOfLifeUI
    {
        public const char empty_block_char = ' ';
        public const char full_block_char = '\u2588';

        //The delay in milliseconds between board updates.
        public const int delay = 1000;
    }
}
