using System;
using System.Runtime.InteropServices.ComTypes;

namespace CodePractice.LeetCode.Bit
{
    public static class BitSkills
    {
        /// <summary>
        /// 数字是否是奇数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsOdd(int number)
        {
            //偶数的最后一位是0，奇数是1
            return (number & 1) == 0;
        }

        /// <summary>
        /// 返回二进制中1的个数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetOneCount(int number)
        {
            int count = 0;
            while (Convert.ToBoolean(number))
            {
                number = number & (number - 1);
                count++;
            }
            return count;
        }

        /// <summary>
        /// 求2的幂次数
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public static int Pow_2(int power)
        {
            return 1 << power;
        }

        /// <summary>
        /// 返回二进制中0的个数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetZeroCount(int number)
        {
            int count = 0;
            while (Convert.ToBoolean(number))
            {
                number = number & (number - 1);
                count++;
            }
            return 31-count;
        }
    }
}