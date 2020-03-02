using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.LeecCode;
using LeetCode.BasicAlgorithms;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //No7 整数反转
            //var rev = No7.Reverse(-120);
            //Console.WriteLine(rev);

            //No6 Z字形转换
            //var rev = No6.ZConvert("AB",1);
            //Console.WriteLine(rev);
            //Console.ReadKey();

            //No3 最长的子串
            //var rev = No3_longestSubString.LongestSubString("abcabcbb");
            //Console.WriteLine(rev);
            //Console.ReadKey();

            //HuaweiNo1最后一个字符串长度
            //var input = Console.ReadLine();
            //var rev = HuaWeiNo1.GetLastStringLength(input);
            //Console.WriteLine(rev);
            //Console.ReadKey();

            //HuaweiNo2计算字符个数
            //var input = Console.ReadLine();
            //var target = Console.Read();
            //var rev = HuaweiNo2.GetCount(input, (char)target);
            //Console.WriteLine(rev);
            //Console.ReadKey();


            //bool needNextCase = true;
            //while (needNextCase)
            //{
            //    var source = new List<int>();
            //    var isDemical = true;
            //    while (isDemical)
            //    {
            //        isDemical = Int32.TryParse(Console.ReadLine(), out int count);
            //        if (!isDemical)
            //        {
            //            needNextCase = false;
            //            break;
            //        }

            //        for (int i = 0; i < count; i++)
            //        {
            //            var value = Int32.Parse(Console.ReadLine());
            //            source.Add(value);
            //        }
            //    }
            //    var newArr = HuaWeiNo3.RandomNumber(source.Count, source.ToArray());
            //    foreach (var item in newArr)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.ReadKey();

            //#region 二分法

            ////二分法
            //var count = Int32.Parse(Console.ReadLine());
            //var list = new List<int>();
            //for (int i = 0; i < count; i++)
            //{
            //    var value = (new Random()).Next(1, 100);
            //    list.Add(value);
            //}
            //list.Sort();
            //var array = list.ToArray();
            //var search = BinarySearch.Search(array, 57);

            //#endregion

            //#region 华为No4：字符串分隔

            //var input1 = System.Console.ReadLine();
            //var input2 = System.Console.ReadLine();
            //var stringArray = HuaWeiNo4.SplitString(input1, input2);
            //for (int i = 0; i < stringArray.Length; i++)
            //{
            //    if (i == stringArray.Length -1)
            //    {
            //        Console.Write(stringArray[i]);
            //        continue;
            //    }
            //    Console.WriteLine(stringArray[i]);
            //}
            //Console.ReadKey();
            //#endregion

            //#region 华为No5：十六进制转换

            //var deque = new Queue<string>();
            //string input;
            //while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            //{
            //    var result = HuaWeiNo5.HexadecimalConvert(input);
            //    deque.Enqueue(result.ToString());
            //}

            //while (deque.Count > 0)
            //{
            //    var item = deque.Dequeue();
            //    if (deque.Count == 0)
            //    {
            //        Console.Write(item);
            //        continue;
            //    }
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            //#endregion

            #region 华为No6：质因数分解

            var input = Console.ReadLine();
            var ulData = long.Parse(input);
            var str = HuaWeiNo6.PrimeFactorization(ulData);
            Console.Write(str);
            Console.ReadKey();
            #endregion
        }
    }
}
