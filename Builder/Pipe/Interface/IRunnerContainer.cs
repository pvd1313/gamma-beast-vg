namespace Builder.Pipe;

public interface IRunnerContainer
{
    void BindRunner(ICommandRunner runner, int commandIndex);
}