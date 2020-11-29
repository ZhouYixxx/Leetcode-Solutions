using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    public class MyPow_50 : LeetCodeBase
    {
        public double MyPow(double x, int n)
        {
            if (n==0)
            {
                return 1;
            }
            if (n>0)
            {
                return PowFun(x, n);
            }
            return 1 / PowFun(x, -n);
        }

        /// <summary>
        /// 二分法递归计算，时间复杂度O(lgN)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double PowFun(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            var y = PowFun(x, n / 2);
            //n为偶数
            if ((n & 1) == 0)
            {
                return y * y;
            }
            return y * y * x;
        }

        public MyPow_50() : base("MyPow_50")
        {
        }
    }
}