/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Solution70 {
    public void Test()
    {
        var n = 5;
        var ans = ClimbStairs(n);
    }

    public int ClimbStairs(int n) 
    {
        var dp = new int[n+1];
        dp[0] = 0;
        dp[1] = 1;
        if (n > 1)
        {
            dp[2] = 2;   
        }
        for (int i = 3; i < n+1; i++)
        {
            dp[i] = dp[i-1]+dp[i-2];
        }
        return dp[n];
    }
}
// @lc code=end

