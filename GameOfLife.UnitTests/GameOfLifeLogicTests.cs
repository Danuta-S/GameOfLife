namespace GameOfLife.UnitTests
{
    public class GameOfLifeLogicTests
    {
        [Fact]
        public void CountAlive_ReturnAliveCells()
        {
            // Arrange
            var cellBoard = new CellBoard
            {
                width = 2,
                height = 2,
                iterationCount = 1,
                aliveCount = 3,
                canLoopEdges = true,
                board = new bool[2, 2],
                index = 0
            };

            cellBoard.board[0, 0] = true;
            cellBoard.board[0, 1] = true;
            cellBoard.board[1, 0] = true;

            var sut = new CellBoardLogic();

            // Act
            var result = sut.CountAlive(cellBoard);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void CountAliveBoardsInArray_ReturnCount()
        {
            // Arrange
            var cellBoardArray = new CellBoard[3];
            var cellBoardOne = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 80,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 0
            };

            var cellBoardTwo = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 80,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 1
            };

            var cellBoardThree = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 80,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 2
            };

            cellBoardArray[0] = cellBoardOne;
            cellBoardArray[1] = cellBoardTwo;
            cellBoardArray[2] = cellBoardThree;

            var sut = new CellBoardLogic();

            // Act
            var result = sut.CountAliveBoardsInArray(cellBoardArray);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void CountAliveBoardsInArray_DoesNotReturnCount()
        {
            // Arrange
            var cellBoardArray = new CellBoard[2];
            var cellBoardOne = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 80,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 0
            };

            var cellBoardTwo = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 80,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 1
            };

            cellBoardArray[0] = cellBoardOne;
            cellBoardArray[1] = cellBoardTwo;

            var sut = new CellBoardLogic();

            // Act
            var result = sut.CountAliveBoardsInArray(cellBoardArray);

            // Assert
            Assert.NotEqual(1, result);
        }

        [Fact]
        public void CountAliveCellsInArray_ReturnCount()
        {
            // Arrange
            var cellBoardArray = new CellBoard[2];
            var cellBoardOne = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 70,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 0
            };

            var cellBoardTwo = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 80,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 1
            };

            cellBoardArray[0] = cellBoardOne;
            cellBoardArray[1] = cellBoardTwo;

            var sut = new CellBoardLogic();

            // Act
            var result = sut.CountAliveCellsInArray(cellBoardArray);

            // Assert
            Assert.Equal(150, result);
        }

        [Fact]
        public void CountAliveCellsInArray_DoesNotReturnCount()
        {
            // Arrange
            var cellBoardArray = new CellBoard[3];
            var cellBoardOne = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 55,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 0
            };

            var cellBoardTwo = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 40,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 1
            };

            var cellBoardThree = new CellBoard
            {
                width = 10,
                height = 10,
                iterationCount = 1,
                aliveCount = 30,
                canLoopEdges = true,
                board = new bool[10, 10],
                index = 2
            };

            cellBoardArray[0] = cellBoardOne;
            cellBoardArray[1] = cellBoardTwo;
            cellBoardArray[2] = cellBoardThree;

            var sut = new CellBoardLogic();

            // Act
            var result = sut.CountAliveCellsInArray(cellBoardArray);

            // Assert
            Assert.NotEqual(10, result);
        }
    }
}