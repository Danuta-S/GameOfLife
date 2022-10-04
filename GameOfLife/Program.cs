using GameOfLife.Library;
using StructureMap;
using StructureMap.Graph;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<ConsoleRegistry>();
            var app = container.GetInstance<GameOfLifeManager>();
            app.StartApp();
        }
    }
}