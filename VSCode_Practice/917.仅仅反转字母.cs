/*
 * @lc app=leetcode.cn id=917 lang=csharp
 *
 * [917] 仅仅反转字母
 */

// @lc code=start
using System.Collections.Generic;

public class Solution917 {
    public void Test(){
        var s = "ab-cd";
        var ans = ReverseOnlyLetters(s);
    }

    /// <summary>
    /// 使用栈
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseOnlyLetters1(string s) {
        var stack = new Stack<char>();
        var chars = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (isLetter(c))
            {
                stack.Push(s[i]);
            }
            else
            {
                chars[i] = s[i];
            }
        }
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (isLetter(c))
            {
               chars[i] = stack.Pop(); 
            }
        }
        return new string(chars);
    }

    /// <summary>
    /// 双指针
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseOnlyLetters(string s) {
        var chars = new char[s.Length];
        int l = 0, r = s.Length-1;
        while (l <= r)
        {
            var l_ch = s[l];
            var r_ch = s[r];
            if (!isLetter(l_ch))
            {
                chars[l] = s[l++];
                continue;
                // chars[l] = s[l];
                // l_ch = s[++l];
            }
            if (!isLetter(r_ch))
            {
                chars[r] = s[r--];
                continue;
                // chars[r] = s[r];
                // r_ch = s[--r];
            }
            chars[l] = r_ch;
            chars[r] = l_ch;
            l++;
            r--;
        }
        return new string(chars);
    }

    private bool isLetter(char c)
    {
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
    }

}
// @lc code=end

