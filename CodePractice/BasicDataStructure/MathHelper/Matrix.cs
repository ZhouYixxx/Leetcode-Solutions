using System;

namespace CodePractice.BasicDataStructure.MathHelper
{
    public static class Matrix
    {
        public static void ShowMatrix(int[][] matrixInts)
        {
            Console.WriteLine("Current Matrix is:");
            var rows = matrixInts.Length;
            var columns = matrixInts[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var value = matrixInts[i][j];
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}