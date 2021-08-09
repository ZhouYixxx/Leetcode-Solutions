/*
 * @lc app=leetcode.cn id=10 lang=csharp
 *
 * [10] 正则表达式匹配
 */

// @lc code=start
public class Solution010 {
    public void Test()
    {
        var s = "mississippi";
        var p = "mis*is*.p*.";
        var ans = IsMatch(s,p);
    }

    public bool IsMatch(string s , string p)
    {
        var dp = new bool[s.Length+1,p.Length+1];
        dp[0,0] = true;
        // for (int i = 1; i < s.Length; i++)
        // {
        //     dp[i,0] = false;
        // }
        for (int i = 2; i <= p.Length; i++)
        {
            dp[0,i] = p[i-1] == '*' && dp[0,i-2];
        }
        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= p.Length; j++)
            {
                //情况1
                if (s[i-1] == p[j-1] || p[j-1] == '.')
                {
                    dp[i,j] = dp[i-1,j-1];
                    continue;
                }
                //情况2
                if (p[j-1] == '*')
                {
                    //情况2.1
                    if (p[j-2] == s[i-1] || p[j-2] == '.')
                    {
                        dp[i,j] = j < 2 ? (dp[i-1,j] || dp[i,j-1]) : (dp[i-1,j] || dp[i,j-1] || dp[i,j-2]);
                    }
                    //情况2.2
                    else
                    {
                        dp[i,j] = j < 2 ? false : dp[i,j-2]; 
                    }
                }
            }
        }
        return dp[s.Length,p.Length];
    }
}
// @lc code=end

