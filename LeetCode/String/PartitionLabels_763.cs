using System;
using System.Collections.Generic;

namespace CodePractice.LeetCode.String
{
    public class PartitionLabels_763
    {
        public IList<int> PartitionLabels(string S)
        {
            //用一个字典记录所有的字母出现的最远位置
            var dic = new Dictionary<char, int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (!dic.ContainsKey(S[i]))
                {
                    dic.Add(S[i],i);
                    continue;
                }
                dic[S[i]] = i;
            }

            var list = new List<int>();
            var start = 0;
            var end = 0;
            for (int i = 0; i < S.Length; i++)
            {
                var charEnd = dic[S[i]];
                end = System.Math.Max(charEnd, end);
                if (i == end)
                {
                    list.Add(end - start + 1);
                    start = end + 1;
                }
            }

            return list;
        }

        public void Test()
        {
            var list = PartitionLabels("ababcbacadefegdehijhklij");
            foreach (var item in list)
            {
                Console.Write($"{item},");
            }
            Console.ReadKey();
        }
    }
}