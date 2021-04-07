using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    public class RemoveDuplicateLetters_316 : LeetCodeBase
    {
        public RemoveDuplicateLetters_316() : base("RemoveDuplicateLetters_316")
        {
            var str = "abacb";
            var str1 = "cbacdcbc";
            Console.WriteLine(RemoveDuplicateLetters(str1));
            Console.ReadKey();
        }

        public string RemoveDuplicateLetters(string s)
        {
            var charArray = s.ToCharArray();
            if (charArray.Length <= 1)
            {
                return s;
            }
            var map = new Dictionary<char, int>();
            var containsMap = new Dictionary<char, bool>();
            //字典记录每个字符出现的次数
            for (int i = 0; i < charArray.Length; i++)
            {
                if (map.ContainsKey(charArray[i]))
                    map[charArray[i]]++;
                else
                    map.Add(charArray[i], 1);
                if (!containsMap.ContainsKey(charArray[i]))
                {
                    containsMap.Add(charArray[i], false);
                }
            }
            var stack = new Stack<char>();
            stack.Push(charArray[0]);
            containsMap[charArray[0]] = true;
            map[charArray[0]]--;
            for (int i = 1; i < charArray.Length; i++)
            {
                map[charArray[i]]--;
                while (containsMap[charArray[i]] == false && 
                       stack.Count > 0 && (stack.Peek() > charArray[i] && map[stack.Peek()] > 0))
                {
                    var top = stack.Pop();
                    containsMap[top] = false;
                    //map[top]--;
                }

                if (containsMap[charArray[i]] == false)
                {
                    stack.Push(charArray[i]);
                    containsMap[charArray[i]] = true;
                }
            }
            var res = new char[stack.Count];
            for (int i = res.Length - 1; i >= 0; i--)
            {
                res[i] = stack.Pop();
            }
            var sb = new StringBuilder();
            for (int i = 0; i < res.Length; i++)
            {
                sb.Append(res[i]);
            }
            return sb.ToString();
        }
    }
}