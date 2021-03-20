/*
 * @lc app=leetcode.cn id=566 lang=csharp
 *
 * [566] 重塑矩阵
 */

// @lc code=start
using System;

public class Solution566 {

    public int[][] MatrixReshape(int[][] nums, int r, int c) {
        var m = nums.Length;
        var n = nums[0].Length;
        var ans = new int[r][];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = new int[c];
        }
        if (r * c != m * n)
        {
            return nums;
        }
        int curRow = 0;
        int curCol = 0;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (curCol == n)
                {
                    curCol = 0;
                    curRow++;
                }
                ans[i][j] = nums[curRow][curCol++];
            }
        }
        return ans;
    }
}
// @lc code=end

