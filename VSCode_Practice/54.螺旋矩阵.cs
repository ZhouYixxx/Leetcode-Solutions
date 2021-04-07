/*
 * @lc app=leetcode.cn id=54 lang=csharp
 *
 * [54] 螺旋矩阵
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution54 {
    public void Test()
    {
        var mat = new int[][]
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,9},
            new int[]{10,11,12},
            //new int[]{13,14,15,16},
        };
        var ans = SpiralOrder(mat);
    }


    public IList<int> SpiralOrder(int[][] matrix) {
        var ans = new List<int>();
        var r = matrix.Length;
        var c = matrix[0].Length;
        SpiralOrderRecursive(matrix,ans, 0,0,r-1,c-1);
        return ans;
    }

    private void SpiralOrderRecursive(int[][] matrix,IList<int> ans,int startRow, int startColumn, 
        int endRow, int endColumn)
    {
        if (startRow > endRow || startColumn > endColumn)
        {
            return;
        }
        var count = (endColumn-startColumn+1)*(endRow-startRow+1);
        for (int i = startColumn; i <= endColumn; i++)
        {
            ans.Add(matrix[startRow][i]);   
        }
        for (int i = startRow+1; i <= endRow; i++)
        {
            ans.Add(matrix[i][endColumn]);   
        }
        for (int i = endColumn-1; i >= startColumn && endRow > startRow; i--)
        {
            ans.Add(matrix[endRow][i]);   
        }
        for (int i = endRow-1; i > startRow && endColumn > startColumn; i--)
        {
            ans.Add(matrix[i][startColumn]);   
        }
        SpiralOrderRecursive(matrix,ans, startRow+1,startColumn+1,endRow-1,endColumn-1);
    }
}

// @lc code=end

