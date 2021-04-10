using System;
using System.Collections.Generic;
using CodePractice.Core;

namespace CodePractice.LeetCode.Stack_Quene
{
    public class ValidParentheses_20 : LeetCodeBase
    {
        public ValidParentheses_20() : base("ValidParentheses_20")
        {
            var s = "{[(]}";
            Console.WriteLine(IsValid(s));
            Console.ReadKey();
        }

        public bool IsValid(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                    continue;
                }
                if (stack.Count == 0)
                {
                    return false;
                }
                var ch1 = stack.Pop();
                if (ch1 == '(' && ch != ')')
                {
                    return false;
                }
                if (ch1 == '[' && ch != ']')
                {
                    return false;
                }
                if (ch1 == '{' && ch != '}')
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
    }
}