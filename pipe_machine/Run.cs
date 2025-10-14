using PipeMachine;
using PipeMachine.Utility;

Machine machine = new();
FileSystem fileSystem = new();
Binder binder = new ();

Safe.Run("Boot failed.", () => machine.Boot(fileSystem));

Safe.Run("Binding failed.", () => binder.BindAll(machine));

Safe.Run("Runtime error.", () => machine.Run("C:/repo/beast_vg/pipe/deploy.pipe"));