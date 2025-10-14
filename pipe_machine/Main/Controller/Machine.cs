namespace PipeMachine;

public class Machine : IMachine
{
    private const int INSTRUCTION_LIMIT = 256;

    private IInstruction[] _instructions;
    private IFileSystem _fileSystem;
    private byte _isBooted;

    public void Boot(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        _instructions = new IInstruction [INSTRUCTION_LIMIT];
        _fileSystem = fileSystem;

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

    public void Run(string filePath)
    {
        if (_isBooted == 0) throw new InvalidOperationException("machine is not booted");

        Stack stack = Stack.Create();
        
        using TextReader reader = File.OpenText(filePath);

        stack.SetFileSystem(_fileSystem);

        string row = string.Empty;
        int rowIndex = 1;

        try
        {
            for (; row != null; rowIndex++)
            {
                row = reader.ReadLine();

                if (string.IsNullOrEmpty(row))
                {
                    continue;
                }

                int instructionIndex = row[0];

                IInstruction instruction = _instructions[instructionIndex];

                if (instruction == null)
                {
                    throw new Exception("Instruction is not bound: " + instructionIndex);
                }

                stack.SetInstruction(row);

                if (stack.GetConfig().instructionPrintEnabled)
                {
                    Console.WriteLine(row);
                }

                instruction.Run(stack);
            }
        }
        catch (Exception exception)
        {
            throw new Exception($"[{rowIndex}] {row}", exception);
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