namespace Builder.Pipe;

public class PipeMachine : IRunnerContainer
{
    private const int RUNNER_LIMIT = 256;
    
    private ICommandRunner[] _runners;
    private IFileSystem _fileSystem;
    private byte _isBooted;
    
    public void Boot(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);
        
        _runners = new ICommandRunner [RUNNER_LIMIT];
        _fileSystem = fileSystem;

        _isBooted = 1;
    }
    
    public void BindRunner(ICommandRunner runner, int commandIndex)
    {
        if (_isBooted == 0) throw new InvalidOperationException("machine is not booted");
        if (runner == null) throw new ArgumentNullException(nameof(runner));
        
        _validateCommandIndex(commandIndex);

        if (_runners[commandIndex] != null)
        {
            throw new InvalidOperationException($"command is already binded: {commandIndex}");
        }

        _runners[commandIndex] = runner;
    }
    
    public void Run(IList<SerializedCommand> commandList)
    {
        if (_isBooted == 0) throw new InvalidOperationException("machine is not booted");
        if (commandList == null) throw new ArgumentNullException(nameof(commandList));

        for (int i = 0; i < commandList.Count; i++)
        {
            SerializedCommand command = commandList[i];
            
            _validateCommandIndex(command.id);

            ICommandRunner runner = _runners[command.id];

            if (runner == null)
            {
                throw new Exception($"Runner is not binded for command '{command.id}'");
            }
            
            runner.Run(_fileSystem, command);
        }
    }

    private static void _validateCommandIndex(int command)
    {
        if (command <= 0 || command >= RUNNER_LIMIT)
        {
            throw new ArgumentException($"invalid command index '{command}'.");
        }
    }
}