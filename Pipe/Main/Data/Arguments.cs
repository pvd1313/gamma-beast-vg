namespace Pipe;

public ref struct Arguments
{
    private const int MAX_PARAMETER_COUNT = 5;

    private int _parameterCount;
    private ReadOnlySpan<char> _param0;
    private ReadOnlySpan<char> _param1;
    private ReadOnlySpan<char> _param2;
    private ReadOnlySpan<char> _param3;
    private ReadOnlySpan<char> _param4;

    public static Arguments Parse(string instruction, int parameterCount)
    {
        if (parameterCount < 0 || parameterCount >= MAX_PARAMETER_COUNT)
        {
            throw new ArgumentException(nameof(parameterCount));
        }

        Arguments result = default;
        
        ReadOnlySpan<char> text = instruction.AsSpan();
        
        int pos = 1;
        int parameterIndex = 0;

        while (true)
        {
            bool hasWord = _nextWord(text, ref pos, out int start, out int end);

            if (hasWord == false)
            {
                break;
            }

            if (parameterIndex > parameterCount)
            {
                throw new Exception("Too many parameters");
            }

            result._setParameter(text[start .. end], parameterIndex);

            parameterIndex++;
        }

        if (parameterIndex != parameterCount)
        {
            throw new Exception("Invalid parameter count");
        }

        result._parameterCount = parameterIndex;

        return result;
    }

    private void _setParameter(ReadOnlySpan<char> span, int index)
    {
        if (index < 0 || index >= MAX_PARAMETER_COUNT) throw new IndexOutOfRangeException();
        
        switch (index)
        {
            case 0: _param0 = span; break;
            case 1: _param1 = span; break;
            case 2: _param2 = span; break;
            case 3: _param3 = span; break;
            case 4: _param4 = span; break;
            
            default: throw new Exception();
        }
    }

    public ReadOnlySpan<char> this[int index]
    {
        get
        {
            if (index < 0 || index >= _parameterCount) throw new IndexOutOfRangeException();

            switch (index)
            {
                case 0: return _param0;
                case 1: return _param1;
                case 2: return _param2;
                case 3: return _param3;
                case 4: return _param4;
            
                default: throw new Exception();
            }
        }
    }

    private static bool _nextWord(ReadOnlySpan<char> text, ref int pos, out int start, out int end)
    {
        start = -1;
        end = -1;

        // Skip leading whitespace.
        while (pos < text.Length && char.IsWhiteSpace(text[pos]))
        {
            pos++;
        }
        
        // Only white spaces or comment.
        if (pos >= text.Length || text[pos] == '#')
        {
            return false;
        }

        // Check if the word is quoted
        bool isQuoted = (text[pos] == '"' || text[pos] == '\'');
        
        if (isQuoted)
        {
            char quoteChar = text[pos];
            
            // Skip opening quote
            pos++; 
            
            start = pos;

            // Find the closing quote
            while (pos < text.Length && text[pos] != quoteChar)
            {
                pos++;
            }

            if (pos >= text.Length)
            {
                throw new FormatException($"Unterminated variable at position {start}");
            }

            end = pos;

            pos++;
            
            return true;
        }

        // Otherwise, parse until next whitespace
        start = pos;
        
        while (pos < text.Length && !char.IsWhiteSpace(text[pos]))
        {
            pos++;
        }

        end = pos;

        return true;
    }
}