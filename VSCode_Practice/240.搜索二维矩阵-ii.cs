/*
 * @lc app=leetcode.cn id=240 lang=csharp
 *
 * [240] 搜索二维矩阵 II
 */

// @lc code=start
public class Solution240 {
    public void Test()
    {
        var ms = "[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]";
        var mat = DataStructureHelper.ConvertStringToTwoDimenNumArray(ms);
        var target = 10;
        var ans = SearchMatrix(mat ,target);
    }

    public bool SearchMatrix(int[][] matrix, int target) 
    {
        return SearchMatrix3(matrix, target);
    }

    /// <summary>
    /// 遍历每行进行二分，时间复杂度O(mlogn)
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool SearchMatrix1(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        for (int i = 0; i < m; i++)
        {
            var nums = matrix[i];
            int l = 0, r = nums.Length-1;
            while (l <= r)
            {
                if (l == r)
                {
                    if (nums[l] == target)
                    {
                        return true;
                    }
                    break;
                }
                var mid = (l+r)/2;
                if (nums[mid] == target)
                {
                    return true;
                }
                else if (nums[mid] > target)
                {
                    r = mid;
                }
                else if (nums[mid] < target)
                {
                    l = mid+1;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// 从右上角开始，左边的数都更小，下面的数都更大, 如果当前值小于目标值，向下走，当前值大于目标值，向左走
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool SearchMatrix2(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        int row = 0, col = n-1;
        while (row < m && col >= 0)
        {
            var candi = matrix[row][col];
            if (candi == target)
            {
                return true;
            }
            if (candi > target)
            {
                col--;
            }
            if (candi < target)
            {
                row++;
            }
        }
        return false;
    }

    /// <summary>
    /// 二维二分，每次舍弃1/4的数据
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool SearchMatrix3(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        return SearchHelper(matrix, 0, m-1, 0, n-1, target);
    }

    private bool SearchHelper(int[][] matrix, int start_row, int end_row, int start_col, int end_col, int target)
    {
        if (start_row == end_row && start_col == end_col)
        {
            return matrix[start_row][start_col] == target;
        }
        if (start_row > end_row || start_col > end_col || end_row >= matrix.Length || end_col >= matrix[0].Length)
        {
            return false;
        }
        var center_row = (start_row + end_row)/2;
        var center_col = (start_col + end_col)/2;
        var center = matrix[center_row][center_col];
        if (center == target)
        {
            return true;
        }
        if (center > target)
        {
            //此时排除右下1/4
            var left_top = SearchHelper(matrix, start_row, center_row, start_col, center_col, target);
            var right_top = SearchHelper(matrix, start_row, center_row, center_col+1, end_col, target);
            var left_bot = SearchHelper(matrix, start_row+1, end_row, start_col, center_col, target);
            return left_top || right_top || left_bot;
        }
        else
        {
            //此时排除左上1/414
            var right_bot = SearchHelper(matrix, center_row+1, end_row, center_col+1, end_col, target);
            var right_top = SearchHelper(matrix, start_row, center_row, center_col+1, end_col, target);
            var left_bot = SearchHelper(matrix, start_row+1, end_row, start_col, center_col, target);
            return left_bot || right_bot || right_top;
        }
    }
}
// @lc code=end

