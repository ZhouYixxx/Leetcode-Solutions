/*
 * @lc app=leetcode.cn id=91 lang=csharp
 *
 * [91] 解码方法
 */

// @lc code=start
using System;

public class Solution91 {
    public void Test()
    {
        var s = "230";
        var ans = NumDecodings(s);
    }

    public int NumDecodings(string s) 
    {
        if (s[0] == '0')
        {
            return 0;
        }
        if (s.Length == 1)
        {
            return s.Length;
        }
        //dp[i], 表示[0,i]范围内的解码方法的数量
        var dp = new int[s.Length];
        dp[0] = 1;
        var temp = (s[0]-'0')*10+s[1]-'0';
        if (s[1] == '0')
        {
            if (temp > 26)
                return 0;
            dp[1] = 1;
        }
        else
        {
            dp[1] = temp > 26 ? 1 : 2;
        }

        for (int i = 2; i < dp.Length; i++)
        {
            var tail = (s[i-1]-'0')*10+s[i]-'0';
            if (tail > 26 || tail < 10)
            {
                if (s[i] == '0')
                {
                    return 0;
                }
                dp[i] = dp[i-1];
            }
            else 
            {
                if (s[i] == '0')
                {
                    dp[i] = dp[i-2];
                }
                else
                {
                    dp[i] = dp[i-1]+ dp[i-2];   
                }
            }
        }
        return dp[dp.Length-1];
    }
}
// @lc code=end

