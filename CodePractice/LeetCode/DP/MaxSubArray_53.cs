using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class MaxSubArray_53 : LeetCodeBase
    {
        public MaxSubArray_53() : base("MaxSubArray_53")
        {
        }

        /// <summary>
        /// 动态规划时，为了寻找递推关系，我们常常需要以子序列的结束节点作为基准，遍历出以某个节点为结束的所有子序列，
        /// 这样更容易寻找到递推关系
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
                return Int32.MinValue;
            var dp = new int[nums.Length];
            //dp[i]表示以nums[i]为结束节点的子串中，和最大的那个子串
            //状态方程应该是:dp[i] = Max(dp[i-1] + nums[i], nums[i])
            dp[0] = nums[0];
            int res = dp[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = System.Math.Max(dp[i - 1] + nums[i], nums[i]);
                if (res < dp[i])
                {
                    res = dp[i];
                }
            }
            return res;
        }
    }
}