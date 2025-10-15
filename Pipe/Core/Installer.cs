using Pipe.Core.Instruction;
using Pipe.Core.Procedure;

namespace Pipe.Core;

public class Installer : IInstaller
{
    public void Install(MachineBind bind)
    {
        bind.Instruction<Comment>('#');
        bind.Instruction<Variable>('$');
        bind.Instruction<Parameter>('@');
        bind.Instruction<Return>('>');

        bind.Procedure<CopyFile>("copy_file");
        bind.Procedure<DeleteFolder>("delete_folder");
        bind.Procedure<CopyFlattenFolder>("copy_flatten_folder");
        bind.Procedure<PrintLine>("print_line");
        bind.Procedure<ReadKey>("read_key");
        bind.Procedure<InstructionPrint>("instruction_print");
        bind.Procedure<GetRuntimePath>("get_runtime_path");
        bind.Procedure<RunPipeFile>("run_pipe_file");
    }
}