using PipeMachine.Instruction;
using PipeMachine.Procedure;

namespace PipeMachine;

public class Binder
{
    private IMachine _machine;
    private Instruction.Procedure _procedure;

    public void BindAll(IMachine machine)
    {
        ArgumentNullException.ThrowIfNull(machine);

        _machine = machine;
        
        _bindInstruction<Comment>('#');
        _bindInstruction<Variable>('$');
        _bindInstruction<Parameter>('@');

        _procedure = new Instruction.Procedure();
        _bindProcedure<CopyFile>("copy_file");
        _bindProcedure<DeleteFolder>("delete_folder");
        _bindProcedure<CopyFlattenFolder>("copy_flatten_folder");
        _bindProcedure<PrintLine>("print_line");
        _bindProcedure<ReadKey>("read_key");
        _bindProcedure<InstructionPrint>("instruction_print");

        _machine.Inject(_procedure, '.');
    }

    private void _bindProcedure<TProcedure>(string id) 
        where TProcedure : IProcedure, new()
    {
        IProcedure instruction;

        try
        {
            instruction = new TProcedure();
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during {typeof(TProcedure)}:new()", e);
        }

        try
        {
            _procedure.Inject(instruction, id);
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during binding of '{typeof(TProcedure)}'", e);
        }
    }

    private void _bindInstruction<TInstruction>(char id) 
        where TInstruction : IInstruction, new()
    {
        IInstruction instruction;

        try
        {
            instruction = new TInstruction();
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during {typeof(TInstruction)}:new()", e);
        }

        try
        {
            _machine.Inject(instruction, id);
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during binding of '{typeof(TInstruction)}'", e);
        }
    }
}