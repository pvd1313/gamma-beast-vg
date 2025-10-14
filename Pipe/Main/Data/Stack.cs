namespace Pipe;

public class Stack
{
    private IDictionary<string, string> _parameters;
    private IDictionary<string, string> _variables;
    private string _instruction;
    private IFileSystem _fileSystem;
    private Evaluator _evaluator;
    private Config _config;

    public static Stack Create()
    {
        return new Stack
        {
            _parameters = new Dictionary<string, string>(),
            _variables = new Dictionary<string, string>(),
            _evaluator = Evaluator.Create()
        };
    }

    public Arguments ParseInstructionArguments(int argumentCount)
    {
        return Arguments.Parse(_instruction, argumentCount);
    }

    public Config GetConfig()
    {
        return _config;
    }

    public void SetConfig(Config config)
    {
        _config = config;
    }

    public void SetInstruction(string value)
    {
        _instruction = value;
    }

    public void SetFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IFileSystem GetFileSystem()
    {
        return _fileSystem;
    }

    public void SetVariable(string key, string value)
    {
        _variables[key] = value;
    }

    public void PushParameter(string key, string value)
    {
        if (_parameters.TryAdd(key, value) == false)
        {
            throw new Exception($"parameter '{key}' is already in stack");
        }
    }

    public string PopParameter(string key)
    {
        if (_parameters.Remove(key, out string value) == false)
        {
            throw new Exception($"parameter '{key}' was not found in stack");
        }

        return value;
    }

    public void FinishParameterReading()
    {
        if (_parameters.Count > 0)
        {
            throw new Exception("not all parameters were consumed");
        }
    }

    public string GetVariable(string key)
    {
        if (_variables.TryGetValue(key, out string value) == false)
        {
            throw new KeyNotFoundException($"Variable '{key}' not found in dictionary.");
        }

        return value;
    }

    public string EvaluateString(ReadOnlySpan<char> value)
    {
        return _evaluator.Evaluate(this, value);
    }
}