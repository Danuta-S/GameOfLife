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
        private static readonly GameOfLifeFileOperator FileOperator = new();
        private static readonly GameOfLifeManager Manager = new();

        public const char empty_block_char = ' ';
        public const char full_block_char = '\u2588';

        //The delay in milliseconds between board updates.
        public const int delay = 1000;

        /// <summary>
        /// Navigation menu at the start of the game.
        /// </summary>
        public void ShowMenu()
        {
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Manager.StartANewGameCase();
                    break;
                case "2":
                    Manager.StartSavedGameCase();
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
                    FileOperator.JSONSerilaize(cellBoard);
                    UserOutput.GameSavedMessage();
                    break;
            }
        }
    }
}
