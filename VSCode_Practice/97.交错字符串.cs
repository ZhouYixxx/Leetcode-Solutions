/*
 * @lc app=leetcode.cn id=97 lang=csharp
 *
 * [97] 交错字符串
 */

// @lc code=start
public class Solution97 {
    public void Test()
    {
        var s1 = "aabcc";
        var s2 = "dbbca";
        var s3 = "aadbbcbcac";
        var ans = IsInterleave(s1, s2, s3);
    }

    public bool IsInterleave(string s1, string s2, string s3) {
        if (s3.Length != s1.Length + s2.Length)
        {
            return false;
        }
        var m = s1.Length;
        var n = s2.Length;
        //DP Init 
        var dp = new bool[m+1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new bool[n+1];
        }
        for (int i = 1; i <= m; i++)
        {
            if (s1[i-1] != s3[i-1])
            {
                break;
            }
            dp[i][0] = true;
        }
        for (int j = 1; j <= n; j++)
        {
            if (s2[j-1] != s3[j-1])
            {
                break;
            }
            dp[0][j] = true;
        }
        dp[0][0] = true;
        //递推公式
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i][j] = (dp[i-1][j] && s1[i-1] == s3[i+j-1]) || (dp[i][j-1] && s2[j-1] == s3[i+j-1]);
            }
        }
        return dp[m][n];
    }
}
// @lc code=end

