using GameOfLife;
using System.Text.Json;
using System.IO;

namespace GameOfLifeLibrary
{
    /// <summary>
    /// Contains methods and variables for saving information to file and restoring it on application start.
    /// </summary>
    public class GameOfLifeFileOperator : IGameOfLifeFileOperator
    {
        public const string rootFolder = @"C:\GameOfLifeFolder";
        public const string filePath = @"C:\GameOfLifeFolder\CellData.txt";

        /// <summary>
        /// Checks if the file for saving information exists.
        /// </summary>
        /// <returns>FilePath - information about the location of the file where the info is saved.</returns>
        public bool CheckIfFileExists()
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Checks if the folder for the file where the information will be saved exists.
        /// </summary>
        /// <returns>RootFolder - folder's location and name where the file is saved.</returns>
        public bool CheckIfDirectoryExists()
        {
            return Directory.Exists(rootFolder);
        }

        /// <summary>
        /// Creates a new file and folder for saving information if the file does not exist already.
        /// </summary>
        /// <param name="exists" bool param "exists" checks if the file does not exist to create a new file - FilePath.></param>
        public void IfFileNotExistCreateNewFile(bool exists)
        {
            if (!exists)
            {
                File.Create(filePath);
            }
        }

        /// <summary>
        /// Creates a new folder and file for saving information if the folder does not exist already.
        /// </summary>
        /// <param name="exists" bool param "exists" checks if the file does not exist to create a new file - FilePath.></param>
        public void IfDirectoryNotExistCreateNewDirectory(bool exists)
        {
            if (!exists)
            {
                File.Create(filePath);
            }
        }

        //public static void SaveInformationToFile()
        //{
        //    //    string[] lines = { GameOfLifeUI.board };
        //    //    File.WriteAllLines(@"C:\GameOfLifeFolder\CellData.txt", lines);
        //    //}

        //    //public static void JsonSerialization(GameOfLifeUI.board)
        //    //{
        //    string json = JsonSerializer.Serialize(GameOfLifeUI.board);
        //    Console.WriteLine(json);

        //    //    var desObject = JsonSerializer.Deserialize<Board>(json);
        //    //    Console.WriteLine($"Board object : {desObject.width} {desObject.height}");
        //}
    }
}
