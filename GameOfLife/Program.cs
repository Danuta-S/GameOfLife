using GameOfLifeLibrary;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            UserOutput.ShowMenu();
            // Use initializeRandomBoard for a random board.
            GameOfLifeUI.InitializeRandomBoard();
            GameOfLifeUI.InitializeConsole();

            // Run the game until the S key is pressed.
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.S)
            {
                GameOfLifeUI.DrawBoard();
                BusinessLogic.UpdateBoard();

                // Wait for a bit between updates.
                Thread.Sleep(GameOfLifeUI.delay);
            }
        }  
    }
}