using GameOfLife.Interfaces;
using StructureMap;

namespace GameOfLife
{
    public class DependencyInjection : Registry
    {
        public DependencyInjection()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
            For<IManager>().Use<Manager>();
            For<ICellBoardLogic>().Use<CellBoardLogic>();
            For<IFileOperator>().Use<FileOperator>();
        }
    }
}
