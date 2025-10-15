namespace Pipe.Procedure;

public class DeleteFolder : IProcedure
{
    private string _folder;
    
    public void Read(ProcedureReader reader)
    {
        _folder = reader.ReadParameter("folder");
    }

    public void Run(Stack stack)
    {
        IFileSystem fileSystem = stack.GetFileSystem();

        fileSystem.DeleteFolder(_folder);
    }
}