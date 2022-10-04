using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Library
{
    public interface IGameOfLifeLogic
    {
        void UpdateBoard(CellBoard cellBoard);
        void UpdateColumns(CellBoard cellBoard, int row, bool[,] newBoard);
        int CountLiveNeighbors(CellBoard cellBoard, int column, int row);
        int CountNeighborsInColumn(CellBoard cellBoard, int column, int value, int inverseRow);
        void CountAlive(CellBoard cellBoard);
        int CounAliveInRows(CellBoard cellBoard, int row, int count);
    }
}
