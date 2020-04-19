/*
977. 有序数组的平方
给定一个按非递减顺序排序的整数数组 A，返回每个数字的平方组成的新数组，要求也按非递减顺序排序。

示例 1：
输入：[-4,-1,0,3,10]
输出：[0,1,9,16,100]

示例 2：
输入：[-7,-3,2,3,11]
输出：[4,9,9,49,121]
 */

using System;

namespace CodePractice.LeetCode.Array
{
    public class SquaresSortedArray_977
    {
        //双指针法，两个指针分别指向数组的左右，时间复杂度O(n)，空间复杂度O(1)
        public static int[] SortedSquares(int[] A)
        {
            var ans = new int[A.Length];
            //定义两个指针，分别指向数组的左右两边
            int left = 0;
            int right = A.Length - 1;
            int leftSqua = 0;
            int rightSqua = 0;
            int i = right;
            while (i >= 0)
            {
                //比较left和right的平方，取更大的值放入新数组的尾部
                leftSqua = A[left] * A[left];
                rightSqua = A[right] * A[right];
                if (leftSqua <= rightSqua)
                {
                    ans[i] = rightSqua;
                    //右边的平方更大，因此right索引-1
                    right--;
                }
                else
                {
                    ans[i] = leftSqua;
                    //左边的平方更大，因此right索引-1
                    left++;
                }
                i--;
            }
            return ans;
        }
        
        public static void Test()
        {
            var nums = new int[] { -12,-7, -3,1, 2, 3, 11 };
            var ans = SortedSquares(nums);
            for (int i = 0; i < ans.Length; i++)
            {
                Console.Write(ans[i] + " ");
            }
            Console.ReadKey();
        }
    }
}