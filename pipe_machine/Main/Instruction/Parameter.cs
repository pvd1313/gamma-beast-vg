namespace PipeMachine.Instruction;

public class Parameter : IInstruction
{
    public void Run(Stack stack)
    {
        Arguments arguments = stack.ParseInstructionArguments(2);

        string parameterName = new(arguments[0]);
        string parameterValue = stack.EvaluateString(arguments[1]);
        
        stack.PushParameter(parameterName, parameterValue);
    }
}