namespace GameOfLifeLibrary
{
    public interface IGameOfLifeFileOperator
    {
        bool CheckIfFileExists();
        bool CheckIfDirectoryExists();
        void IfFileNotExistCreateNewFile(bool exists);
        void IfDirectoryNotExistCreateNewDirectory(bool exists);
    }
}
