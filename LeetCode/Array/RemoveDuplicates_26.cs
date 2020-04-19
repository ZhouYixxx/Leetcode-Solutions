/*
26. 删除排序数组中的重复项

给定一个排序数组，你需要在 原地 删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。

示例 1:
给定 nums = [0,0,1,1,1,2,2,3,3,4],
函数应该返回新的长度 5, 并且原数组 nums 的前五个元素被修改为 0, 1, 2, 3, 4。
你不需要考虑数组中超出新长度后面的元素。
 */
using System;

namespace CodePractice.LeetCode.Array
{
    public class RemoveDuplicates_26
    {
        private static int RemoveDuplicates(int[] nums)
        {
            //nums为空的特殊情况
            if (nums.Length == 0)
            {
                return nums.Length;
            }
            //定义快慢双指针
            int slowIndex = 0;
            int fastIndex = 0;
            while (fastIndex < nums.Length)
            {
                //快指针未发现不同的元素，直接跳到下一个元素
                if (nums[slowIndex] == nums[fastIndex])
                {
                    fastIndex++;
                    continue;
                }
                //发现快慢指针对应元素值不同，慢指针+1，并把快指针对应元素赋值给慢指针
                slowIndex++;
                nums[slowIndex] = nums[fastIndex];
                //快指针+1
                fastIndex++;
            }
            return slowIndex + 1;
        }

        public static void Test()
        {
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 5,5,5,6,6,7 };
            var length = RemoveDuplicates(nums);
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{nums[i]}, ");
            }
            Console.ReadKey();
        }
    }
}