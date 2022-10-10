using GameOfLife.Library.Interfaces;
using StructureMap;

namespace GameOfLife.Library
{
    public class ConsoleRegistry : Registry
    {
        public ConsoleRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
            For<IGameOfLifeManager>().Use<GameOfLifeManager>();
            For<IGameOfLifeLogic>().Use<GameOfLifeLogic>();
            For<IGameOfLifeFileOperator>().Use<GameOfLifeFileOperator>();
        }
    }
}
