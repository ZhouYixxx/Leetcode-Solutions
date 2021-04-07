using System;
using System.Net.Http.Headers;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class GetMaxMatrix : LeetCodeBase
    {
        public GetMaxMatrix() : base("GetMaxMatrix")
        {
            var a = FindMaxSubArray(new[] { -4, -5 });
            var matrix = new int[][]
            {
                new int[]{-4,-5},
            };
            var res = GetMaxMatrix1(matrix);
            foreach (var item in res)
            {
                Console.Write(item+", ");
            }
            Console.ReadKey();
        }

        public int[] GetMaxMatrix1(int[][] matrix)
        {
            var rows = matrix.Length;
            var columns = matrix[0].Length;
            var res = new int[4];
            int max = Int32.MinValue;
            for (int i = 0; i < rows; i++)
            {
                var sumArray = new int[columns];
                for (int j = i; j < rows; j++)
                {
                    //将第i行到第j行的矩阵压缩成一维数组sumArray
                    for (int column = 0; column < columns; column++)
                    {
                        sumArray[column] += matrix[j][column];
                    }
                    //sumArray求最大子数组
                    var maxInfo = FindMaxSubArray(sumArray);
                    if (maxInfo[2] > max)
                    {
                        max = maxInfo[2];
                        res[0] = i;
                        res[1] = maxInfo[0];
                        res[2] = j;
                        res[3] = maxInfo[1];
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 求一维数组的最大子数组和:O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindMaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return new int[3];
            }
            var dp = new int[nums.Length];
            //ans[0]:起始位置,ans[1]：终止位置,ans[2]：最大和
            var ans = new int[3];
            dp[0] = nums[0];
            int max = nums[0];
            int begin = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = dp[i - 1] <= 0 ? nums[i] : (dp[i - 1] + nums[i]);
                if (dp[i-1] < 0)
                {
                    begin = i;
                }
                if (max < dp[i])
                {
                    max = dp[i];
                    ans[0] = begin;
                    ans[1] = i;
                }
            }
            ans[2] = max;
            return ans;
        }

        /// <summary>
        /// 求一维数组的最大子数组和:O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindMaxSubArray1(int[] nums)
        {
            if (nums.Length == 0)
            {
                return new int[3];
            }
            var max = Int32.MinValue;
            int dp_i = nums[0];
            int begin = 0;
            //ans[0]:起始位置,ans[1]：终止位置,ans[2]：最大和
            var ans = new int[3];
            for (int i = 1; i < nums.Length; i++)
            {
                if (dp_i < 0)
                {
                    dp_i = nums[i];
                    ans[0] = i;
                }
                else
                {
                    dp_i += nums[i];
                }

                if (dp_i > max)
                {
                    max = dp_i;
                    ans[0] = begin;
                    ans[1] = i;
                }
            }
            ans[2] = max;
            return ans;
        }
    }
}