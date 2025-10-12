namespace Builder.Pipe;

public interface IFileSystem
{
    void CopyFile(string sourcePath, string targetPath);
}