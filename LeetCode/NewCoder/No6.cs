using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace LeetCode
{
    public static class No6
    {
        public static string ZConvert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }
            var newStr = "";
            var arrayStr = new string[numRows];
            var charArray = s.ToCharArray();
            int index = 1;
            var interval = 1;
            for (int i = 0; i < charArray.Length; i++)
            {
                arrayStr[index-1] +=charArray[i];
                index += interval;
                if (index > numRows)
                {
                    index = numRows - 1;
                    interval = -1;
                }
                if (index < 1)
                {
                    index = 2;
                    interval = 1;
                }
            }

            for (int i = 0; i < arrayStr.Length; i++)
            {
                var subStr = arrayStr[i];
                newStr += subStr;
            }
            return newStr;
        }
    }
}