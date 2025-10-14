namespace Pipe.Procedure;

public class CopyFile : IProcedure
{
    private string _sourceFile;
    private string _targetFile;

    public void Read(ParameterReader reader)
    {
        _sourceFile = reader.Read("source_file");
        _targetFile = reader.Read("target_file");
    }

    public void Run(Stack stack)
    {
        IFileSystem fileSystem = stack.GetFileSystem();

        fileSystem.CopyFile(_sourceFile, _targetFile);
    }
}