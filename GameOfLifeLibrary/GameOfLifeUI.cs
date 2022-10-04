using DocumentFormat.OpenXml.ExtendedProperties;

namespace GameOfLife.Library
{
    /// <summary>
    /// Contains methods and variables that are responsible for the look of the cell board.
    /// </summary>
    public class GameOfLifeUI : IGameOfLifeUI
    {
        public const char empty_block_char = ' ';
        public const char full_block_char = '\u2588';

        //The delay in milliseconds between board updates.
        public const int delay = 1000;
    }
}
