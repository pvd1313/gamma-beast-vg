namespace Pipe.Core.Procedure;

public class RunPipeFile : IProcedure
{
    private string _file;

    public void Read(ProcedureReader reader)
    {
         _file = reader.ReadParameter("file");
    }

    public void Run(Stack stack)
    {
        IMachine machine = stack.GetMachine();

        machine.Run(_file);
    }
}