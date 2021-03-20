using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class MaxProduct_152 : LeetCodeBase
    {
        public MaxProduct_152() : base("MaxProduct_152")
        {
            var nums = new int[] { 2, 3,-1,2, 4 };
            Console.WriteLine(MaxProduct(nums));
            Console.ReadKey();
        }

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            var minDp = new int[nums.Length];
            var maxDp = new int[nums.Length];
            minDp[0] = nums[0];
            maxDp[0] = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                minDp[i] = System.Math.Min(System.Math.Min(maxDp[i - 1] * nums[i], nums[i]), minDp[i - 1] * nums[i]);
                maxDp[i] = System.Math.Max(System.Math.Max(minDp[i - 1] * nums[i], nums[i]), maxDp[i - 1] * nums[i]);
                if (max < maxDp[i])
                    max = maxDp[i];
            }
            return max;
        }
    }
}