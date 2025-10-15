using Pipe.Core;
using Pipe.Utility;

if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
{
    Context.Terminate(".pipe file not provided.");
}

Machine machine = new();
FileSystem fileSystem = new();

Context.Run("Boot failed.", () => machine.Boot(fileSystem));

MachineBind bind = new ()
{
    machine = machine
};

Context.Run("Binding installation failed.", () =>
{
    bind.Installer<Installer>();
});

Context.Run("Runtime error.", () => machine.Run(args[0]));