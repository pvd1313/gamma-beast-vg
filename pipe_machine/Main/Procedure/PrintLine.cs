namespace PipeMachine.Procedure;

public class PrintLine : IProcedure
{
    private string _message;
    
    public void Read(ParameterReader reader)
    {
        _message = reader.Read("message");
    }

    public void Run(Stack stack)
    {
        Console.WriteLine(_message);
    }
}