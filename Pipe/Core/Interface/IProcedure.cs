namespace Pipe.Core;

public interface IProcedure
{
    void Read(ProcedureReader reader);

    void Run(Stack stack);
}