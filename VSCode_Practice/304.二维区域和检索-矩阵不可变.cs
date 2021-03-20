/*
 * @lc app=leetcode.cn id=304 lang=csharp
 *
 * [304] 二维区域和检索 - 矩阵不可变
 */

// @lc code=start
using System;

public class NumMatrix {
    private int[][] preSum;

    public NumMatrix(int[][] matrix) {
/*         var rows = matrix.Length;
        var cols = rows == 0 ? 0 : matrix[0].Length;
        preSum = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            preSum[i] = new int[cols];
            //公式：preSum[i][j] = preSum[i][j-1]+ preSum[i-1][j] - preSum[i-1][j-1] + matrix[i][j]
            for (int j = 0; j < cols; j++)
            {
                //特殊情况的处理
                if (i == 0 && j == 0)
                {
                    preSum[i][j] = matrix[i][j];
                    continue;
                }
                if (i == 0)
                {
                    preSum[i][j] = preSum[i][j-1] + matrix[i][j];
                    continue;
                }
                else if(j == 0)
                {
                    preSum[i][j] = preSum[i-1][j] + matrix[i][j];
                    continue;
                }
                preSum[i][j] = preSum[i][j-1]+ preSum[i-1][j] - preSum[i-1][j-1] + matrix[i][j];
            }
        } */
        var rows = matrix.Length;
        var cols = rows == 0 ? 0 : matrix[0].Length;
        preSum = new int[rows+1][];
        preSum[0] = new int[cols+1];
        for (int i = 1; i < rows+1; i++)
        {
            preSum[i] = new int[cols+1];
            for (int j = 1; j < cols+1; j++)
            {
                preSum[i][j] = preSum[i][j-1]+ preSum[i-1][j] - preSum[i-1][j-1] + matrix[i-1][j-1];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
/*         if (row1 == 0 && col1 == 0)
        {
            return preSum[row2][col2];
        }
        if (row1 == 0)
        {
            return preSum[row2][col2] - preSum[row2][col1-1];
        }
        if (col1 == 0)
        {
            return preSum[row2][col2] - preSum[row1-1][col2];
        } */
        row1++;
        col1++;
        row2++;
        col2++;
        var s1 = preSum[row1-1][col1-1];
        var s2 = preSum[row2][col2];
        var s3 = preSum[row1-1][col2];
        var s4 = preSum[row2][col1-1];
        return s1+s2-s3-s4;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
// @lc code=end

