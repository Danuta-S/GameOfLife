using GameOfLife.Interfaces;
using Moq;

namespace GameOfLife.UnitTests
{
    public class GameOfLifeManagerTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(0, 0)]
        [InlineData(5.5, 10)]
        [InlineData(10, 6.5)]
        public void CreateCellBoardObject_ChecksAliveCellCount(int width, int height)
        {
            // Arrange
            var mock = new Mock<ICellBoardLogic>();
            mock.Setup(p => p.CountAlive(It.IsAny<CellBoard>())).Returns(1);
            var sut = new Manager(mock.Object);

            // Act
            var result = sut.CreateCellBoardObject(width, height);

            // Assert
            Assert.Equal(1, result.aliveCount);
        }
    }
}