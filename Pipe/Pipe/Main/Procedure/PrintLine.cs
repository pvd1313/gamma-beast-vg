namespace Pipe.Procedure;

public class PrintLine : IProcedure
{
    private string _message;
    
    public void Read(ProcedureReader reader)
    {
        _message = reader.ReadParameter("message");
    }

    public void Run(Stack stack)
    {
        Console.WriteLine(_message);
    }
}