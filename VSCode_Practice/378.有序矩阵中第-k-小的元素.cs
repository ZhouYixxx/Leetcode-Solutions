/*
 * @lc app=leetcode.cn id=378 lang=csharp
 *
 * [378] 有序矩阵中第 K 小的元素
 */

// @lc code=start
using System;
public class Solution378 {
    public void Test()
    {
        // var mat = new int[][]
        // {
        //     new int[]{1,4,7,11,15},
        //     new int[]{2,5,8,12,19},
        //     new int[]{3,6,9,16,22},
        //     new int[]{10,13,14,17,24},
        //     new int[]{18,21,23,26,30},
        // };
        // var mat = new int[][]
        // {
        //     new int[]{1,4},
        //     new int[]{12,100},
        // };
        var mat = new int[][]
        {
            new int[]{-5,-4},
            new int[]{-5,-4},
        };
        int k = 2;
        //测试比对
        var arr = new int[mat.Length*mat.Length];
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat.Length; j++)
            {
                arr[i*mat.Length + j] = mat[i][j];
            }
        }
        Array.Sort(arr);
        var trueAns = arr[k-1];
        var ans = KthSmallest(mat, k);
    }

    private int n;

    public int KthSmallest(int[][] matrix, int k) {
        
        n = matrix.Length;
        if (k == 1)
        {
            return matrix[0][0];
        }
        var l = matrix[0][0];
        var r = matrix[n-1][n-1];
        while (l <= r)
        {
            if (l == r)
            {
                return l;
            }
            var mid = l + (r - l) / 2;
            var smallerCount = GetNoBiggerCount(matrix, mid);
            // if (smallerCount == k)
            // {
            //     return mid;
            // }
            //smallerCount = k时不能停止搜索
            if (smallerCount >= k)
            {
                r = mid;
            }
            else
            {
                l = mid+1;
            }   
        }
        return l;
    }

    /// <summary>
    /// 获取矩阵中比当前数字更小(包括相等)的元素数量
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private int GetNoBiggerCount(int[][] matrix, int num)
    {
        int count = 0;
        //每一行用二分寻找
        for (int i = 0; i < n; i++)
        {
            int l = 0, r = n-1;
            if (matrix[i][0] > num)
            {
                continue;
            }
            //寻找最后一个小于等于num的数的位置
            while (l <= r)
            {
                if (l == r)
                {
                    count += l+1;
                    break;
                }
                var mid = (l+r)/2;
                if (matrix[i][mid] <= num)
                {
                    if (matrix[i][mid+1] > num)
                    {
                        count += mid+1;
                        break;
                    }
                    l = mid+1;
                    continue;
                }
                else
                {
                    r = mid;
                    continue;
                }
            }
        }
        return count;
    }

}
// @lc code=end

