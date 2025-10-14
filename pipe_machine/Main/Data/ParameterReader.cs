using System.Runtime.CompilerServices;

namespace PipeMachine;

public struct ParameterReader
{
    public Stack stack;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string Read(string name)
    {
        return stack.PopParameter(name);
    }
}