using System;

namespace LeetCode
{
    /// <summary>
    /// 十六进制转化
    /// </summary>
    public class HuaWeiNo5
    {
        public static long HexadecimalConvert(string hexString)
        {
            hexString = hexString.ToLower();
            long result = 0;
            for (int i = 2; i < hexString.Length; i++)
            {
                var hexChar = hexString[i];
                var decimalValue = HexToDecimalDigit(hexChar);
                result = result * 16 + decimalValue;
            }
            return result;
        }

        private static int HexToDecimalDigit(char a)
        {
            if (a == 'a')
            {
                return 10;
            }
            else if (a == 'b')
            {
                return 11;
            }
            else if (a == 'c')
            {
                return 12;
            }
            else if (a == 'd')
            {
                return 13;
            }
            else if (a == 'e')
            {
                return 14;
            }
            else if (a == 'f')
            {
                return 15;
            }
            return a - '0';
        }
    }
}