using StructureMap;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<DependencyInjection>();
            var app = container.GetInstance<CellBoardUI>();
            app.Start();
        }
    }
}