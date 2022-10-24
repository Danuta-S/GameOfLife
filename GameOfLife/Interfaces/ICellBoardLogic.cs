namespace GameOfLife.Interfaces;

public interface ICellBoardLogic
{
    /// <summary>
    /// Moves the board to the next state based on Conway's rules.
    /// </summary>
    /// <param name="cellBoard">object of the CellBoard.</param>
    void UpdateBoard(CellBoard cellBoard);

    /// <summary>
    /// Returns the count of live cells.
    /// </summary>
    /// <param name = "cellBoard" > object of the CellBoard.</param>
    /// <returns>alive - count of live cells in cellBoard.</returns>
    int CountAlive(CellBoard cellBoard);

    /// <summary>
    /// Moves all the CellBoards in array to the next state based on Conway's rules.
    /// </summary>
    /// <param name="CellBoardArray">Array of the cellBoard objects.</param>
    void UpdateAllBoardsInArray(CellBoard[] CellBoardArray);

    /// <summary>
    /// Counts how many live games we have in total.
    /// </summary>
    /// <param name="CellBoardArray">Array of the cellBoard objects.</param>
    /// <returns>count - Count of live games in total.</returns>
    int CountAliveBoardsInArray(CellBoard[] CellBoardArray);

    /// <summary>
    /// Counts how many live cells we have in total.
    /// </summary>
    /// <param name="CellBoardArray">Array of the cellBoard objects.</param>
    /// <returns>count - Count of live cells in total.</returns>
    int CountAliveCellsInArray(CellBoard[] CellBoardArray);

}
