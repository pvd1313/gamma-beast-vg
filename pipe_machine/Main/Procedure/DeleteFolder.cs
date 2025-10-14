namespace PipeMachine.Procedure;

public class DeleteFolder : IProcedure
{
    private string _folder;
    
    public void Read(ParameterReader reader)
    {
        _folder = reader.Read("folder");
    }

    public void Run(Stack stack)
    {
        IFileSystem fileSystem = stack.GetFileSystem();

        fileSystem.DeleteFolder(_folder);
    }
}