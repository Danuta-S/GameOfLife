using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Library
{
    public interface IGameOfLifeManager
    {
        CellBoard CreateCellBoardObject(int width, int height);
        void StartApp();
        void StartANewGameCase();
        void StartSavedGameCase();
        int WidthCheck();
        int HeightCheck();
        void RunGame(CellBoard cellBoard);
        void DrawBoard(CellBoard cellBoard);
        void DrawColumn(CellBoard cellBoard, StringBuilder builder, int row);
        void InitializeRandomBoard(CellBoard cellBoard);
        void GenerateRandomColumn(CellBoard cellBoard, Random random, int row);
        void ShowMenu();
        void ExitMenu(CellBoard cellBoard);
    }
}
