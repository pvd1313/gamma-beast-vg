namespace PipeMachine;

public interface IInstruction
{
    void Run(Stack stack);
}