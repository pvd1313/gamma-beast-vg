namespace Pipe.Core;

public interface IMachine
{
    void InjectInstruction(IInstruction instruction, int id);

    void InjectProcedure(IProcedure procedure, string id);
    
    void Run(string pipeFilePath);
}