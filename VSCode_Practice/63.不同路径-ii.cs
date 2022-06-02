/*
 * @lc app=leetcode.cn id=63 lang=csharp
 *
 * [63] 不同路径 II
 */

// @lc code=start
public class Solution63 {
    public void Test()
    {
        var s = "[[0,0,0,0],[0,0,1,0],[0,0,0,0]]";
        var mat1 = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var ans = UniquePathsWithObstacles(mat1);
    }

    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        var dp = new int[m+1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n+1];
        }
        dp[1][1] = obstacleGrid[0][0] == 1 ? 0 : 1;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == 1 && j == 1)
                {
                    continue;
                }
                if (obstacleGrid[i-1][j-1] == 1)
                {
                    dp[i][j] = 0;
                    continue;
                }
                dp[i][j] = dp[i-1][j] + dp[i][j-1];
            }
        }
        return dp[m][n];
    }

}
// @lc code=end

