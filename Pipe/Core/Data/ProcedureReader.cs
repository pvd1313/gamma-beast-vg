using System.Runtime.CompilerServices;

namespace Pipe.Core;

public struct ProcedureReader
{
    public Stack stack;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ReadParameter(string name)
    {
        return stack.PopParameter(name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ReadReturn(string name)
    {
        return stack.PopReturn(name);
    }
}