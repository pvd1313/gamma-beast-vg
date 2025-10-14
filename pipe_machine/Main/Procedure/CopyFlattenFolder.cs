namespace PipeMachine.Procedure;

public class CopyFlattenFolder : IProcedure
{
    private string _sourceFolder;
    private string _targetFolder;
    private string _fileMask;
    
    public void Read(ParameterReader reader)
    {
        _sourceFolder = reader.Read("source_folder");
        _targetFolder = reader.Read("target_folder");
        _fileMask = reader.Read("file_mask");
    }

    public void Run(Stack stack)
    {
        IFileSystem fileSystem = stack.GetFileSystem();

        fileSystem.CopyFlattenFolder(_sourceFolder, _targetFolder, _fileMask);
    }
}