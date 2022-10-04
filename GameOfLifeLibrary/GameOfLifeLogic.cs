using GameOfLife;
using GameOfLife.Library;
using System.Text;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains methods that are responsible for the logic of the app's algorithm.
    /// </summary>
    public class GameOfLifeLogic : IGameOfLifeLogic
    {
        /// <summary>
        /// Moves the board to the next state based on Conway's rules.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        public void UpdateBoard(CellBoard cellBoard)
        {
            // A temp variable to hold the next state while it's being calculated.
            bool[,] newBoard = new bool[cellBoard.width, cellBoard.height];

            for (var row = 0; row < cellBoard.height; row++)
            {
                UpdateColumns(cellBoard, row, newBoard);
            }

            // Set the board to its new state.
            cellBoard.board = newBoard;
            cellBoard.iterationCount++;
            CountAlive(cellBoard);
        }

        /// <summary>
        /// Moves the columns to the next state based on Conway's rules.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="row">describes the rows of the grid.</param>
        /// <param name="newBoard">the board is set to its new state.</param>
        public void UpdateColumns(CellBoard cellBoard, int row, bool[,] newBoard)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                var n = CountLiveNeighbors(cellBoard, column, row);
                var c = cellBoard.board[column, row];

                // A live cell dies unless it has exactly 2 or 3 live neighbors.
                // A dead cell remains dead unless it has exactly 3 live neighbors.
                newBoard[column, row] = c && (n == 2 || n == 3) || !c && n == 3;
            }
        }

        /// <summary>
        /// Returns the number of live neighbors around the cell.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="column">describes the columns of the grid.</param>
        /// <param name="row">describes the rows of the grid.</param>
        /// <returns>Value - the number of live neighbors.</returns>
        public int CountLiveNeighbors(CellBoard cellBoard, int column, int row)
        {
            // The number of live neighbors.
            int value = 0;

            // This nested loop enumerates the 9 cells in the specified cells neighborhood.
            for (var j = -1; j <= 1; j++)
            {
                // If loopEdges is set to false and row+j is off the board, continue.
                if (!cellBoard.canLoopEdges && row + j < 0 || row + j >= cellBoard.height)
                {
                    continue;
                }

                // Loop around the edges if row+j is off the board.
                int k = (row + j + cellBoard.height) % cellBoard.height;
                value = CountNeighborsInColumn(cellBoard, column, value, k);
            }

            // Subtract 1 if (column,row) is alive since we counted it as a neighbor.
            return value - (cellBoard.board[column, row] ? 1 : 0);
        }

        /// <summary>
        /// Returns the number of live neighbors in column.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="column">describes the columns of the grid.</param>
        /// <param name="value">describes the number of live neighbors.</param>
        /// <param name="inverseRow">row index on the oposite side of the board.</param>
        /// <returns>Value - the number of live neighbors.</returns>
        public int CountNeighborsInColumn(CellBoard cellBoard, int column, int value, int inverseRow)
        {
            for (var i = -1; i <= 1; i++)
            {
                // If loopEdges is set to false and column+i is off the board, continue.
                if (!cellBoard.canLoopEdges && column + i < 0 || column + i >= cellBoard.width)
                {
                    continue;
                }

                // Loop around the edges if column+i is off the board.
                int inverseColumn = (column + i + cellBoard.width) % cellBoard.width;

                // Count the neighbor cell at (inverseColumn,inverseRow) if it is alive.
                value += cellBoard.board[inverseColumn, inverseRow] ? 1 : 0;
            }
            // Returns the number of live neighbors around the cell.
            return value;
        }

        /// <summary>
        /// Returns the count of live cells.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        public void CountAlive(CellBoard cellBoard)
        {
            // Local temp variable holding the number of alive cells.
            int count = 0;

            for (var row = 0; row < cellBoard.height; row++)
            {
                count = CounAliveInRows(cellBoard, row, count);
            }

            cellBoard.aliveCount = count;
        }

        /// <summary>
        /// Returns the count of live cells in rows.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        /// <param name="row">describes the rows of the grid.</param>
        /// <param name="count">the number of live cells.</param>
        /// <returns>Count - the number of live cells.</returns>
        public int CounAliveInRows(CellBoard cellBoard, int row, int count)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                count += cellBoard.board[column, row] ? 1 : 0;
            }

            return count;
        }
    }
}
