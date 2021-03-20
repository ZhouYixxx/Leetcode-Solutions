/*
 * @lc app=leetcode.cn id=132 lang=csharp
 *
 * [132] 分割回文串 II
 */

// @lc code=start
public class Solution132 {
    public void Test()
    {
        var s = "aab";
        var ans = MinCut(s);
    }

    public int MinCut(string s) 
    {
        var memo = Pretreatment(s);
        var dp = new int[s.Length];
        dp[0] = 0;
        for (int i = 1; i < dp.Length; i++)
        {
            if (memo[0][i])
            {
                dp[i] = 0;
                continue;
            }
            dp[i] = dp[i-1]+1;
            for (int j = i-1; j >= 0; j--)
            {
                if (memo[j][i] && (dp[j-1]+1) < dp[i])
                {
                    dp[i] = dp[j-1]+1;
                }
            }
        }
        return dp[dp.Length-1];
    }

    //用DP记录所有回文子串
    private bool[][] Pretreatment(string s)
    {
        var ans = new bool[s.Length][];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = new bool[s.Length];
            for (int j = i; j >= 0; j--)
            {
                // if (i - j == 0)
                // {
                //     ans[j][i] = true;
                //     continue;
                // }
                if (i - j <= 2)
                {
                    ans[j][i] = s[i] == s[j];
                    continue;
                }
                ans[j][i] = s[i] == s[j] && ans[j+1][i-1];
            }
        }
        return ans;
    }
}
// @lc code=end

