namespace Pipe.Instruction;

public class Variable : IInstruction
{
    public void Run(Stack stack)
    {
        Arguments arguments = stack.ParseInstructionArguments(2);

        string variableName = new (arguments[0]);
        string variableValue = stack.EvaluateString(arguments[1]);
        
        stack.SetVariable(variableName, variableValue);
    }
}