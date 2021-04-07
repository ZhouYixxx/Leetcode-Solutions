using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.Core;

//特判，对于数组长度 n，如果数组为 null 或者数组长度小于 3，返回 [][]。
//对数组进行排序。
//遍历排序后数组：
//  若 nums[i]>0nums[i]>0：因为已经排序好，所以后面不可能有三个数加和等于 0，直接返回结果。
//  对于重复元素：跳过，避免出现重复解
//  令左指针 L =i+1，右指针 R = n - 1，当 L<R 时，执行循环：
//  当 nums[i]+nums[L]+nums[R]==0，执行循环，判断左界和右界是否和下一位置重复，去除重复解。并同时将 L, RL, R 移到下一位置，寻找新的解
//  若和大于 0，说明 nums[R] 太大，RR 左移
//  若和小于 0，说明 nums[L] 太小，LL 右移

namespace CodePractice.LeetCode.Array
{
    public class ThreeSum_015 : LeetCodeBase
    {
        /// <summary>
        /// 三数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return new List<IList<int>>();
            }
            var list = new List<IList<int>>();
            System.Array.Sort(nums);
            if (nums[0] > 0)
            {
                return new List<IList<int>>();
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                if (i>0 && nums[i] == nums[i-1])
                {
                    continue;
                }

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        list.Add(new List<int>(){ nums[i], nums[left], nums[right] });
                        while (left<right && nums[left] == nums[left+1])
                        {
                            left += 1;
                        }
                        while (left<right && nums[right] == nums[right - 1])
                        {
                            right -= 1;
                        }
                        left = left + 1;
                        right = right - 1;
                    }

                    if (sum < 0)
                    {
                        left++;
                    }

                    if (sum>0)
                    {
                        right--;
                    }
                }
            }
            return list;
        }

        public void Test()
        {
            var nums = new int[] {-1, 0, 1, 2, -1, -4};
            var list = ThreeSum(nums);
            foreach (var item in list)
            {
                foreach (var value in item)
                {
                    Console.Write($"{value},");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public ThreeSum_015() : base("ThreeSum_015")
        {
            Test();
        }
    }
}