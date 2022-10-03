namespace GameOfLife.Library
{
    /// <summary>
    /// Contains the properties of the CellBoard.
    /// </summary>
    public class CellBoard
    {
        // The dimensions of the board in cells.
        public int width { get; set; }
        public int height { get; set; }

        // Holds the current state of the board.
        public bool[,] board { get; set; } = null!;

        // True if cell rules can loop around edges.
        public bool loopEdges = true;

        // Iteration counter represents count of iterations.
        public int iterationCount { get; set; }

        // Holds the number alive cels in current board state.
        public int aliveCount { get; set; }
    }
}
