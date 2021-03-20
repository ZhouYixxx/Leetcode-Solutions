using System;
using System.Collections.Generic;
using CodePractice.Core;

namespace CodePractice.LeetCode.BackTrack
{
    /// <summary>
    /// 回溯算法寻找斐波那契数列
    /// </summary>
    public class SplitArrayIntoFibonacciSequence_842 : LeetCodeBase
    {
        public SplitArrayIntoFibonacciSequence_842() : base("SplitArrayIntoFibonacciSequence_842")
        {
            var s = "0123";
            var res = SplitIntoFibonacci(s);
            for (int i = 0; i < res.Count; i++)
            {
                Console.Write(res[i]+", ");
            }
            Console.ReadKey();
        }

        public IList<int> SplitIntoFibonacci(string S)
        {
            var res = new List<int>();
            var nums = S.ToCharArray();
            var canFinish = BackTrack(res, nums, 0);
            return res;
        }

        public bool BackTrack(List<int> res, char[] digits, int index)
        {
            if (index == digits.Length && res.Count >= 3)
                return true;
            //考察index之后的数i
            for (int i = index; i < digits.Length; i++)
            {
                if (digits[index] == '0' && i > index)
                {
                    break;
                }
                //任何一个符合条件的数字的位数不可能超过整个数组的二分之一
                if ((i - index) >= digits.Length / 2)
                {
                    break;
                }
                var num = GenerateNumber(digits, index, i+1);
                if (num > Int32.MaxValue)
                {
                    break;
                }
                var size = res.Count;
                if (size >= 2 && res[size - 1] + res[size - 2] < num)
                {
                    break;
                }

                if (size < 2 || res[size-1] + res[size-2] == num)
                {
                    res.Add((int)num);
                    //找到了[index,i]区间形成的数字满足条件，可以跳出此次寻找，将index设置为i+1继续找
                    if (BackTrack(res, digits, i + 1))
                    {
                        return true;
                    }
                    //到最后也没找到符合要求的结果
                    res.RemoveAt(res.Count - 1);
                }
            }
            return false;
        }

        public bool BackTrack1(List<int> res, char[] digit, int index)
        {
            //边界条件判断，如果截取完了，并且res长度大于等于3，表示找到了一个组合。
            if (index == digit.Length && res.Count >= 3)
            {
                return true;
            }
            for (int i = index; i < digit.Length; i++)
            {
                //两位以上的数字不能以0开头
                if (digit[index] == '0' && i > index)
                {
                    break;
                }
                //任何一个符合条件的数字的位数不可能超过整个数组的二分之一
                if ((i - index) >= digit.Length / 2)
                {
                    break;
                }
                //截取字符串转化为数字
                long num = GenerateNumber(digit, index, i + 1);
                //如果截取的数字大于int的最大值，则终止截取
                if (num > Int32.MaxValue)
                {
                    break;
                }
                int size = res.Count;
                //如果截取的数字大于res中前两个数字的和，说明这次截取的太大，直接终止，因为后面越截取越大
                if (size >= 2 && num > (res[size - 1] + res[size - 2]))
                {
                    break;
                }
                if (size <= 1 || num == res[size - 1] + res[size - 2])
                {
                    //把数字num添加到集合res中
                    res.Add((int)num);
                    //如果找到了就直接返回
                    if (BackTrack1(res, digit, i + 1))
                        return true;
                    //如果没找到，就会走回溯这一步，然后把上一步添加到集合res中的数字给移除掉
                    res.RemoveAt(res.Count - 1);
                }
            }
            return false;
        }

        private long GenerateNumber(char[] digits, int start, int end)
        {
            long num = 0;
            for (int i = start; i < end; i++)
            {
                num = num * 10 + digits[i] - '0';
            }
            return num;
        }
    }
}