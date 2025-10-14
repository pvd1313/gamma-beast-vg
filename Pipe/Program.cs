using Pipe;
using Pipe.Utility;

if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
{
    Context.Terminate(".pipe file not provided.");
}

Machine machine = new();
FileSystem fileSystem = new();
Binder binder = new ();

Context.Run("Boot failed.", () => machine.Boot(fileSystem));

Context.Run("Binding failed.", () => binder.BindAll(machine));

Context.Run("Runtime error.", () => machine.Run(args[0]));