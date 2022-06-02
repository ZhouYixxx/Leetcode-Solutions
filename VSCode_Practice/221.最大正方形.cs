/*
 * @lc app=leetcode.cn id=221 lang=csharp
 *
 * [221] 最大正方形
 */

// @lc code=start
public class Solution221 {
    public void Test()
    {
        var s = "[['1','0','1','0','0'],['1','0','1','1','1'],['1','1','1','1','1'],['1','0','0','1','0']]";
        var mat1 = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        int m = mat1.Length, n = mat1[0].Length;
        var mat = new char[m][];
        for (int i = 0; i < m; i++)
        {
            mat[i] = new char[n];
            for (int j = 0; j < n; j++)
            {
                mat[i][j] = (char)(mat1[i][j] + '0');
            }
        }
        var ans = MaximalSquare(mat);
    }

    public int MaximalSquare(char[][] matrix) {
        var m = matrix.Length; 
        var n = matrix[0].Length;
        var ans = 0;
        var dp = new int[m+1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n+1];
        }
        dp[1][1] = matrix[0][0] == '0' ? 0 : 1;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (matrix[i-1][j-1] != '1')
                {
                    dp[i][j] = 0;
                    continue;
                }
                dp[i][j] = Math.Min(Math.Min(dp[i-1][j-1], dp[i-1][j]), dp[i][j-1]) + 1;
                ans = Math.Max(dp[i][j]*dp[i][j], ans);
            }
        }
        return ans;
    }
}
// @lc code=end

