namespace GameOfLife.Interfaces;

public interface IFileOperator
{
    /// <summary>
    /// Saves the game to file.
    /// </summary>
    /// <param name="cellBoard">object of the CellBoard.</param>
    void JSONSerilaize(CellBoard cellBoard);

    /// <summary>
    /// Saves up to 1000 games to file.
    /// </summary>
    /// <param name="cellBoards">Array of the CellBoard.</param>
    void JSONSerilaize(CellBoard[] cellBoards);

    /// <summary>
    /// Restores the previously saved game.
    /// </summary>
    /// <returns>cellBoard object of the CellBoard.</returns>
    CellBoard JSONSDeserilaize();

    /// <summary>
    /// Load up to 1000 previously saved games.
    /// </summary>
    /// <returns>cellBoards - array of the CellBoard.</returns>
    CellBoard[] LoadPreviouslySavedGamesInArray();
}
