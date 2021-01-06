using System;
using System.Collections.Generic;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class LargeGroupPositions_830 : LeetCodeBase
    {
        public LargeGroupPositions_830() : base("LargeGroupPositions_830")
        {
            var s = "aaaaa";
            var list = LargeGroupPositions(s);
            foreach (var subList in list)
            {
                Console.WriteLine($"[{subList[0]}, {subList[1]}]");
            }
            Console.ReadKey();
        }

        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var list = new List<IList<int>>();
            if (s.Length < 3)
            {
                return list;
            }
            var start = 0;
            var end = 1;
            while (end < s.Length)
            {
                while (end < s.Length && s[end] == s[start])
                {
                    end++;
                }

                if (end - start > 2)
                {
                    var tempList = new List<int>(){start, end-1};
                    list.Add(tempList);
                }
                start = end;
                end++;
            }
            return list;
        }
    }
}