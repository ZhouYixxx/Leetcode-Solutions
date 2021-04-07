using System;
using System.ComponentModel;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    /// <summary>
    /// 寻找两个有序数组的中位数
    /// </summary>
    public class FindMedianSortedArrays_004 : LeetCodeBase
    {
        public void Test()
        {
            //var nums1 = new int[] { 1, 3, 4, 9 };
            //var nums2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var nums1 = new int[] { 1 };
            var nums2 = new int[] { 2, 3, 4, 5, 6 };
            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
            Console.ReadKey();
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;
            var k = totalLength >> 1;
            //偶数
            if ((totalLength & 1 )== 0)
            {
                var m = GetKth(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1, k);
                var n = GetKth(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1, k + 1);
                return (m + n) * 0.5;

            }
            //奇数
            return GetKth(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1, k + 1);
        }

        /// <summary>
        /// 递归法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="start1"></param>
        /// <param name="end1"></param>
        /// <param name="nums2"></param>
        /// <param name="start2"></param>
        /// <param name="end2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double GetKth(int[] nums1,int start1, int end1, int[] nums2, int start2, int end2, int k)
        {
            //因为索引和算数不同6-0=6，但是是有7个数的，因为end初始就是数组长度-1构成的。
            //最后len代表当前数组(也可能是经过递归排除后的数组)，符合当前条件的元素的个数
            int len1 = end1 - start1 + 1;
            int len2 = end2 - start2 + 1;
            //让 len1 的长度小于 len2，这样就能保证如果有数组空了，一定是 len1
            //就是如果len1长度小于len2，把getKth()中参数互换位置，即原来的len2就变成了len1，即len1永远比len2小
            if (len1 > len2) return GetKth(nums2, start2, end2, nums1, start1, end1, k);
            //如果一个数组中没有了元素，那么即从剩余数组nums2的其实start2开始加k再-1.
            //因为k代表个数，而不是索引，那么从nums2后再找k个数，那个就是start2 + k-1索引处就行了。因为还包含nums2[start2]也是一个数。因为它在上次迭代时并没有被排除
            if (len1 == 0) return nums2[start2 + k - 1];

            //如果k=1，表明最接近中位数了，即两个数组中start索引处，谁的值小，中位数就是谁(start索引之前表示经过迭代已经被排出的不合格的元素，即数组没被抛弃的逻辑上的范围是nums[start]--->nums[end])。
            if (k == 1) return System.Math.Min(nums1[start1], nums2[start2]);

            //为了防止数组长度小于 k/2,每次比较都会从当前数组所生长度和k/2作比较，取其中的小的(如果取大的，数组就会越界)
            //数组如果len1小于k / 2，表示数组经过下一次遍历就会到末尾，然后后面就会在那个剩余的数组中寻找中位数
            int i = start1 + System.Math.Min(len1, k / 2) - 1;
            int j = start2 + System.Math.Min(len2, k / 2) - 1;

            //如果nums1[i] > nums2[j]，表示nums2数组中包含j索引，之前的元素，逻辑上全部淘汰，即下次从J+1开始。
            //而k则变为k - (j - start2 + 1)，即减去逻辑上排出的元素的个数(要加1，因为索引相减，相对于实际排除的时要少一个的)
            if (nums1[i] > nums2[j])
            {
                var newK = k - (j + 1 - start2);
                return GetKth(nums1, start1, end1, nums2, j + 1, end2, newK);
            }
            else
            {
                var newK = k - (i + 1 - start1);
                return GetKth(nums1, i + 1, end1, nums2, start2, end2, newK);
            }
        }

        /// <summary>
        /// 迭代法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthElement(int[] nums1, int[] nums2, int k)
        {
            /* 主要思路：要找到第 k (k>1) 小的元素，那么就取 pivot1 = nums1[k/2-1] 和 pivot2 = nums2[k/2-1] 进行比较
             * 这里的 "/" 表示整除
             * nums1 中小于等于 pivot1 的元素有 nums1[0 .. k/2-2] 共计 k/2-1 个
             * nums2 中小于等于 pivot2 的元素有 nums2[0 .. k/2-2] 共计 k/2-1 个
             * 取 pivot = min(pivot1, pivot2)，两个数组中小于等于 pivot 的元素共计不会超过 (k/2-1) + (k/2-1) <= k-2 个
             * 这样 pivot 本身最大也只能是第 k-1 小的元素
             * 如果 pivot = pivot1，那么 nums1[0 .. k/2-1] 都不可能是第 k 小的元素。把这些元素全部 "删除"，剩下的作为新的 nums1 数组
             * 如果 pivot = pivot2，那么 nums2[0 .. k/2-1] 都不可能是第 k 小的元素。把这些元素全部 "删除"，剩下的作为新的 nums2 数组
             * 由于我们 "删除" 了一些元素（这些元素都比第 k 小的元素要小），因此需要修改 k 的值，减去删除的数的个数
             */

            int length1 = nums1.Length, length2 = nums2.Length;
            int index1 = 0, index2 = 0;
            int kthElement = 0;

            while (true)
            {
                // 边界情况
                if (index1 == length1)
                {
                    return nums2[index2 + k - 1];
                }
                if (index2 == length2)
                {
                    return nums1[index1 + k - 1];
                }
                if (k == 1)
                {
                    return System.Math.Min(nums1[index1], nums2[index2]);
                }

                // 正常情况
                int half = k / 2;
                int newIndex1 = System.Math.Min(index1 + half, length1) - 1;
                int newIndex2 = System.Math.Min(index2 + half, length2) - 1;
                int pivot1 = nums1[newIndex1], pivot2 = nums2[newIndex2];
                if (pivot1 <= pivot2)
                {
                    k -= (newIndex1 - index1 + 1);
                    index1 = newIndex1 + 1;
                }
                else
                {
                    k -= (newIndex2 - index2 + 1);
                    index2 = newIndex2 + 1;
                }
            }
        }
        public FindMedianSortedArrays_004() : base("FindMedianSortedArrays_004")
        {
        }
    }
}