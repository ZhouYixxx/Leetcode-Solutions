/*
1. 两数之和
给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那两个整数，并返回他们的数组下标。
你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。

示例:
给定 nums = [2, 7, 11, 15], target = 9
因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]
 */

using System;
using System.Collections.Generic;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class TwoSum_001 : LeetCodeBase
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = target - nums[i];
                if (dic.ContainsKey(result))
                {
                    return new int[2]{dic[result],i};
                }
                dic[nums[i]] = i;
            }
            throw new Exception("未能找到符合要求的元素");
        }

        public static void Test()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            var result = TwoSum(nums, target);
            Console.WriteLine($"{result[0]};{result[1]}");
            Console.ReadKey();
        }

        public TwoSum_001() : base("TwoSum_001")
        {
            Test();
        }
    }
}