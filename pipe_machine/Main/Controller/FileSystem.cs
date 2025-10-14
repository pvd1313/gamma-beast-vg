namespace PipeMachine;

public class FileSystem : IFileSystem
{
    public void CopyFile(string sourcePath, string targetPath)
    {
        if (string.IsNullOrEmpty(sourcePath)) throw new ArgumentException("sourcePath is empty");
        if (string.IsNullOrEmpty(targetPath)) throw new ArgumentException("targetPath is empty");

        if (File.Exists(sourcePath) == false)
        {
            throw new Exception($"File '{sourcePath}' not exists");
        }

        string directoryPath = Path.GetDirectoryName(targetPath);

        if (Directory.Exists(directoryPath) == false)
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.Copy(sourcePath, targetPath, true);
    }

    public void DeleteFolder(string folder)
    {
        if (string.IsNullOrEmpty(folder)) throw new ArgumentException("folder is empty");

        if (Directory.Exists(folder))
        {
            Directory.Delete(folder, true);
        }
    }

    public void CopyFlattenFolder(string sourceFolder, string targetFolder, string fileMask)
    {
        if (string.IsNullOrEmpty(sourceFolder)) throw new ArgumentException("sourceFolder is empty");
        if (string.IsNullOrEmpty(targetFolder)) throw new ArgumentException("targetFolder is empty");
        if (string.IsNullOrEmpty(fileMask)) throw new ArgumentException("fileMask is empty");

        if (Directory.Exists(sourceFolder) == false)
        {
            throw new Exception($"Directory '{sourceFolder}' not exists");
        }

        if (Directory.Exists(targetFolder) == false)
        {
            Directory.CreateDirectory(targetFolder);
        }

        string[] files = Directory.GetFiles(sourceFolder, fileMask, SearchOption.AllDirectories);

        foreach (string sourceFilePath in files)
        {
            string fileName = Path.GetFileName(sourceFilePath);
            string targetFilePath = Path.Combine(targetFolder, fileName);

            File.Copy(sourceFilePath, targetFilePath, true);
        }
    }
}