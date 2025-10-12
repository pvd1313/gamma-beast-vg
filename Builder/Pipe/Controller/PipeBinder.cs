namespace Builder.Pipe;

public class PipeBinder
{
    private IRunnerContainer _container;
    
    public void BindAll(IRunnerContainer container)
    {
        ArgumentNullException.ThrowIfNull(container);

        _container = container;
        
        Bind<CopyFileRunner>(ECommand.CopyFile);
    }

    private void Bind<TRunner>(ECommand command) where TRunner : ICommandRunner, new()
    {
        ICommandRunner runner;
        
        try
        {
            runner = new TRunner();
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during {typeof(TRunner).FullName}:new()", e);
        }

        try
        {
            _container.BindRunner(runner, (int) command);
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during binding of '{typeof(TRunner)}'", e);
        }
    }
}