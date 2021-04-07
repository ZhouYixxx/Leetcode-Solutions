using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class LongestIncreasingSubsequence_300 : LeetCodeBase
    {
        public LongestIncreasingSubsequence_300() : base("LongestIncreasingSubsequence_300")
        {
            Test();
        }

        /// <summary>
        /// O(N2)复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums.Length;
            }
            var dp = new int[nums.Length];
            // dp[i]的值代表以nums[i]结尾的最长子序列长度
            //状态方程：dp[i] = max(dp[j]+1), j<i && nums[i]>nums[j]
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var max = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        max = System.Math.Max(max, dp[j] + 1);
                    }
                }

                if (dp[i] < max)
                {
                    dp[i] = max;
                }
            }

            var longest = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                if (longest < dp[i])
                {
                    longest = dp[i];
                }
            }
            return longest;
        }

        /// <summary>
        /// O(NLogN)复杂度,
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS2(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums.Length;
            }
            //存储最长升序子串
            var longestSubsequence = new List<int>() { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                // nums[i]比升序子串最后一个数大，直接添加
                var last = longestSubsequence[longestSubsequence.Count - 1];
                if (last < nums[i])
                {
                    longestSubsequence.Add(nums[i]);
                    continue;
                }
                int left = 0, right = longestSubsequence.Count - 1;
                //二分查找后替换
                //保证nums[i]替换比他大的数中，最小的那个，保证这个队列始终是在保证最长的情况下，值最小的那个
                while (left < right)
                {
                    var mid = left + ((right - left) >> 1);
                    if (longestSubsequence[mid] < nums[i])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                longestSubsequence[left] = nums[i];
            }
            return longestSubsequence.Count;
        }

        public void Test()
        {
            var nums = new int[] { 1,4,1,21,3,6 };
            Console.WriteLine(LengthOfLIS2(nums));
            Console.ReadKey();
        }

    }
}