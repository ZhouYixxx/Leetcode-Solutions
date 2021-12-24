using System;
using System.Text;
using System.Collections.Generic;

public class Solution_Offer58
{
    public void Test()
    {
        var s = "the sky is blue";
        var ans = ReverseWords(s);
    }

    public string ReverseWords(string s) 
    {
        return ReverseWords_Stack(s);
    }

    /// <summary>
    /// 栈
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private string ReverseWords_Stack(string s)
    {
        var sb = new StringBuilder();
        var stack = new Stack<char>();
        for (int i = s.Length-1; i >= 0; i--)
        {
            if (s[i] == ' ' || i == 0)
            {
                if (s[i] != ' ')
                {
                    stack.Push(s[i]);
                }
                bool flag = stack.Count > 0;
                while (stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }
                if (flag)
                {
                    sb.Append(' ');
                }
            }
            else
            {
                stack.Push(s[i]);   
            }
        }
        if (sb.Length > 0)
        {
            sb.Remove(sb.Length-1,1);   
        }
        return sb.ToString();

    }
}