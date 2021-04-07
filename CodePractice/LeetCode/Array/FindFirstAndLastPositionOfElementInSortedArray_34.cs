using System;
using System.Globalization;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class FindFirstAndLastPositionOfElementInSortedArray_34 : LeetCodeBase
    {
        public FindFirstAndLastPositionOfElementInSortedArray_34() 
            : base("FindFirstAndLastPositionOfElementInSortedArray_34")
        {
            var nums = new int[] { 2,2 };
            int target =2;
            var result = SearchRangeQuick(nums, target);
            Console.WriteLine($"{result[0]}, {result[1]}");
            Console.ReadKey();
        }

        /// <summary>
        /// 常规解法，O(N)
        /// </summary>
        public int[] SearchRange(int[] nums, int target)
        {
            var result = new int[2] { -1, -1 };
            if (nums.Length == 0)
            {
                return result;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    var index = result[0] == -1 ? 0 : 1;
                    result[index] = i;
                }
            }
            if (result[0] != -1 && result[1] == -1)
            {
                result[1] = result[0];
            }
            return result;
        }

        /// <summary>
        /// 二分法，O(logN)
        /// </summary>
        public int[] SearchRangeQuick(int[] nums, int target)
        {
            var result = new int[2] { -1, -1 };
            if (nums.Length == 0)
            {
                return result;
            }
            var left = SearchLeftPosition(nums, target, 0, nums.Length - 1, -1);
            if (left == -1)
            {
                return result;
            }
            var right = SearchRightPosition(nums, target, left, nums.Length - 1,-1);
            result[0] = left;
            result[1] = right;
            return result;
        }

        /// <summary>
        /// 二分法，O(logN)，寻找出现的第一个元素
        /// </summary>
        public int SearchLeftPosition(int[] nums, int target, int start, int end, int leftIndex)
        {
            if (start == end)
            {
                return nums[start] == target ? start : leftIndex;
            }
            var mid = start + (end - start) / 2;
            //数组存在重复，在寻找第一个元素时，找到相等也不返回
            if (nums[mid] == target)
            {
                //找到一个相等的值就更新leftIndex
                leftIndex = mid;
                return SearchLeftPosition(nums, target, start, mid, leftIndex);
            }

            if (nums[mid] < target)
            {
                return SearchLeftPosition(nums, target, mid + 1, end, leftIndex);
            }
            else
            {
                return SearchLeftPosition(nums, target, start, mid, leftIndex);
            }
        }

        /// <summary>
        /// 二分法，O(logN)，寻找出现的最后一个元素
        /// </summary>
        public int SearchRightPosition(int[] nums, int target, int start, int end, int rightIndex)
        {
            if (start == end)
            {
                //rightIndex记录有边界的位置
                return nums[start] == target ? start : rightIndex;
            }
            var mid = start + (end - start) / 2;
            //数组存在重复，在寻找第一个元素时，找到相等也不返回
            //寻找第一个和最后一个元素的主要区别
            if (nums[mid] == target)
            {
                //找到一个相等的值就更新rightIndex
                rightIndex = mid;
                return SearchRightPosition(nums, target, mid+1, end, rightIndex);
            }

            if (nums[mid] < target)
            {
                return SearchRightPosition(nums, target, mid + 1, end, rightIndex);
            }
            else
            {
                return SearchRightPosition(nums, target, start, mid, rightIndex);
            }
        }
    }
}