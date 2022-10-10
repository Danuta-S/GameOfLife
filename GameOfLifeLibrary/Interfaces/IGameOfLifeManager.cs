using System.Text;

namespace GameOfLife.Library.Interfaces
{
    public interface IGameOfLifeManager
    {
        /// <summary>
        /// Creates object of the CellBoard.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <returns>cellBoard object of the CellBoard.</returns>
        CellBoard CreateCellBoardObject(int width, int height);

        /// <summary>
        /// Runs the application: shows navigation menu and possibility for the user to select size of field, and shows the outcome in a Console window.
        /// </summary>
        void Start();

        /// <summary>
        /// Case 1 - start a new game - in the navigation menu at the start of the game.
        /// </summary>
        void StartANewGameCase();

        /// <summary>
        /// Case 2 - load the previously saved game - in the navigation menu at the start of the game.
        /// </summary>
        void StartSavedGameCase();

        /// <summary>
        /// Checks if the user has entered correct input for the width and throws exception if the input is not valid.
        /// </summary>
        /// <returns>width or 0</returns>
        int WidthCheck();

        /// <summary>
        /// Checks if the user has entered correct input for the height and throws exception if the input is not valid.
        /// </summary>
        /// <returns>height or 0</returns>
        int HeightCheck();

        /// <summary>
        /// Shows the game board with the iteration and live cell count.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        void RunGame(CellBoard cellBoard);

        /// <summary>
        /// Draws the board to the console.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        void DrawBoard(CellBoard cellBoard);

        /// <summary>
        /// Draws the columns to the console.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="builder">object of a Stringbuilder.</param>
        /// <param name="row">describes the rows of the grid.</param>
        void DrawColumn(CellBoard cellBoard, StringBuilder builder, int row);

        /// <summary>
        /// Creates the initial board with a random state.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        void InitializeRandomBoard(CellBoard cellBoard);

        /// <summary>
        /// Creates the initial columns with a random state.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="random">random object.</param>
        /// <param name="row">describes the rows of the grid.</param>
        void GenerateRandomColumn(CellBoard cellBoard, Random random, int row);

        /// <summary>
        /// Navigation menu at the start of the game.
        /// </summary>
        void ShowMenu();

        /// <summary>
        /// Menu in the end of the game for saving and exiting the game.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        void ExitMenu(CellBoard cellBoard);
    }
}
