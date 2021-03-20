using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    //三角形的最大周长
    public class LargestPerimeterTriangle_976 : LeetCodeBase
    {
        public LargestPerimeterTriangle_976() : base("LargestPerimeterTriangle_976")
        {
            var test = new int[] { 3, 2, 3, 4 };
            Console.WriteLine(LargestPerimeter(test));
            Console.ReadKey();
        }

        public int LargestPerimeter(int[] A)
        {
            System.Array.Sort(A);
            for (int i = A.Length -1; i >= 2; i--)
            {
                if (A[i-2]+A[i-1] > A[i])
                {
                    return A[i - 2] + A[i - 1] + A[i];
                }
            }
            return 0;
        }
    }
}