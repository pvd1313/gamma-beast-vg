namespace Pipe;

public interface IProcedure
{
    void Read(ParameterReader reader);

    void Run(Stack stack);
}