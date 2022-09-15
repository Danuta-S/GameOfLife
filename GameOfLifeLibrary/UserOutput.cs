using GameOfLife;

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
            Console.WriteLine("(You can stop application in any moment by pressing S key)" + Environment.NewLine);
            Console.WriteLine("Please enter the size of field.");
            Console.Write("Width: ");
            GameOfLifeUI.width= Convert.ToInt32(Console.ReadLine());
            Console.Write("Height: ");
            GameOfLifeUI.height = Convert.ToInt32(Console.ReadLine());
        }
    }
}
