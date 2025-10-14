namespace Pipe.Procedure;

public class InstructionPrint : IProcedure
{
    private int _enabled;
    
    public void Read(ParameterReader reader)
    {
        _enabled = int.Parse(reader.Read("enabled"));
    }

    public void Run(Stack stack)
    {
        Config config = stack.GetConfig();

        config.instructionPrintEnabled = _enabled == 1;

        stack.SetConfig(config);
    }
}