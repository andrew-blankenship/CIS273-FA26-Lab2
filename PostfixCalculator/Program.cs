namespace PostfixCalculator;


public class Program
{
    public static Stack<double> nums = new Stack<double>();

    public static void Main(string[] args)
    {

    }

    /// <summary>
    /// Evaluates a mathematical expression written in postfix notation
    /// (also called Reverse Polish Notation) and returns its value.
    /// If the expression cannot be evaluated, returns null.
    /// </summary>
    /// <remarks>
    /// In postfix notation each operator comes AFTER its two operands,
    /// so no parentheses are needed:
    /// <code>
    /// Infix:   (2 + 6) * 3
    /// Postfix: 2 6 + 3 *        // (2 + 6) * 3 = 24
    /// </code>
    /// Rules:
    /// <list type="bullet">
    /// <item><description>
    /// Operands (numbers) and operators are separated by whitespace. There may be more than
    /// one whitespace digit.ToString() between tokens, and spaces, tabs, and newlines all count.
    /// </description></item>
    /// <item><description>The supported operators are +, -, *, and /.</description></item>
    /// <item><description>
    /// Operands may be negative or have decimals, such as -3 or 2.5. A "-" by itself is
    /// the subtraction operator; a "-" followed by digits is part of a negative number.
    /// </description></item>
    /// <item><description>You may assume every token is a legal number or operator.</description></item>
    /// <item><description>
    /// Division by zero follows normal C# double rules, so it is NOT an error:
    /// a nonzero number divided by 0 gives Infinity or -Infinity, and 0 / 0 gives NaN.
    /// </description></item>
    /// <item><description>
    /// The expression is not evaluable, and the method returns null, when it is empty or only
    /// whitespace, when an operator does not have two operands available, or when numbers
    /// are left over at the end.
    /// </description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// Evaluate("5 3 +");                            // 8
    /// Evaluate("7 5 -");                            // 2
    /// Evaluate("5 3 1 + -");                        // 1
    /// Evaluate("15 7 1 1 + - / 3 * 2 1 1 + + -");   // 5
    /// Evaluate("3");                                // 3
    /// Evaluate("2 6 + 3  *");                       // 24 (extra spaces are fine)
    /// Evaluate("-3 2 +");                           // -1
    /// Evaluate("1 0 /");                            // Infinity
    /// Evaluate("0 0 /");                            // NaN
    /// Evaluate("1 + + -");                          // null (not enough operands)
    /// Evaluate("1 -");                              // null (not enough operands)
    /// Evaluate("-");                                // null (not enough operands)
    /// Evaluate("");                                 // null (empty)
    /// Evaluate("   ");                              // null (only whitespace)
    /// Evaluate("3 4 5 6 7 8 ");                     // null (numbers left over)
    /// </code>
    /// </example>
    /// <param name="s">A postfix expression whose tokens are separated by whitespace.</param>
    /// <returns>The value of the expression, or null if it cannot be evaluated.</returns>
    public static double? Evaluate(string s)
    {
        if (s.Replace(" ", "") == "")
        {
            return null;
        }
        s = s.Trim();
        s = s.Replace("  ", " ");
        
        string[] words = s.Split(null);

        


        foreach (string thing in words)
        {
            if (thing == "+" || thing == "-" || thing == "*" || thing == "/")
            {
                if (nums.Count < 2)
                {
                    nums.Clear();
                    return null;
                }
                if (nums.Count >= 2)
                {
                    double a = nums.Pop();
                    double b = nums.Pop();

                    if (thing == "+")
                    {
                        double digit = b+a;
                

                        nums.Push(digit);
                    }
                    if (thing == "-")
                    {
                        double digit = b-a;
                        

                        nums.Push(digit);
                    }
                    if (thing == "*")
                    {
                        double digit = b*a;
                        

                        nums.Push(digit);
                    }
                    if (thing == "/")
                    {
                        if (a == 0)
                        {
                            if (b > 0)
                            {
                                return double.PositiveInfinity;
                                
                            }
                            if (b < 0)
                            {
                                return double.NegativeInfinity;
                                
                            }
                            if (b == 0)
                            {
                                return double.NaN;
                            }
                        }
                        double digit = b/a;

                        nums.Push(digit);
                    }
                }
                
        
            }
            else if (thing == " ")
            {
                continue;
            }
            else
            {
                double num = double.Parse(thing);
                nums.Push(num);
            }
        }
        if (nums.Count > 1)
        {
            nums.Clear();
            return null;
            
        }
        return nums.Pop();
    }
}

