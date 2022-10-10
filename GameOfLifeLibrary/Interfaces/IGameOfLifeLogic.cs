namespace GameOfLife.Library.Interfaces
{
    public interface IGameOfLifeLogic
    {
        /// <summary>
        /// Moves the board to the next state based on Conway's rules.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        void UpdateBoard(CellBoard cellBoard);

        /// <summary>
        /// Moves the columns to the next state based on Conway's rules.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="row">describes the rows of the grid.</param>
        /// <param name="newBoard">the board is set to its new state.</param>
        void UpdateColumns(CellBoard cellBoard, int row, bool[,] newBoard);

        /// <summary>
        /// Returns the number of live neighbors around the cell.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="column">describes the columns of the grid.</param>
        /// <param name="row">describes the rows of the grid.</param>
        /// <returns>Value - the number of live neighbors.</returns>
        int CountLiveNeighbors(CellBoard cellBoard, int column, int row);

        /// <summary>
        /// Returns the number of live neighbors in column.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="column">describes the columns of the grid.</param>
        /// <param name="value">describes the number of live neighbors.</param>
        /// <param name="inverseRow">row index on the oposite side of the board.</param>
        /// <returns>Value - the number of live neighbors.</returns>
        int CountNeighborsInColumn(CellBoard cellBoard, int column, int value, int inverseRow);

        /// <summary>
        /// Returns the count of live cells.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        int CountAlive(CellBoard cellBoard);

        /// <summary>
        /// Returns the count of live cells in rows.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="aliveCells">the count of live cells.</param>
        /// <param name="row">describes the rows of the grid.</param>
        /// <returns></returns>
        int CountAliveInRows(CellBoard cellBoard, int alive, int row);
    }
}
