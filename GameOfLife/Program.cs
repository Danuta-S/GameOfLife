using GameOfLifeLibrary;

namespace GameOfLife
{
    class Program
    {
        private static readonly GameOfLifeManager Manager = new();

        static void Main(string[] args)
        {
            Manager.StartApp();
        }
    }
}