using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //For<IGameOfLifeLogic>().Use<GameOfLifeLogic>();
            //For<IGameOfLifeFileOperator>().Use<GameOfLifeFileOperator>();
            For<IGameOfLifeUI>().Use<GameOfLifeUI>();
        }
    }
}
