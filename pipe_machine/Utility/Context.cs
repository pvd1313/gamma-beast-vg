using System.Diagnostics;

namespace PipeMachine.Utility;

public static class Context
{
    public static void Run(string errorMessage, Action action)
    {
        if (string.IsNullOrEmpty(errorMessage)) throw new ArgumentException("operationName is empty");
        if (action == null) throw new ArgumentNullException(nameof(action));

        try
        {
            action();
        }
        catch (Exception e)
        {
            _terminateWithException(errorMessage, e);
        }
    }
    
    private static void _terminateWithException(string errorMessage, Exception exception)
    {
        if (Debugger.IsAttached)
        {
            throw exception;
        }
        
        Console.WriteLine(errorMessage);

        Exception childException = exception;

        while (childException != null)
        {
            Console.WriteLine(childException.Message);

            childException = childException.InnerException;
        }
    
        Console.WriteLine("Press any key to exit...");

        Console.ReadKey();

        throw new Exception("Application terminated.", exception);
    }

    public static void Terminate(string errorMessage)
    {
        if (Debugger.IsAttached)
        {
            throw new Exception(errorMessage);
        }
        
        Console.WriteLine(errorMessage);
        
        Console.WriteLine("Press any key to exit...");
        
        Console.ReadKey();
        
        throw new Exception("Application terminated: " + errorMessage);
    }
}