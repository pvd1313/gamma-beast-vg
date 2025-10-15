namespace Pipe.Core;

public struct MachineBind
{
    public IMachine machine;

    public void Installer<TInstaller>() where TInstaller : IInstaller, new()
    {
        IInstaller installer;

        try
        {
            installer = new TInstaller();
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during {typeof(TInstaller)}:new()", e);
        }

        try
        {
            installer.Install(this);
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during binding of {typeof(TInstaller)}", e);
        }
    }
    
    public void Procedure<TProcedure>(string id) where TProcedure : IProcedure, new()
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
            machine.InjectProcedure(instruction, id);
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during binding of {typeof(TProcedure)}", e);
        }
    }
    
    public void Instruction<TInstruction>(char id) where TInstruction : IInstruction, new()
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
            machine.InjectInstruction(instruction, id);
        }
        catch (Exception e)
        {
            throw new Exception($"Exception during binding of {typeof(TInstruction)}", e);
        }
    }
}