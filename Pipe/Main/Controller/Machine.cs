using System.Text;

namespace Pipe;

public class Machine : IMachine
{
    private const int INSTRUCTION_LIMIT = 256;

    private IInstruction[] _instructions;
    private IFileSystem _fileSystem;
    private Stack _stack;
    private byte _isBooted;

    public void Boot(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        _instructions = new IInstruction [INSTRUCTION_LIMIT];
        _fileSystem = fileSystem;
        _stack = Stack.Create(_fileSystem, this);

        _isBooted = 1;
    }

    public void Inject(IInstruction instruction, int instructionIndex)
    {
        if (_isBooted == 0) throw new InvalidOperationException("machine is not booted");

        ArgumentNullException.ThrowIfNull(instruction);

        _validateInstructionIndex(instructionIndex);

        if (_instructions[instructionIndex] != null)
        {
            throw new InvalidOperationException($"instruction is already bound: {instructionIndex}");
        }

        _instructions[instructionIndex] = instruction;
    }

    public void Run(string pipeFilePath)
    {
        if (_isBooted == 0) throw new InvalidOperationException("machine is not booted");
        
        string[] lines = File.ReadAllLines(pipeFilePath);

        string pipeAbsolute = Path.GetFullPath(pipeFilePath);
        string pipeFolder = Path.GetDirectoryName(pipeAbsolute);
        _stack.PushRuntimePath(pipeFolder);
        
        string row = string.Empty;
        int rowIndex = 0;

        try
        {
            for (; rowIndex < lines.Length; rowIndex++)
            {
                row = lines[rowIndex];

                if (string.IsNullOrEmpty(row))
                {
                    if (_stack.GetConfig().instructionPrintEnabled)
                    {
                        Console.WriteLine();
                    }
                    
                    continue;
                }

                int instructionIndex = row[0];

                IInstruction instruction = _instructions[instructionIndex];

                if (instruction == null)
                {
                    throw new Exception($"Unknown instruction: {instructionIndex} '{(char)instructionIndex}'");
                }

                _stack.SetInstruction(row);

                if (_stack.GetConfig().instructionPrintEnabled)
                {
                    Console.WriteLine(row);
                }

                instruction.Run(_stack);
            }

            _stack.PopRuntimePath();
        }
        catch (Exception exception)
        {
            StringBuilder builder = new ();

            builder.AppendLine();

            builder.AppendLine(pipeFilePath);

            builder.AppendLine("...");

            builder.Append('[');

            builder.Append(rowIndex + 1);

            builder.Append("] ");

            builder.AppendLine(row);

            builder.AppendLine("...");
            
            throw new Exception(builder.ToString(), exception);
        }
    }

    private static void _validateInstructionIndex(int instruction)
    {
        if (instruction <= 0 || instruction >= INSTRUCTION_LIMIT)
        {
            throw new ArgumentException($"invalid instruction index '{instruction}'.");
        }
    }
}