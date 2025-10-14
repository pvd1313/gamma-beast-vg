namespace PipeMachine;

public interface IMachine
{
    void Inject(IInstruction instruction, int instructionIndex);
}