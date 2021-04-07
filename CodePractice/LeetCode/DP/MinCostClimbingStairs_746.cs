using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class MinCostClimbingStairs_746 : LeetCodeBase
    {
        public MinCostClimbingStairs_746() : base("MinCostClimbingStairs_746")
        {
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            var dp = new int[cost.Length+1];
            dp[0] = 0;
            dp[1] = 0;
            for (int i = 2; i < dp.Length; i++)
            {
                var cost1 = dp[i - 1] + cost[i - 1];
                var cost2 = dp[i - 2] + cost[i - 2];
                dp[i] = System.Math.Min(cost1, cost2);
            }
            return dp[dp.Length];
        }
    }
}