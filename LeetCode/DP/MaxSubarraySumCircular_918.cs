using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class MaxSubarraySumCircular_918 : LeetCodeBase
    {
        public MaxSubarraySumCircular_918() : base("MaxSubarraySumCircular_918")
        {
            var nums = new int[] {5,-3,4,-2,5};
            Console.WriteLine(MaxSubarraySumCircular(nums));
            Console.ReadKey();
        }

        public int MaxSubarraySumCircular(int[] A)
        {
            if (A.Length < 2)
            {
                return A[0];
            }
            var maxDp = new int[A.Length];
            var minDp = new int[A.Length];
            int max1 = A[0];
            var min = A[1];
            maxDp[0] = max1;
            minDp[1] = min;
            //minDp数组是计算[1,A.Length-1]这个区间的最小值，因此将头尾两个值默认设为0。
            minDp[0] = 0;
            minDp[A.Length - 1] = 0;
            var sum = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                maxDp[i] = System.Math.Max(maxDp[i - 1] + A[i], A[i]);
                sum += A[i];
                //minDp[A.Length -1] = 0
                if (i < A.Length -1)
                {
                    minDp[i] = System.Math.Min(minDp[i - 1] + A[i], A[i]);
                }
                if (max1 < maxDp[i])
                {
                    max1 = maxDp[i];
                }
                if (min > minDp[i])
                {
                    min = minDp[i];
                }
            }

            return System.Math.Max(max1, sum - min);
        }
    }
}