namespace Pipe.Core;

public interface IInstruction
{
    void Run(Stack stack);
}