using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using CodePractice.Core;
using Console = System.Console;

namespace CodePractice.LeetCode.Array
{
    public class FindKthLargest_215 : LeetCodeBase
    {
        public void Test()
        {
            var nums = new int[] {1,2};
            Console.Write(FindKthLargest(nums, 1, 0, nums.Length - 1));
            Console.ReadKey();
        }

        /// <summary>
        /// 类似快速排序，平均一次去掉一半的数据,时间复杂度为O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k, int start, int end)
        {
            var p = Partition(nums, start, end);
            if (p == k - 1)
            {
                return nums[p];
            }
            if (p > k -1)
            {
                return FindKthLargest(nums,k, start, p - 1);
            }
            else
            {
                return FindKthLargest(nums, k, p + 1, end);
            }
        }


        /// <summary>
        /// 返回值i满足[start，i]的值都大于nums[i]，[i+1，end]的值都小于nums[i]，
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int Partition(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return start;
            }
            var pivot = nums[end];
            int i = start;//标记已处理的位置
            int j = start;//遍历
            while (j <= end)
            {
                if (nums[j] > pivot)
                {
                    //swap i,j,用异或运算实现交换
                    //nums[i] = nums[i] ^ nums[j];
                    //nums[j] = nums[j] ^ nums[i];
                    //nums[i] = nums[i] ^ nums[j];
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                }
                j++;
            }
            //交换pivot和nums[i]
            nums[end] = nums[i];
            nums[i] = pivot;
            return i;
        }

        public FindKthLargest_215() : base("FindKthLargest_215")
        {
            Test();
        }
    }
}