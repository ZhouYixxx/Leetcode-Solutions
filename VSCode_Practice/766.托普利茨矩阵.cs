/*
 * @lc app=leetcode.cn id=766 lang=csharp
 *
 * [766] 托普利茨矩阵
 */

// @lc code=start
public class Solution766 {
    public void Test()
    {
        var mat = new int[][]
        {
            //new int[]{1,2,3,4},
            //new int[]{5,1,2,3},
            //new int[]{9,5,1,2},
            new int[]{2},
            new int[]{1},
        };
        var ans = IsToeplitzMatrix(mat);
    }


    public bool IsToeplitzMatrix(int[][] matrix) {
        if (matrix.Length == 1 || matrix[0].Length == 1)
        {
            return true;
        }
        return IsToeplitzMatrixHelper(matrix, matrix.Length-1,0);
    }

    private bool IsToeplitzMatrixHelper(int[][] matrix,int startRow,int startCol)
    {
        var row = startRow;
        var col = startCol;
        if (col == matrix[0].Length-1)
        {
            return true;
        }
        while (row < matrix.Length -1 && col < matrix[0].Length -1 )
        {
            if (matrix[row][col] != matrix[row+1][col+1])
            {
                return false;
            }
            row++;
            col++;
        }
        //本对角线是相等的
        int newCol = startRow == 0 ? startCol+1 : startCol;
        int newRow = startRow > 0 ? startRow-1 : startRow;
        return IsToeplitzMatrixHelper(matrix, newRow,newCol);
    }
}
// @lc code=end

