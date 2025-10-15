using Pipe.Utility;

namespace Pipe.Core.Procedure;

public class ReadKey : IProcedure
{
    private int _timeoutMS;
    
    public void Read(ProcedureReader reader)
    {
        _timeoutMS = int.Parse(reader.ReadParameter("timeout_ms"));
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