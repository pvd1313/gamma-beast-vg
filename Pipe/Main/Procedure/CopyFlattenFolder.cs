namespace Pipe.Procedure;

public class CopyFlattenFolder : IProcedure
{
    private string _sourceFolder;
    private string _targetFolder;
    private string _fileMask;
    
    public void Read(ProcedureReader reader)
    {
        _sourceFolder = reader.ReadParameter("source_folder");
        _targetFolder = reader.ReadParameter("target_folder");
        _fileMask = reader.ReadParameter("file_mask");
    }

    public void Run(Stack stack)
    {
        IFileSystem fileSystem = stack.GetFileSystem();

        fileSystem.CopyFlattenFolder(_sourceFolder, _targetFolder, _fileMask);
    }
}