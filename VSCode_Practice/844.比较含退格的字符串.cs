/*
 * @lc app=leetcode.cn id=844 lang=csharp
 *
 * [844] 比较含退格的字符串
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution844 
{
    public void Test()
    {
        var s = "bxj##tw";
        var t = "bxj###tw";
        var ans = BackspaceCompare3(s,t);
    }

    /// <summary>
    /// 双栈法
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool BackspaceCompare1(string s, string t) 
    {
        var stack1 = new Stack<int>();
        var stack2 = new Stack<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '#')
            {
                if (stack1.Count > 0)
                {
                    stack1.Pop();
                }    
            }
            else
            {
                stack1.Push(s[i]);
            }
        }
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == '#')
            {
                if (stack2.Count > 0)
                {
                    stack2.Pop();
                }    
            }
            else
            {
                stack2.Push(t[i]);
            }
        }
        if (stack1.Count != stack2.Count)
        {
            return false;
        }
        while (stack1.Count > 0)
        {
            var ch1 = stack1.Pop();
            var ch2 = stack2.Pop();
            if (ch1 != ch2)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 双指针法
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool BackspaceCompare(string s, string t) 
    {
        int skipCount1 = 0, skipCount2 = 0;
        int index1 = s.Length-1, index2 = t.Length-1;
        while (index1 >= 0 || index2 >= 0)
        {
            while (index1 >= 0)
            {
                if (s[index1] == '#')
                {
                    skipCount1++;
                    index1--;
                }
                else
                {
                    if (skipCount1 == 0)
                    {
                        break;
                    }
                    else
                    {
                        skipCount1--;
                        index1--;
                    }
                }    
            }
            while (index2 >= 0)
            {
                if (t[index2] == '#')
                {
                    skipCount2++;
                    index2--;
                }
                else
                {
                    if (skipCount2 == 0)
                    {
                        break;
                    }
                    else
                    {
                        skipCount2--;
                        index2--;
                    }
                } 
            }
            if (index1 >= 0 && index2 >= 0)
            {
                if (s[index1] != t[index2])
                {
                    return false;
                }
            }
            else
            {
                if (index1 >= 0 || index2 >= 0)
                {
                    return false;
                }
            }
            index1--;
            index2--;
        }
        return true;
    }

    public bool BackspaceCompare3(string s, string t)
    {
        int slow1 = 0, fast1 = 0;
        int slow2 = 0, fast2 = 0;
        var sCharArray = s.ToCharArray();
        var tCharArray = t.ToCharArray();
        while (fast1 < s.Length)
        {
            if (s[fast1] != '#')
            {
                sCharArray[slow1++] = s[fast1];
            }
            else
            {
                if (slow1 > 0)
                {
                    slow1--;
                }
            }
            fast1++;
        }
        while (fast2 < t.Length)
        {
            if (t[fast2] != '#')
            {
                tCharArray[slow2++] = t[fast2];
            }
            else
            {
                if (slow2 > 0)
                {
                    slow2--;
                }
            }
            fast2++;
        }
        if (slow1 != slow2)
        {
            return false;
        }
        for (int i = 0; i < slow1; i++)
        {
            if (sCharArray[i] != tCharArray[i])
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

