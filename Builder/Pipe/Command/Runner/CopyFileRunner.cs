namespace Builder.Pipe;

public class CopyFileRunner : ICommandRunner
{
    public void Run(IFileSystem system, SerializedCommand command)
    {
        CopyFileCommand myCommand = CopyFileCommand.Deserialize(command);
        
        system.CopyFile(myCommand.sourcePath, myCommand.targetPath);
    }
}