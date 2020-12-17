using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class UniquePaths_62 : LeetCodeBase
    {
        public UniquePaths_62() : base("UniquePaths_62")
        {
        }

        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1)
            {
                return 1;
            }
            int[][] dp = new int[m][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n];
            }

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i][0] = 1;
            }
            for (int i = 0; i < dp[0].Length; i++)
            {
                dp[0][i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1]; 
                }
            }
            return dp[m - 1][n - 1];
        }
    }
}