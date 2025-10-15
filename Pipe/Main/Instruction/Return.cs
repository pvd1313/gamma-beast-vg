namespace Pipe.Instruction;

public class Return : IInstruction
{
    public void Run(Stack stack)
    {
        Arguments arguments = stack.ParseInstructionArguments(2);

        string returnName = new(arguments[0]);
        string returnTarget = stack.EvaluateString(arguments[1]);

        stack.PushReturn(returnName, returnTarget);
    }
}