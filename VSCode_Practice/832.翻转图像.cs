/*
 * @lc app=leetcode.cn id=832 lang=csharp
 *
 * [832] 翻转图像
 */

// @lc code=start
using System;

public class Solution832 {
    public int[][] FlipAndInvertImage(int[][] A) {
        var n = A.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < (n+1)/2; j++)
            {
                var temp = A[i][j];
                A[i][j] = 1-A[i][n-j-1];
                A[i][n-j-1] = 1-temp;
            }
        }
        return A;
    }
}
// @lc code=end

