using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    public class ScoreAfterFlippingMatrix_861 : LeetCodeBase
    {
        public ScoreAfterFlippingMatrix_861() : base("ScoreAfterFlippingMatrix_861")
        {
            var A = new int[][]
            {
                new int[]{ 0, 0, 1, 1 },
            };
            Console.WriteLine(MatrixScore(A));
            Console.ReadKey();
        }

        public int MatrixScore(int[][] A)
        {
            var rows = A.Length;
            var columns = A[0].Length;
            //第一列一定要保证为1
            for (int i = 0; i < rows; i++)
            {
                if (A[i][0] == 0)
                {
                    Flipping(A, 0, i);
                }
            }
            //之后查看第一列到第columns-1列
            for (int i = 1; i < columns; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j][i] == 0)
                        zeroCount++;
                    else
                        oneCount++;
                }
                if (zeroCount > oneCount)
                {
                    Flipping(A, 1, i);
                }
            }
            //计算
            var sum = 0;
            for(int i = 0; i<rows; i++){
                var subSum = 0;
                int pow = 0;
                for(int j = columns -1; j>=0; j--){
                    subSum+=A[i][j]*(int)System.Math.Pow(2,pow);
                    pow++;
                }
                sum+=subSum;
            }
            return sum;
        }

        //type == 0,翻转行, type == 1，翻转列
        private void Flipping(int[][] A, int type, int index)
        {
            if (type == 0)
            {
                for (int i = 0; i < A[0].Length; i++){
                    A[index][i] = A[index][i] == 0 ? 1 : 0;
                }
            }
            else if (type == 1)
            {
                for (int i = 0; i < A.Length; i++){
                    A[i][index] = A[i][index] == 0 ? 1 : 0;
                }
            }
        }
    }
}