using System;

namespace CodePractice.LeetCode.Array
{
    public class _MergeSortedArray_88
    {
        //双指针法，从后向前遍历，时间复杂度O(m+n)，空间复杂度O(1)
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
            {
                return;
            }
            int p1 = m - 1;
            int p2 = n - 1;
            int p = m + n - 1;
            while (p1 >= 0 && p2 >= 0)
            {
                //nums2[p2]的值大，则将p处赋值为nums2[p2]
                if (nums1[p1] <= nums2[p2])
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                //nums1[p1]的值大，则将p处赋值为nums1[p1]
                else
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                p--;
            }
            //如果p2 <= 0,无需处理，p1 <= 0说明需要将nums2中余下的元素赋值到nums1数组中
            if (p1 <= 0)
            {
                for (int i = 0; i <= p2; i++)
                {
                    nums1[i] = nums2[i];
                }
            }
        }

        public static void Test()
        {
            var nums1 = new int[] { 2,0};
            var nums2 = new int[] { 1 };
            int m = 1, n = 1;
            Merge(nums1,m,nums2,n);
            for (int i = 0; i <= m+n-1; i++)
            {
                Console.Write(nums1[i] + "  ");
            }
            Console.ReadKey();
        }
    }
}