/*
 * @lc app=leetcode.cn id=227 lang=csharp
 *
 * [227] 基本计算器 II
 */

// @lc code=start
using System.Collections.Generic;

public class Solution227 {
    public void Test(){
        //var s = "(1+(4+5+2)-3)+(6+8)";
        var s = " 3/2 ";
        var ans = Calculate(s);
    }


    public int Calculate(string s) {
        var stack = new Stack<int>();
        char preOpt = '+';
        int num = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' && i != s.Length-1)
            {
                continue;
            }
            if (s[i] >= '0' && s[i] <= '9')
            {
                num = num * 10 + (s[i] - '0');
                if (i != s.Length -1)
                    continue;
            }
            switch (preOpt)
            {
                case '+':
                    stack.Push(num);
                    break;
                case '-':
                    stack.Push(-num);
                    break;
                case '*':
                    var mul = num * stack.Pop();
                    stack.Push(mul);
                    break;
                case '/':
                    var div = stack.Pop() / num ;
                    stack.Push(div);
                    break;
                default:
                    break;
            }
            if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
            {
                preOpt = s[i];
            }
            num = 0;
        }
        var ans = 0;
        while (stack.Count > 0)
        {
            ans += stack.Pop();
        }
        return ans;
    }

}
// @lc code=end

