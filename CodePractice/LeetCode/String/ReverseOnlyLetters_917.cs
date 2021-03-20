/*
917. 仅仅反转字母
给定一个字符串 S，返回 “反转后的” 字符串，其中不是字母的字符都保留在原地，而所有字母的位置发生反转。

示例 2：
输入："a-bC-dEf-ghIj"
输出："j-Ih-gfE-dCba"

 */
using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.String
{
    public class ReverseOnlyLetters_917 : LeetCodeBase
    {
        //双指针法，时间复杂度O(n),空间复杂度O(n)
        public static string ReverseOnlyLetters(string S)
        {
            //指针reverseIndex从右往左
            int reverseIndex = S.Length - 1;
            char[] sArray = S.ToCharArray();
            //指针i从左往右
            int i = 0;
            while (i < reverseIndex)
            {
                var cha = sArray[i];
                var reverCha = sArray[reverseIndex];
                //任意一个指针对应的值不是字母，则跳到下一个字符
                if (cha < 'A' || cha>'z' || (cha<'a' && cha>'Z'))
                {
                    i++;
                    continue;
                }
                if (reverCha < 'A' || reverCha > 'z' || (reverCha < 'a' && reverCha > 'Z'))
                {
                    reverseIndex--;
                    continue;
                }
                //两个指针对应的都是字符，进行交换
                char temp = cha;
                sArray[i] = reverCha;
                sArray[reverseIndex] = temp;
                i++;
                reverseIndex--;
            }
            var newStr = new string(sArray);
            return newStr;
        }

        public static void Test()
        {
            Console.WriteLine(ReverseOnlyLetters("a-bC-dEf-ghIj"));
            Console.ReadKey();
        }

        public ReverseOnlyLetters_917() : base("ReverseOnlyLetters_917")
        {
            Test();
        }
    }
}