namespace Pipe.Procedure;

public class CopyFile : IProcedure
{
    private string _sourceFile;
    private string _targetFile;

    public void Read(ProcedureReader reader)
    {
        _sourceFile = reader.ReadParameter("source_file");
        _targetFile = reader.ReadParameter("target_file");
    }

    public void Run(Stack stack)
    {
        IFileSystem fileSystem = stack.GetFileSystem();

        fileSystem.CopyFile(_sourceFile, _targetFile);
    }
}