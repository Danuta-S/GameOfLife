namespace GameOfLife.Library
{
    /// <summary>
    /// Contains methods and variables that are responsible for the look of the cell board.
    /// </summary>
    public class GameOfLifeUI
    {
        // Displays how the dead cells will appear in console.
        public const char empty_block_char = ' ';

        // Displays how the live cells will appear in console.
        public const char full_block_char = '\u2588';

        // The delay in milliseconds between board updates, it is used for the game field to be updated by iteration each second.
        public const int delay = 1000;
    }
}
