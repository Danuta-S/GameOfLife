using GameOfLife.Interfaces;
using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Contains methods and variables for saving information to file and restoring it on application start.
    /// </summary>
    public class FileOperator : IFileOperator
    {
        private const string filePath = @"C:\GameOfLifeFolder\CellData.txt";
        private const string arrayfilePath = @"C:\GameOfLifeFolder\CellDataArray.txt";

        /// <summary>
        /// Saves the game to file.
        /// </summary>
        /// <param name="cellBoard">object of the CellBoard.</param>
        public void JSONSerilaize(CellBoard cellBoard)
        {
            string jsonData = JsonConvert.SerializeObject(cellBoard, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        /// <summary>
        /// Saves up to 1000 games to file.
        /// </summary>
        /// <param name="cellBoards">Array of the CellBoard</param>
        public void JSONSerilaize(CellBoard[] cellBoards)
        {
            string jsonData = JsonConvert.SerializeObject(cellBoards, Formatting.Indented);
            File.WriteAllText(arrayfilePath, jsonData);
        }

        /// <summary>
        /// Load up to 1000 previously saved games.
        /// </summary>
        /// <returns>cellBoards array of the CellBoard</returns>
        public CellBoard[] LoadPreviouslySavedGamesInArray()
        {
            string json = File.ReadAllText(arrayfilePath);
            CellBoard[] cellBoards = JsonConvert.DeserializeObject<CellBoard[]>(json);
            return cellBoards;
        }

        /// <summary>
        /// Restores the previously saved game.
        /// </summary>
        /// <returns>cellBoard object of the CellBoard.</returns>
        public CellBoard JSONSDeserilaize()
        {
            string json = File.ReadAllText(filePath);
            CellBoard cellBoard = JsonConvert.DeserializeObject<CellBoard>(json);
            return cellBoard;
        }
    }
}
