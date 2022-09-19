namespace GameOfLifeLibrary
{
    /// <summary>
    /// Interface that contains methods and variables for saving information to file and restoring it on application start.
    /// </summary>
    public interface IGameOfLifeFileOperator
    {
        /// <summary>
        /// Checks if the file for saving information exists.
        /// </summary>
        /// <returns>FilePath - information about the location of the file where the info is saved.</returns>
        bool CheckIfFileExists();

        /// <summary>
        /// Checks if the folder for the file where the information will be saved exists.
        /// </summary>
        /// <returns>RootFolder - folder's location and name where the file is saved.</returns>
        bool CheckIfDirectoryExists();

        /// <summary>
        /// Creates a new file and folder for saving information if the file does not exist already.
        /// </summary>
        /// <param name="exists" bool param "exists" checks if the file does not exist to create a new file - FilePath.></param>
        void IfFileNotExistCreateNewFile(bool exists);

        /// <summary>
        /// Creates a new folder and file for saving information if the folder does not exist already.
        /// </summary>
        /// <param name="exists" bool param "exists" checks if the file does not exist to create a new file - FilePath.></param>
        void IfDirectoryNotExistCreateNewDirectory(bool exists);
    }
}
