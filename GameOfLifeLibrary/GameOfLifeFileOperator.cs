namespace GameOfLifeLibrary
{
    public class GameOfLifeFileOperator : IGameOfLifeFileOperator
    {
        private const string RootFolder = @"C:\GameOfLifeFolder";
        private const string FilePath = @"C:\GameOfLifeFolder\CellData.txt";

        public bool CheckIfFileExists()
        {
            return File.Exists(FilePath);
        }

        public bool CheckIfDirectoryExists()
        {
            return Directory.Exists(RootFolder);
        }

        public void IfFileNotExistCreateNewFile(bool exists)
        {
            if (!exists)
            {
                File.Create(FilePath);
            }
        }

        public void IfDirectoryNotExistCreateNewDirectory(bool exists)
        {
            if (!exists)
            {
                File.Create(FilePath);
            }
        }
    }
}
