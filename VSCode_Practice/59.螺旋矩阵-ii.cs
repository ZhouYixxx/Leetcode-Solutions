/*
 * @lc app=leetcode.cn id=59 lang=csharp
 *
 * [59] 螺旋矩阵 II
 */

// @lc code=start
using System;

public class Solution59 {
    public void Test()
    {
        var ans = GenerateMatrix(4);
    }

    public int[][] GenerateMatrix(int n) {
        //Init
        var mat = new int[n][];
        for (int i = 0; i < mat.Length; i++)
        {
            mat[i] = new int[n];
        }
        var left = 0;
        var right = n-1;
        var top = 0;
        var bottom = n-1;
        //按顺序计算
        int value = 1;
        while (left <= right && top <= bottom)
        {
            //从左到右
            for (int i = left; i <= right; i++)
            {
                mat[top][i] = value++;
            }
            //从上到下
            for (int i = top+1; i <= bottom; i++)
            {
                mat[i][right] = value++;
            }

            //从右到左
            for (int i = right-1; i >= left && top != bottom; i--)
            {
                mat[bottom][i] = value++;
            }
            //从下往上
            for (int i = bottom-1; i > top && left != right; i--)
            {
                mat[i][left] = value++;
            }
            top++;
            right--;
            bottom--;
            left++;
        }
        return mat;
    }
}
// @lc code=end

