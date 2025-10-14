using PipeMachine.Utility;

namespace PipeMachine.Procedure;

public class ReadKey : IProcedure
{
    private int _timeoutMS;
    
    public void Read(ParameterReader reader)
    {
        _timeoutMS = int.Parse(reader.Read("timeout_ms"));
    }

    public void Run(Stack stack)
    {
        TimeSpan span = TimeSpan.FromMilliseconds(_timeoutMS);

        if (span.TotalMilliseconds < 0)
        {
            Console.ReadKey();
        }
        else
        {
            Input.ReadKeyTimeout(span, out _);
        }
    }
}