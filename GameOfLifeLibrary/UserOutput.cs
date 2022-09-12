using GameOfLife;
using System;
namespace GameOfLifeLibrary
{
    public class UserOutput
    {
        /// <summary>
        /// Shows navigation menu and possibility for the user to select size of field.
        /// </summary>
        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to the Game Of Life!" + Environment.NewLine);
            Console.WriteLine("Please enter the size of field.");
            Console.Write("Width: ");
            GameOfLifeUI.width= int.Parse(Console.ReadLine());
            Console.Write("Height: ");
            GameOfLifeUI.height = int.Parse(Console.ReadLine());
        }
    }
}
