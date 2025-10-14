namespace PipeMachine;

public interface IProcedure
{
    void Read(ParameterReader reader);

    void Run(Stack stack);
}