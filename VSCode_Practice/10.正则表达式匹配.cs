/*
 * @lc app=leetcode.cn id=10 lang=csharp
 *
 * [10] 正则表达式匹配
 */

// @lc code=start
public class Solution010 {
    public void Test()
    {

    }

    public bool IsMatch(string s, string p) 
    {
        var dp = new bool[s.Length,p.Length];
        dp[0,0] = s[0] == p[0];
        return dp[s.Length-1,p.Length-1];
    }
}
// @lc code=end

