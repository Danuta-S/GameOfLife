using GameOfLifeLibrary;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            UserOutput.ShowMenu();
            // Use initializeRandomBoard for a larger, random board.
            Logic.InitializeRandomBoard();
            Logic.InitializeConsole();

            // Run the game until the S key is pressed.
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.S)
            {
                Logic.DrawBoard();
                Logic.UpdateBoard();

                // Wait for a bit between updates.
                Thread.Sleep(GameOfLifeUI.delay);
            }
        }  
    }
}