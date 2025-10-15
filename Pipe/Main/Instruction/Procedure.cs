namespace Pipe.Instruction;

public class Procedure : IInstruction
{
    private readonly Dictionary<string, IProcedure> _procedures;
    
    public Procedure()
    {
        _procedures = new Dictionary<string, IProcedure>();
    }

    public void Inject(IProcedure procedure, string id)
    {
        if (procedure == null) throw new ArgumentNullException(nameof(procedure));
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("id is empty");

        if (_procedures.TryAdd(id, procedure) == false)
        {
            throw new Exception("id is already bound: " + id);
        }
    }
    
    public void Run(Stack stack)
    {
        Arguments arguments = stack.ParseInstructionArguments(1);

        string procedureIndex = new (arguments[0]);

        if (_procedures.TryGetValue(procedureIndex, out IProcedure procedure) == false)
        {
            throw new Exception($"unknown procedure '{procedureIndex}'");
        }
        
        procedure.Read(new ProcedureReader
        {
            stack = stack
        });
        
        stack.FinishProcedureReading();

        procedure.Run(stack);
    }
}