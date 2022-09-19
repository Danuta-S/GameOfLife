using GameOfLife;
using System.Text.Json;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains methods and variables for saving information to file and restoring it on application start.
    /// </summary>
    public class GameOfLifeFileOperator : IGameOfLifeFileOperator
    {
        private const string RootFolder = @"C:\GameOfLifeFolder";
        private const string FilePath = @"C:\GameOfLifeFolder\CellData.txt";

        /// <summary>
        /// Checks if the file for saving information exists.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfFileExists()
        {
            return File.Exists(FilePath);
        }

        /// <summary>
        /// Checks if the folder for the file where the information will be saved exists.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfDirectoryExists()
        {
            return Directory.Exists(RootFolder);
        }

        /// <summary>
        /// Creates a new file and folder for saving information if the file does not exist already.
        /// </summary>
        /// <param name="exists"></param>
        public void IfFileNotExistCreateNewFile(bool exists)
        {
            if (!exists)
            {
                File.Create(FilePath);
            }
        }

        /// <summary>
        /// Creates a new folder and file for saving information if the folder does not exist already.
        /// </summary>
        /// <param name="exists"></param>
        public void IfDirectoryNotExistCreateNewDirectory(bool exists)
        {
            if (!exists)
            {
                File.Create(FilePath);
            }
        }

        //public static void JsonSerialization(Board board)
        //{
        //    var json = JsonSerializer.Serialize<Board>(board);
        //    Console.WriteLine(json);

        //    var desObject = JsonSerializer.Deserialize<Board>(json);
        //    Console.WriteLine($"Board object : {desObject.width} {desObject.height}");
        //}
    }
}
