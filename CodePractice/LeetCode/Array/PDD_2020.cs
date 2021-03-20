/*给定一个整数N，代表N个盒子。第i个盒子当中有i个球。
我们可以选定一个N以内的自然数X，每次会把所有盒中小球数量大于等于X的盒子都减少X个球。现在想要用最少的步骤将所有盒子的球清空，请问最少需要多少次操作？
返回最少操作次数K
举例： 以数组Cn表示盒子中球的个数
N=1，一个盒子一个球，Cn=[1],取X=1，一次操作，K=1
N=3，Cn=[1,2,3]，取X=2，Cn=[1,0,1],再取X=1，Cn=[0,0,0],两次操作，K=2
N=6，Cn=[1,2,3,4,5,6]，取X=3，Cn=[1,2,0,1,2,3],再取X=2，Cn=[1,0,0,1,0,1],再取X=1，Cn=[0,0,0,0,0,0]，,三次操作，K=3
 */

using System;
using System.Collections.Generic;
using System.Text;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    //复杂度O(logN)
    public class PDD_2020 : LeetCodeBase
    {
        public PDD_2020() : base("PDD_2020")
        {
            var pr = new StringBuilder();
            int n = 100;
            var showArray = new int[n];
            var showBd = new StringBuilder();
            var list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                showArray[i] = i + 1;
                showBd.Append($"{showArray[i]} ");
            }
            list.Add(showBd.ToString());
            showBd.Clear();
            Console.WriteLine($"N={n}, K={GetMinCount(n, pr, showArray, showBd, list)}");
            Console.WriteLine(pr.ToString());
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadKey();
        }

        private int GetMinCount(int n,StringBuilder process,int[] showArray, StringBuilder showArrayBuilder, List<string> arrayProcessList)
        {
            if (n <= 1)
            {
                process.Append("1");
                var arrayProcess = MinusCount(showArray, n, showArrayBuilder);
                arrayProcessList.Add(arrayProcess);
                showArrayBuilder.Clear();
                return n;
            }
            if (n > 1)
            {
                var x = (int)System.Math.Ceiling(n / 2.0);
                process.Append($"{x}->");
                var arrayProcess = MinusCount(showArray, x, showArrayBuilder);
                arrayProcessList.Add(arrayProcess);
                showArrayBuilder.Clear();
            }
            n = n / 2;
            return GetMinCount(n, process, showArray, showArrayBuilder,arrayProcessList) + 1;
        }

        private string MinusCount(int[] nums,int k, StringBuilder showArrayBuilder)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= k)
                {
                    nums[i] -= k;
                }
                showArrayBuilder.Append($"{nums[i]} ");
            }
            return showArrayBuilder.ToString();
        }
    }
}