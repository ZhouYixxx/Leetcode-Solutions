using System;
using System.Collections.Generic;
using CodePractice.Core;
//重构字符串，保证无相同的相邻字符。
namespace CodePractice.LeetCode.Greedy
{
    public class ReorganizeString_767 :LeetCodeBase
    {
        public ReorganizeString_767() : base("ReorganizeString_767")
        {
            var s = "aabaca";
            Console.WriteLine(ReorganizeString(s));
            Console.ReadKey();
        }

        public string ReorganizeString(string S)
        {
            //第一步判断是否能做到无相邻字符
            //记录每个字符的出现次数，如果某个字符出现次数超过(n+1)/2,则该字符必然存在相邻
            var countDic = new Dictionary<char, int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (countDic.ContainsKey(S[i]))
                {
                    countDic[S[i]]++;
                    if (countDic[S[i]] > (S.Length +1)/2)
                    {
                        return "";
                    }
                }
                else
                    countDic.Add(S[i], 1);
            }
            var pairArray = new KeyValuePair<char,int>[countDic.Count];
            int index = 0;
            foreach (var pair in countDic)
            {
                pairArray[index] = pair;
                index++;
            }
            var result = new char[S.Length];
            //如何生成这种字符串
            index = 0;
            System.Array.Sort(pairArray, Comparison);
            for (int i = 0; i < pairArray.Length; i++)
            {
                var count = pairArray[i].Value;
                var character = pairArray[i].Key;
                while (count > 0)
                {
                    result[index] = character;
                    index += 2;
                    if (index>=result.Length)
                    {
                        index = 1;
                    }
                    count--;
                }
            }
            return new string(result);
        }

        private int Comparison(KeyValuePair<char, int> x, KeyValuePair<char, int> y)
        {
            return y.Value - x.Value;
        }
    }
}