namespace Pipe.Core.Procedure;

public class GetRuntimePath : IProcedure
{
    private string _returnPath;

    public void Read(ProcedureReader reader)
    {
        _returnPath = reader.ReadReturn("return_path");
    }

    public void Run(Stack stack)
    {
        string runtimePath = stack.PeekRuntimePath();

        stack.SetVariable(_returnPath, runtimePath);
    }
}