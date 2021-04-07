using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace CodePractice.NewCoder.HuaWei
{
    public class No08_MergeDic
    {
        public static void MergeDic()
        {
            var number = int.Parse(Console.ReadLine());
            var dic = new Dictionary<int,int>();
            var pair = string.Empty;
            for (int i = 0; i < number; i++)
            {
                pair = Console.ReadLine();
                var split = pair.Split(' ');
                var key = int.Parse(split[0]);
                var value = int.Parse(split[1]);
                if (dic.TryGetValue(key, out var curValue))
                {
                    dic[key] = curValue + value;
                    continue;
                }
                dic.Add(key, value);
            }
            dic = dic.OrderBy(t => t.Key).ToDictionary(t => t.Key, t => t.Value);
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            Console.ReadKey();
        }
    }
}