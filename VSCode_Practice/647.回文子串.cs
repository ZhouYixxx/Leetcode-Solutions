/*
 * @lc app=leetcode.cn id=647 lang=csharp
 *
 * [647] 回文子串
 */

// @lc code=start

using System;
using System.Collections.Generic;
public class Solution647 {
    public void Test()
    {
        var s = "aaabbb";
        var ans = CountSubstrings(s);
    }

    public int CountSubstrings(string s) 
    {
        //dp[i][j] = true, 表示[i,j]为回文串
        // int count = 0;
        // var list = new List<string>();
        // var dp = new bool[s.Length][];
        // for (int j = 0; j < s.Length; j++)
        // {
        //     dp[j] = new bool[s.Length];
        //     for (int i = j; i >= 0; i--)
        //     {
        //         if (j - i == 0)
        //         {
        //             dp[i][j] = true;
        //             list.Add(s.Substring(i,j-i+1));
        //             count++;
        //         }
        //         else if (j - i == 1)
        //         {
        //             dp[i][j] = s[i] == s[j];
        //             if (dp[i][j])
        //             {
        //                 list.Add(s.Substring(i,j-i+1));
        //                 count++;
        //             }
        //         }
        //         // j - i >= 2
        //         else
        //         {
        //             dp[i][j] = s[i] == s[j] ? dp[i+1][j-1] : false;
        //             if (dp[i][j])
        //             {
        //                 list.Add(s.Substring(i,j-i+1));
        //                 count++;
        //             }
        //         }
        //     }
        // }

        // return count;

        //中心扩散法
        var count = 0;
        var list = new List<string>();
        for (int i = 0; i < s.Length*2-1; i++)
        {
            //中心落在s[i]上
            if ((i & 1) == 0)
            {
                var center = i/2;
                int left = center;
                int right = center;
                while (left >= 0 && right< s.Length)
                {
                    if (s[left] != s[right])
                        break;
                    list.Add(s.Substring(left, right-left+1));
                    count++;
                    left--;
                    right++;
                }
            }
            //中心落在s[i-1]和s[i]上
            else
            {
                var center = i/2+1;
                int left = center-1;
                int right = center;
                while (left >= 0 && right< s.Length)
                {
                    if (s[left] != s[right])
                        break;
                    list.Add(s.Substring(left, right-left+1));
                    count++;
                    left--;
                    right++;
                }
            }
        }
        return count;
    }
}
// @lc code=end

