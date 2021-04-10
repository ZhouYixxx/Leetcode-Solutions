using System.Collections.Generic;
using System.Globalization;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class LargestDivisibleSubset_368 : LeetCodeBase
    {
        public LargestDivisibleSubset_368() : base("LargestDivisibleSubset_368")
        {
            var nums = new int[] {2,3,4,8,9,27};
            var ans = LargestDivisibleSubset(nums);
        }

        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            System.Array.Sort(nums);
            var dp = new List<int>[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new List<int>(){nums[i]};
            }
            var maxLen = 1;
            int ans = 0;
            //dp[0].Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                int max = 0;
                for (int j = i-1; j >= 0; j--)
                {
                    if (nums[i] % nums[j] == 0 && max <= dp[j].Count)
                    {
                        dp[i] = new List<int>(dp[j]);
                        dp[i].Add(nums[i]);
                        max = dp[i].Count;
                        if (max > maxLen)
                        {
                            maxLen = max;
                            ans = i;
                        }
                    }
                }
            }
            return dp[ans];
        }
    }
}