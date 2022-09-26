using GameOfLife;
using Newtonsoft.Json.Linq;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains methods that are responsible for the logic of the app's algorithm.
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        /// Moves the board to the next state based on Conway's rules.
        /// </summary>
        public static void UpdateBoard()
        {
            // A temp variable to hold the next state while it's being calculated.
            bool[,] newBoard = new bool[GameOfLifeUI.width, GameOfLifeUI.height];

            for (var row = 0; row < GameOfLifeUI.height; row++)
            {
                UpdateColumns(newBoard, row);
            }

            // Set the board to its new state.
            GameOfLifeUI.board = newBoard;
            IterationCount();
            CountAlive();   
        }

        /// <summary>
        /// Moves the columns to the next state based on Conway's rules.
        /// </summary>
        /// <param name="newBoard" the board is set to its new state.></param>
        /// <param name="row" describes the rows of the grid.></param>
        private static void UpdateColumns(bool[,] newBoard, int row)
        {
            for (var column = 0; column < GameOfLifeUI.width; column++)
            {
                var n = CountLiveNeighbors(column, row);
                var c = GameOfLifeUI.board[column, row];

                // A live cell dies unless it has exactly 2 or 3 live neighbors.
                // A dead cell remains dead unless it has exactly 3 live neighbors.
                newBoard[column, row] = c && (n == 2 || n == 3) || !c && n == 3;
            }
        }

        /// <summary>
        /// Represents count of iterations.
        /// </summary>
        public static void IterationCount()
        {
            GameOfLifeUI.iterationCount++;
        }

        /// <summary>
        /// Returns the number of live neighbors around the cell at position (x,y).
        /// </summary>
        /// <param name="column" describes the columns of the grid.></param>
        /// <param name="row" describes the rows of the grid.></param>
        /// <returns>Value - the number of live neighbors.</returns>
        public static int CountLiveNeighbors(int column, int row)
        {
            // The number of live neighbors.
            int value = 0;

            // This nested loop enumerates the 9 cells in the specified cells neighborhood.
            for (var j = -1; j <= 1; j++)
            {
                // If loopEdges is set to false and row+j is off the board, continue.
                if (!GameOfLifeUI.loopEdges && row + j < 0 || row + j >= GameOfLifeUI.height)
                {
                    continue;
                }

                // Loop around the edges if row+j is off the board.
                int k = (row + j + GameOfLifeUI.height) % GameOfLifeUI.height;

                value = CountNeighborsInColumn(column, value, k);
            }

            // Subtract 1 if (x,y) is alive since we counted it as a neighbor.
            return value - (GameOfLifeUI.board[column, row] ? 1 : 0);
        }

        /// <summary>
        /// Returns the number of live neighbors in column.
        /// </summary>
        /// <param name="column" describes the columns of the grid.></param>
        /// <param name="value" describes the number of live neighbors.></param>
        /// <param name="inverseRow" row index on the oposite side of the board.></param>
        /// <returns>Value - the number of live neighbors.</returns>
        private static int CountNeighborsInColumn(int column, int value, int inverseRow)
        {
            for (var i = -1; i <= 1; i++)
            {
                // If loopEdges is set to false and x+i is off the board, continue.
                if (!GameOfLifeUI.loopEdges && column + i < 0 || column + i >= GameOfLifeUI.width)
                {
                    continue;
                }

                // Loop around the edges if x+i is off the board.
                int inverseColumn = (column + i + GameOfLifeUI.width) % GameOfLifeUI.width;

                // Count the neighbor cell at (h,k) if it is alive.
                value += GameOfLifeUI.board[inverseColumn, inverseRow] ? 1 : 0;
            }

            return value;
        }

        /// <summary>
        /// Returns the count of live cells.
        /// </summary>
        /// <returns>Count - the number of live cells.</returns>
        public static int CountAlive()
        {
            // The number of alive cells.
            int count = 0;

            for (var row = 0; row < GameOfLifeUI.height; row++)
            {
                count = CounAliveInRows(count, row);
            }

            return count;
        }

        /// <summary>
        /// Returns the count of live cells in rows.
        /// </summary>
        /// <param name="count" the number of live cells.></param>
        /// <param name="row" describes the rows of the grid.></param>
        /// <returns>Count - the number of live cells.</returns>
        private static int CounAliveInRows(int count, int row)
        {
            for (var column = 0; column < GameOfLifeUI.width; column++)
            {
                count += GameOfLifeUI.board[column, row] ? 1 : 0;
            }

            return count;
        }
    }
}
