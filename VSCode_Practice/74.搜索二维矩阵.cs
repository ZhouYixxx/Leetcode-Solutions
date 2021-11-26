/*
 * @lc app=leetcode.cn id=74 lang=csharp
 *
 * [74] 搜索二维矩阵
 */

// @lc code=start
public class Solution74 {
    public void Test()
    {
        var matrix = new int[][]{
            new int[]{1,3,5,7},
            new int[]{10,11,16,20},
            new int[]{23,30,34,60},
        };
        var matrix1 = new int[][]{
            new int[]{5,8}
        };
        var target = 7;
        var ans = SearchMatrix1(matrix1,target);
    }

    public bool SearchMatrix(int[][] matrix, int target) 
    {
        var m = matrix.Length;//行
        var n = matrix[0].Length;//列
        //二分查找：行
        var top = 0;
        var bot = m-1;
        while (top <= bot)
        {
            var mid = (top+bot)/2;
            if (matrix[mid][n-1] == target)
            {
                return true;
            }

            if (matrix[mid][n-1] > target)
            {
                bot = mid-1;
            }
            else
            {
                top = mid+1;
            }
        }
        var row = top >= m ? m-1 : top;
        //二分查找：列
        var left = 0;
        var right = n-1;
        while (left <= right)
        {
            var mid = (left+right)/2;
            if (matrix[row][mid] == target)
            {
                return true;
            }

            if (matrix[row][mid] > target)
            {
                right = mid-1;
            }
            else
            {
                left = mid+1;
            }
        }
        return false;
    }

    public bool SearchMatrix1(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        //先确定在第几行
        int low = 0, high = m-1;
        while (low <= high)
        {
            if (low == high)
            {
                if (matrix[low][n-1] == target)
                {
                    return true;
                }
                if (matrix[low][n-1] < target)
                {
                    return false;
                }
                break;
            }
            var mid = (low+high)/2;
            if (matrix[mid][n-1] == target)
            {
                return true;
            }
            if (matrix[mid][n-1] > target)
            {
                high = mid;
            }
            else
            {
                low = mid+1;
            }
        }
        var row = high >= m ? m-1 : high;
        int left = 0, right = n-1;
        while (left <= right)
        {
            if (left == right)
            {
                return matrix[row][left] == target;
            }
            var mid = (left+right)/2;
            if (matrix[row][mid] == target)
            {
                return true;
            }
            if (matrix[row][mid] > target)
            {
                right = mid;
            }
            else
            {
                left = mid+1;
            }
        }
        return false;
    }
}
// @lc code=end

