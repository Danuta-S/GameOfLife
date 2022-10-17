namespace GameOfLife.Interfaces
{
    public interface IManager
    {
        /// <summary>
        /// Creates object of the CellBoard.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <returns>cellBoard object of the CellBoard.</returns>
        CellBoard CreateCellBoardObject(int width, int height);

        /// <summary>
        /// Creates array of the CellBoard objects.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <param name="count">The count of the games - objects of the CellBoardArray.</param>
        /// <returns>CellBoardArray - array of the cellBoard objects.</returns>
        CellBoard[] CreateCellBoardObjectArray(int width, int height, int count);
    }
}
