using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Library
{
    public interface IGameOfLifeFileOperator
    {
        bool CheckIfFileExists();
        bool CheckIfDirectoryExists();
        void IfFileNotExistCreateNewFile(bool exists);
        void IfDirectoryNotExistCreateNewDirectory(bool exists);
        void JSONSerilaize(CellBoard cellBoard);
        CellBoard JSONSDeserilaize();
    }
}
