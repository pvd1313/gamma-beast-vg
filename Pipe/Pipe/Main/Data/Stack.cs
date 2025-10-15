namespace Pipe;

public class Stack
{
    private IDictionary<string, string> _parameters;
    private IDictionary<string, string> _variables;
    private IDictionary<string, string> _returns;
    private Stack<string> _runtimePath;
    private string _instruction;
    private IFileSystem _fileSystem;
    private IMachine _machine;
    private Evaluator _evaluator;
    private Config _config;

    public static Stack Create(IFileSystem fileSystem, IMachine machine)
    {
        return new Stack
        {
            _parameters = new Dictionary<string, string>(),
            _variables = new Dictionary<string, string>(),
            _returns = new Dictionary<string, string>(),
            _runtimePath = new Stack<string>(),
            _fileSystem = fileSystem,
            _machine = machine,
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

    public IFileSystem GetFileSystem()
    {
        return _fileSystem;
    }

    public IMachine GetMachine()
    {
        return _machine;
    }

    public void PushRuntimePath(string path)
    {
        _runtimePath.Push(path);
    }

    public string PopRuntimePath()
    {
        return _runtimePath.Pop();
    }

    public string PeekRuntimePath()
    {
        return _runtimePath.Peek();
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

    public void PushReturn(string key, string value)
    {
        if (_returns.TryAdd(key, value) == false)
        {
            throw new Exception($"return '{key}' is already in stack");
        }
    }

    public string PopReturn(string key)
    {
        if (_returns.Remove(key, out string value) == false)
        {
            throw new Exception($"return '{key}' was not found in stack.");
        }

        return value;
    }

    public string PopParameter(string key)
    {
        if (_parameters.Remove(key, out string value) == false)
        {
            throw new Exception($"parameter '{key}' was not found in stack.");
        }

        return value;
    }

    public void FinishProcedureReading()
    {
        if (_parameters.Count > 0)
        {
            throw new Exception("not all parameters were consumed");
        }

        if (_returns.Count > 0)
        {
            throw new Exception("not all returns were consumed");
        }
    }

    public string GetVariable(string key)
    {
        if (_variables.TryGetValue(key, out string value) == false)
        {
            throw new KeyNotFoundException($"Variable '{key}' is not defined.");
        }

        return value;
    }

    public string EvaluateString(ReadOnlySpan<char> value)
    {
        return _evaluator.Evaluate(this, value);
    }
}