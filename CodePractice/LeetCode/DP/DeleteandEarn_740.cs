using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class DeleteandEarn_740 : LeetCodeBase
    {
        public DeleteandEarn_740() : base("DeleteandEarn_740")
        {
            var nums = new int[] { 4, 10, 10, 8, 1, 4, 10, 9, 7, 6 };
            Console.WriteLine(DeleteAndEarn(nums));
            Console.ReadKey();
        }

        public int DeleteAndEarn(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            var nums1 = new int[10000];
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (max < nums[i])
                    max = nums[i];
                nums1[nums[i] - 1] += 1;
            }
            var dp = new int[max];
            dp[0] = nums1[0] * 1;
            dp[1] = nums1[0] * 1 > nums1[1] * 2 ? nums1[0] * 1 : nums1[1] * 2;
            for (int i = 2; i < max; i++)
            {
                dp[i] = System.Math.Max(dp[i - 1], dp[i - 2] + nums1[i] * (i + 1));
            }
            return dp[max - 1];
        }
    }
}