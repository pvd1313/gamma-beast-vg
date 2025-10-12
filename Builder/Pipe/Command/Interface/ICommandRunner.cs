namespace Builder.Pipe;

public interface ICommandRunner
{
    void Run(IFileSystem system, SerializedCommand command);
}