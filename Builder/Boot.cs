using Builder;
using Builder.Pipe;

PipeMachine machine = new ();
PipeBinder binder = new ();
PipeFileSystem fileSystem = new();

Safe.Run("boot machine", () => machine.Boot(fileSystem));

Safe.Run("install bindings", () => binder.BindAll(machine));

List<SerializedCommand> commands = new()
{
    CopyFileCommand.Serialize(@"C:\download\1.txt", @"C:\download\2.txt")
};

Safe.Run("run machine", () => machine.Run(commands));

Console.WriteLine("All done.");