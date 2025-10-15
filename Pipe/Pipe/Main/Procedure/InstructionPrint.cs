namespace Pipe.Procedure;

public class InstructionPrint : IProcedure
{
    private int _enabled;
    
    public void Read(ProcedureReader reader)
    {
        _enabled = int.Parse(reader.ReadParameter("enabled"));
    }

    public void Run(Stack stack)
    {
        Config config = stack.GetConfig();

        config.instructionPrintEnabled = _enabled == 1;

        stack.SetConfig(config);
    }
}