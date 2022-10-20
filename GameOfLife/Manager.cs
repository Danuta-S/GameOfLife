using GameOfLife.Interfaces;

namespace GameOfLife
{
    /// <summary>
    /// Contains the methods that are responsible for launching the game.
    /// </summary>
    public class Manager : IManager
    {
        private readonly ICellBoardLogic _lifeLogic;

        public Manager(ICellBoardLogic lifeLogic)
        {
            _lifeLogic = lifeLogic;
        }

        /// <summary>
        /// Creates object of the CellBoard.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <returns>cellBoard object of the CellBoard.</returns>
        public CellBoard CreateCellBoardObject(int width, int height)
        {
            CellBoard cellBoard = new()
            {
                width = width,
                height = height,
                iterationCount = 0,
                aliveCount = 0,
                canLoopEdges = true
            };
            InitializeRandomBoard(cellBoard);
            cellBoard.aliveCount = _lifeLogic.CountAlive(cellBoard);

            return cellBoard;
        }

        /// <summary>
        /// Creates array of the CellBoard objects.
        /// </summary>
        /// <param name="width">The width dimensions of the board in cells.</param>
        /// <param name="height">The height dimensions of the board in cells.</param>
        /// <param name="count">The count of the games - objects of the CellBoardArray.</param>
        /// <returns>CellBoardArray array of the cellBoard objects.</returns>
        public CellBoard[] CreateCellBoardObjectArray(int width, int height, int count)
        {
            CellBoard[] CellBoardArray = new CellBoard[count];
            for (int i = 0; i < CellBoardArray.Length; i++)
            {
                CellBoard cellBoard = new()
                {
                    index = i,
                    width = width,
                    height = height,
                    iterationCount = 0,
                    aliveCount = 0,
                    canLoopEdges = true,
                    isAlive = true
                };
                InitializeRandomBoard(cellBoard);
                CellBoardArray[i] = cellBoard;
            }
            return CellBoardArray;
        }

        /// <summary>
        /// Creates the initial board with a random state.
        /// </summary>
        /// <param name="cellBoard">Object of the CellBoard.</param>
        private void InitializeRandomBoard(CellBoard cellBoard)
        {
            var random = new Random();

            cellBoard.board = new bool[cellBoard.width, cellBoard.height];
            for (var row = 0; row < cellBoard.height; row++)
            {
                GenerateRandomColumn(cellBoard, random, row);
            }
        }

        /// <summary>
        /// Creates the initial columns with a random state.
        /// </summary>
        /// <param name="cellBoard">Object of the CellBoard.</param>
        /// <param name="random">Random object.</param>
        /// <param name="row">Describes the rows of the grid.</param>
        private void GenerateRandomColumn(CellBoard cellBoard, Random random, int row)
        {
            for (var column = 0; column < cellBoard.width; column++)
            {
                // Equal probability of being true or false.
                cellBoard.board[column, row] = random.Next(2) == 0;
            }
        }
    }
}
