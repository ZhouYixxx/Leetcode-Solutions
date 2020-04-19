/*
283. 移动零
给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。

示例:
输入: [0,1,0,3,12]
输出: [1,3,12,0,0]
 */

using System;

namespace CodePractice.LeetCode.Array
{
    public class MoveZeroes_283
    {
        public static void MoveZeroes(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return;
            }
            int fast = 0;
            int slow = 0;
            while (fast < nums.Length)
            {
                if (nums[fast] != 0)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }

            for (int i = slow; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        public static void Test()
        {
            var nums = new int[] { 0,1 };
            MoveZeroes(nums);
            foreach (var num in nums)
            {
                Console.Write(num+"  ");
            }
            Console.ReadKey();
        }
    }
}