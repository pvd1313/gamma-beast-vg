namespace Builder;

public static class Safe
{
    public static void Run(string operationName, Action action)
    {
        if (string.IsNullOrEmpty(operationName)) throw new ArgumentException("operationName is empty");
        if (action == null) throw new ArgumentNullException(nameof(action));

        try
        {
            action();
        }
        catch (Exception e)
        {
            Terminate(operationName, e);
        }
    }
    
    private static void Terminate(string operationName, Exception exception)
    {
        Console.WriteLine("Failed to " + operationName);

        Exception? childException = exception;

        while (childException != null)
        {
            Console.WriteLine(childException.Message);
            Console.WriteLine(childException.StackTrace);

            childException = childException.InnerException;
        }
    
        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();

        throw new Exception("Application terminated.", exception);
    }
}