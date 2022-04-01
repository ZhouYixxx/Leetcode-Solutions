/*
 * @lc app=leetcode.cn id=378 lang=csharp
 *
 * [378] 有序矩阵中第 K 小的元素
 */

// @lc code=start
public class Solution378 {
    public void Test()
    {
        var mat = new int[][]
        {
            new int[]{1,4,7,11,15},
            new int[]{2,5,8,12,19},
            new int[]{3,6,9,16,22},
            new int[]{10,13,14,17,24},
            new int[]{18,21,23,26,30},
        };
        int k = 5;
        var ans = KthSmallest(mat, k);
    }

    private int n;

    public int KthSmallest(int[][] matrix, int k) {
        //从左上角开始，分别向右向下寻找
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
            var mid = (l+r) / 2;
            var smallerCount = GetSmallerCount(matrix, mid);
            if (smallerCount == k)
            {
                return mid;
            }
            if (smallerCount > k)
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
    private int GetSmallerCount(int[][] matrix, int num)
    {
        int count = 0;
        //每一行用二分寻找
        for (int i = 0; i < n; i++)
        {
            //寻找最后一个小于等于num的数的位置
            int l = 0, r = n-1;
            while (l <= r)
            {
                if (l == r)
                {
                    count += l;
                    break;
                }
                var mid = (l+r)/2;
                if (matrix[i][mid] == num && mid != n-1 && matrix[i][mid+1] != num)
                {
                    count += mid;
                    break;
                }
                if (matrix[i][mid] > num)
                {
                    r = mid;
                    continue;
                }
                else
                {
                    l = mid+1;
                    continue;
                }
            }
        }
        return count;
    }

}
// @lc code=end

