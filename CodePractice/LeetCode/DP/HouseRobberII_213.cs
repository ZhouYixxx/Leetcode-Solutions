using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class HouseRobberII_213 : LeetCodeBase
    {
        public HouseRobberII_213() : base("HouseRobberII_213")
        {
            var nums = new int[] { 5, 2, 3, 1,6,10,7 };
            Console.WriteLine(Rob(nums));
            Console.ReadKey();
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return nums[0] > nums[1] ? nums[0] : nums[1];
            var dp1 = new int[nums.Length - 1];
            var dp2 = new int[nums.Length - 1];
            dp1[0] = nums[0];
            dp1[1] = nums[0] > nums[1] ? nums[0] : nums[1];

            dp2[0] = nums[1];
            dp2[1] = nums[2] > nums[1] ? nums[2] : nums[1];
            for (int i = 2; i < dp1.Length; i++)
            {
                dp1[i] = System.Math.Max(dp1[i - 1], dp1[i - 2] + nums[i]);
                dp2[i] = System.Math.Max(dp2[i - 1], dp2[i - 2] + nums[i+1]);
            }
            return System.Math.Max(dp1[dp1.Length - 1], dp2[dp2.Length - 1]);
        }
    }
}