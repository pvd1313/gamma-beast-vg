namespace Pipe;

public interface IMachine
{
    void Inject(IInstruction instruction, int instructionIndex);
    
    void Run(string pipeFilePath);
}