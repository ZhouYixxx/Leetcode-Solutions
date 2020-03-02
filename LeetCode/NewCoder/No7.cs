using System;

namespace LeetCode
{
    /// <summary>
    /// Integer Inversion 
    /// </summary>
    public static class No7
    {
        public static int Reverse(int x)
        {
            //获取位数
            int ans = 0;
            var length = x.ToString().Length;
            if (x < 0)
            {
                length -= 1;
            }
            for (int i = 0; i < length; i++)
            {
                int pop = x % 10;
                if (ans > int.MaxValue / 10 || (ans == int.MaxValue / 10 && pop > 7))
                    return 0;
                ans = ans * 10 + pop;
                x /= 10;
            }
            return ans;
            //while (x != 0)
            //{
            //    int pop = x % 10;
            //    if (ans > int.MaxValue/ 10 || (ans == int.MaxValue/ 10 && pop > 7))
            //        return 0;
            //    if (ans < int.MinValue / 10 || (ans == int.MinValue/ 10 && pop < -8))
            //        return 0;
            //    ans = ans * 10 + pop;
            //    x /= 10;
            //}
            //return ans;
        }
    }
}