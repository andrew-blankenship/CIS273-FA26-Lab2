namespace BalancedParentheses;

public class Program
{
    static void Main(string[] args)
    {
    }

    /// <summary>
    /// Write a method IsBalanced() that tests a string for balanced parentheses.
    /// The string is balanced when every opening parenthesis has a matching closing
    /// parenthesis of the same kind, and they are closed in the correct order.
    /// Your code must work for all four kinds: &lt; &gt;, { }, [ ], and ( ).
    /// Ignore any other characters in the string.
    /// </summary>
    /// <example>
    /// <code>
    /// IsBalanced("{ int a = new int[ ] ( ( ) ) }"); // true
    /// IsBalanced("{ () ) ) ( ( }");                 // false
    /// IsBalanced(" ( ( [ &lt; ] &gt; ) ) ");        // false (closed in the wrong order)
    /// IsBalanced(" ( ( [ ");                        // false (never closed)
    /// IsBalanced(" ] ");                            // false (nothing to close)
    /// </code>
    /// </example>
    /// <param name="s">The string to check. It may contain any characters.</param>
    /// <returns>true if the parentheses in <paramref name="s"/> are balanced; otherwise, false.</returns>
    public static bool IsBalanced(string s)
    {
        Stack<char> bal = new Stack<char>();
        // int a = 0;
        // int b = 0;
        // int c = 0;
        // int d = 0;
        foreach (char thing in s)
        {
            List<char> paren = new List<char>();
            paren = ['(', ')', '[', ']', '{', '}', '<', '>'];
            if (paren.Contains(thing) == false)
            {
                continue;
            }

            if (thing == '(' || thing == '[' || thing == '{' || thing == '<')
            {
                bal.Push(thing);
            }

            if (bal.Count == 0)
            {
                return false;
            }

            if (thing == ')')
            {
                char test = bal.Pop();
                if (test != '(')
                {
                    return false;
                }
            }

            if (thing == ']')
            {
                char test = bal.Pop();
                if (test != '[')
                {
                    return false;
                }
            }

            if (thing == '}')
            {
                char test = bal.Pop();
                if (test != '{')
                {
                    return false;
                }
            }

            if (thing == '>')
            {
                char test = bal.Pop();
                if (test != '<')
                {
                    return false;
                }
            }

        
        }

        if (bal.Count != 0)
        {
            return false;
        }
        

        // foreach (char thing in s)
        // {
        //     // if (b>0 && (b>0 || c>0 || d>0) && thing == '}')
        //     // {
        //     //     return false;
        //     // } 

        //     if (thing == '(')
        //     {
        //         a ++;
        //     }
        //     if (thing == '{')
        //     {
        //         b ++;
        //     }
        //     if (thing == '[')
        //     {
        //         c ++;
        //     }
        //     if (thing == '<')
        //     {
        //         d++;
        //     }
        //     if (thing == ')')
        //     {
        //         a --;
        //     }
        //     if (thing == '}')
        //     {
        //         b --;
        //     }
        //     if (thing == ']')
        //     {
        //         c --;
        //     }
        //     if (thing == '>')
        //     {
        //         d--;
        //     }

        //     if (a < 0 || b < 0 || c < 0 || d < 0)
        //     {
        //         return false;
        //     }
            
            
        // }
        // if (a !=0 || b!=0 || c != 0 || d != 0)
        // {
        //     return false;
        // }
        
        return true;
    }
}

