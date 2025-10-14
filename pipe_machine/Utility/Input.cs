namespace PipeMachine.Utility;

public static class Input
{
    public static bool ReadKeyTimeout(TimeSpan timeout, out ConsoleKeyInfo keyInfo)
    {
        keyInfo = default;
        
        DateTime start = DateTime.Now;

        while ((DateTime.Now - start) < timeout)
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                
                return true;
            }

            Thread.Sleep(50);
        }

        return false;
    }
}