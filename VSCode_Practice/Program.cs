using System;
using System.Collections.Generic;
using System.Linq;


namespace VSCode_Practice
{
    class Program
    {
        private static int[] _nums = new int[1000];
        static void Main(string[] args)
        {
            var sol = new Solution314();
            sol.Test();
        }

        private static async Task AsyncTest()
        {
            var res = await LongTimeTask();
            Console.WriteLine(res);
        }

        private static async Task<string> LongTimeTask()
        {
            return await Task.Run(()=>{
                Console.WriteLine($"Helo I am LongTimeTask. My Thread ID is :{Thread.CurrentThread.ManagedThreadId}" );
                Thread.Sleep(3000);
                Console.WriteLine($"Helo I am LongTimeTask after sleep 3s. My Thread ID is :{Thread.CurrentThread.ManagedThreadId}" );
                return "LongTimeTask Finished";
            });
        } 

        private static int XOR_Test()
        {
            var nums = new int[]{1,2,3,4,4,5,6};
            var xor = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                xor ^= nums[i];
                if (i != nums.Length -1)
                {
                     xor ^= (i+1);
                }
            }
            return xor;
        }

        private static void YieldTest(){
            foreach (var item in GetEvenNumberList()) 
            {
                Console.Write(item+", "); //输出偶数测试
            }
        }

        private static IEnumerable<int> GetEvenNumberList()
        {
            foreach (var item in _nums)
            {
                if ((item & 1) == 0)
                {
                    yield return item;
                }
            }
            yield break;
        }
    }
}
