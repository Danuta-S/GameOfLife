using GameOfLifeLibrary;

//var builder = Host.CreateDefaultBuilder(args);

//builder.ConfigureServices(
//    services =>
//        services.AddHostedService<Worker>()
//          .AddScoped<IGameOfLifeManager, GameOfLifeManager>());
//var host = builder.Build();
//host.Run();

namespace GameOfLife
{
    class Program
    {
        private static readonly GameOfLifeManager manager = new GameOfLifeManager();
   

        //private readonly IGameOfLifeManager _manager;

        //public Program(IGameOfLifeManager manager) =>
        //    _manager = manager;

        static void Main(string[] args)
        {
            manager.StartApp();
        }
    }
}