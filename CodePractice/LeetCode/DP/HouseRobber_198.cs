using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class HouseRobber_198 : LeetCodeBase
    {
        public HouseRobber_198() : base("HouseRobber_198")
        {
            var nums = new int[] { 5, 4, 16, 10, 1, 5, 12, 3, 9 };
            Console.WriteLine(Rob(nums));
            Console.ReadKey();
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = nums[1] > nums[0] ? nums[1] : nums[0];
            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = System.Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[nums.Length - 1];
        }
    }
}