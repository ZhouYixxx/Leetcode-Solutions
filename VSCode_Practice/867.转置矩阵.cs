/*
 * @lc app=leetcode.cn id=867 lang=csharp
 *
 * [867] 转置矩阵
 */

// @lc code=start
using System;

public class Solution867 {
    public void Test()
    {
        var mat = new int[][]{
            new int[]{1},
            new int[]{4},
            //new int[]{7,8,9},
        };
        var ans = Transpose(mat);
    }

    public int[][] Transpose(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var newMat = new int[n][];
        for (int i = 0; i < newMat.Length; i++)
        {
            newMat[i] = new int[m];
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                newMat[j][i] = matrix[i][j];
            }
        }
        return newMat;
    }
}
// @lc code=end

