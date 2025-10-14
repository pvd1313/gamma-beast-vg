namespace PipeMachine;

public interface IFileSystem
{
    void CopyFile(string sourcePath, string targetPath);

    void CopyFlattenFolder(string sourceFolder, string targetFolder, string fileMask);
    
    void DeleteFolder(string folder);
}