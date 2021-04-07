using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    public class Sqrt_69 : LeetCodeBase
    {
        public Sqrt_69() : base("Sqrt_69")
        {
            Console.Write(MySqrt(5));
            Console.ReadKey();
        }
        public int MySqrt(int x)
        {
            if (x == 0)
            {
                return x;
            }
            return (int) MySqrtFunc(x, x * 1.0);
        }

        public double MySqrtFunc(int n, double sqrt)
        {
            //var floor = System.Math.Floor(sqrt);
            //var ceil = System.Math.Ceiling(sqrt);
            var newSqrt = (sqrt + n / sqrt) / 2;
            if (System.Math.Abs(sqrt - newSqrt) <= 1E-6)
            {
                return sqrt;
            }
            sqrt = newSqrt;
            //牛顿迭代法
            return MySqrtFunc(n, sqrt);
        }
    }
}