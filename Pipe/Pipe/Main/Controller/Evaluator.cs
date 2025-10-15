using System.Text;

namespace Pipe;

public struct Evaluator
{
    private StringBuilder _stringBuilder;
    
    public static Evaluator Create()
    {
        return new Evaluator
        {
            _stringBuilder = new StringBuilder()
        };
    }
    
    public string Evaluate(Stack stack, ReadOnlySpan<char> input)
    {
        _stringBuilder.Clear();
        
        int i = 0;

        while (i < input.Length)
        {
            if (input[i] == '$')
            {
                i++;

                int start = i;
                
                while (i < input.Length && input[i] != '$')
                {
                    i++;
                }

                if (i >= input.Length)
                {
                    throw new FormatException($"Unterminated variable");
                }

                string variableName = input[start .. i].ToString();

                string value = stack.GetVariable(variableName);
                
                _stringBuilder.Append(value);
            }
            else
            {
                _stringBuilder.Append(input[i]);
            }

            i++;
        }

        return _stringBuilder.ToString();
    }
}