using GameOfLife;

namespace GameOfLifeLibrary
{
    public class BusinessLogic
    {
        /// <summary>
        /// Moves the board to the next state based on Conway's rules.
        /// </summary>
        public static void UpdateBoard()
        {
            // A temp variable to hold the next state while it's being calculated.
            bool[,] newBoard = new bool[GameOfLifeUI.width, GameOfLifeUI.height];

            for (var y = 0; y < GameOfLifeUI.height; y++)
            {
                for (var x = 0; x < GameOfLifeUI.width; x++)
                {
                    var n = CountLiveNeighbors(x, y);
                    var c = GameOfLifeUI.board[x, y];

                    // A live cell dies unless it has exactly 2 or 3 live neighbors.
                    // A dead cell remains dead unless it has exactly 3 live neighbors.
                    newBoard[x, y] = c && (n == 2 || n == 3) || !c && n == 3;
                }
            }

            // Set the board to its new state.
            GameOfLifeUI.board = newBoard;
        }

        /// <summary>
        /// Returns the number of live neighbors around the cell at position (x,y).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CountLiveNeighbors(int x, int y)
        {
            // The number of live neighbors.
            int value = 0;

            // This nested loop enumerates the 9 cells in the specified cells neighborhood.
            for (var j = -1; j <= 1; j++)
            {
                // If loopEdges is set to false and y+j is off the board, continue.
                if (!GameOfLifeUI.loopEdges && y + j < 0 || y + j >= GameOfLifeUI.height)
                {
                    continue;
                }

                // Loop around the edges if y+j is off the board.
                int k = (y + j + GameOfLifeUI.height) % GameOfLifeUI.height;

                for (var i = -1; i <= 1; i++)
                {
                    // If loopEdges is set to false and x+i is off the board, continue.
                    if (!GameOfLifeUI.loopEdges && x + i < 0 || x + i >= GameOfLifeUI.width)
                    {
                        continue;
                    }

                    // Loop around the edges if x+i is off the board.
                    int h = (x + i + GameOfLifeUI.width) % GameOfLifeUI.width;

                    // Count the neighbor cell at (h,k) if it is alive.
                    value += GameOfLifeUI.board[h, k] ? 1 : 0;
                }
            }

            // Subtract 1 if (x,y) is alive since we counted it as a neighbor.
            return value - (GameOfLifeUI.board[x, y] ? 1 : 0);
        }
    }
}
