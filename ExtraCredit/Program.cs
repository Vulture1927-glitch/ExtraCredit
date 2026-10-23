using System.Security.Cryptography.X509Certificates;

public class Program
{
    static void Main()
    {
        Console.WriteLine(IsBalanced("(){}[]").ToString()); // true
        Console.WriteLine(IsBalanced("({[]})").ToString()); // true
        Console.WriteLine(IsBalanced("({[})").ToString()); // false
    }
    public static bool IsBalanced(string s)
    {
        int balance = 0;
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
                balance++;
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char top = stack.Pop();
                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                {
                    return false;
                }
                balance--;
            }
        }
        return balance == 0;
    }

    public static int TimeToBuy(int[] tickets, int k)
    {
        int time = 0;
        int n = tickets.Length;
        for (int i = 0; i < n; i++)
        {
            if (i <= k)
            {
                time += Math.Min(tickets[i], tickets[k]);
            }
            else
            {
                time += Math.Min(tickets[i], tickets[k] - 1);
            }
        }
        return time;
    }
}
