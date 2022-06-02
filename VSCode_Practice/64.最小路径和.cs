/*
 * @lc app=leetcode.cn id=64 lang=csharp
 *
 * [64] 最小路径和
 */

// @lc code=start
public class Solution64 {

    public void Test()
    {
        var s = "[[1,3,1],[1,5,1],[4,2,1]]";
        var mat1 = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var ans = MinPathSum(mat1);
    }

    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        var dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }
        // for (int i = 0; i <= m; i++)
        // {
        //     dp[i][0] = 100000;
        // }
        // for (int i = 0; i <= n; i++)
        // {
        //     dp[0][i] = 100000;
        // }
        dp[0][0] = grid[0][0];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                if (i == 0)
                {
                    dp[i][j] = dp[i][j-1] + grid[i][j];
                }
                else if (j == 0)
                {
                    dp[i][j] = dp[i-1][j] + grid[i][j];
                }
                else
                {
                    dp[i][j] = Math.Min(dp[i-1][j], dp[i][j-1]) + grid[i][j];   
                }
            }
        }
        return dp[m-1][n-1];
    }
}
// @lc code=end

