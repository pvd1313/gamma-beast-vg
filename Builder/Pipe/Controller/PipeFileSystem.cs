namespace Builder.Pipe;

public class PipeFileSystem : IFileSystem
{
    public void CopyFile(string sourcePath, string targetPath)
    {
        if (string.IsNullOrEmpty(sourcePath)) throw new ArgumentException("sourcePath is empty");
        if (string.IsNullOrEmpty(targetPath)) throw new ArgumentException("targetPath is empty");
        
        if (File.Exists(sourcePath) == false)
        {
            throw new Exception($"File '{sourcePath}' not exists");
        }

        File.Copy(sourcePath, targetPath, true);
    }
}