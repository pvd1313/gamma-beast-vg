namespace Builder.Pipe;

public struct CopyFileCommand
{
    public string sourcePath;
    public string targetPath;
    
    public static SerializedCommand Serialize(string sourceFile, string targetFile)
    {
        if (string.IsNullOrEmpty(sourceFile)) throw new ArgumentException("empty sourceFile");
        if (string.IsNullOrEmpty(targetFile)) throw new ArgumentException("empty targetFile");
        
        return new SerializedCommand
        {
            id = (int)ECommand.CopyFile,
            obj0 = sourceFile,
            obj1 = targetFile,
        };
    }

    public static CopyFileCommand Deserialize(SerializedCommand command)
    {
        if (command.id != (int)ECommand.CopyFile) throw new ArgumentException("invalid command type");

        return new CopyFileCommand
        {
            sourcePath = (string) command.obj0,
            targetPath = (string) command.obj1
        };
    }
}