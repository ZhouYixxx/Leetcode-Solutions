using System;
using System.Globalization;
using CodePractice.BasicDataStructure.MathHelper;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    public class SetMatrixZeroes_73 : LeetCodeBase
    {
        public SetMatrixZeroes_73() : base("SetMatrixZeroes_73")
        {
            var nums = new int[][]
            {
                new[] {3, 5, 5, 6, 9, 1, 4, 5, 0, 5},
                new[] {2, 7, 9, 5, 9, 5, 4, 9, 6, 8},
                new [] {6, 0, 7, 8, 1, 0, 1, 6, 8, 1},
                new [] {7, 2, 6, 5, 8, 5, 6, 5, 0, 6},
                new [] {2, 3, 3, 1, 0, 4, 6, 5, 3, 5},
                new [] {5, 9, 7, 3, 8, 8, 5, 1, 4, 3},
                new [] {2, 4, 7, 9, 9, 8, 4, 7, 3, 7},
                new [] {3, 5, 2, 8, 8, 2, 2, 4, 9, 8},
            };
            Matrix.ShowMatrix(nums);
            SetZeroes(nums);
            Matrix.ShowMatrix(nums);
            Console.ReadKey();
        }

        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;//m行
            int n = matrix[0].Length;//n列
            bool isFirstRowZero = false;
            bool isFirstColumnZero = false;
            //先判断第一行第一列的情况
            for (int i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    isFirstRowZero = true;
                    break;
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isFirstColumnZero = true;
                    break;
                }
            }
            //从第二行第二列开始遍历，发现0就把当前行和列的第一个元素置0（用第一行和第一列来记录0的位置）
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            //从第二列开始遍历置0
            for (int i = 1; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    for (int j = 1; j < m; j++)
                    {
                        matrix[j][i] = 0;
                    }
                }
            }

            //从第二行开始遍历置0
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < n; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            //处理第一行
            if (isFirstRowZero)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    matrix[0][i] = 0;
                }
            }

            //处理第一列
            if (isFirstColumnZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }
    }
}