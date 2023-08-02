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
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World!");
            // System.Console.WriteLine($"111, My Thread ID is :{Thread.CurrentThread.ManagedThreadId}");
            // AsyncTest();
            // System.Console.WriteLine($"222, My Thread ID is :{Thread.CurrentThread.ManagedThreadId}");
            //Console.ReadKey();
            var sol = new Solution_Offer09_ii();
            sol.Test(); 

            //aggregate用法测试
            // var test = new string[]{"B1","1F","2F","3F","4F"};
            // var res = test.Length == 1 ? $"\'{test[0]}\'" : test.Aggregate((cur,next)=>
            // {
            //     if (cur == test[0])
            //     {
            //         return $"\'{cur}\',\'{next}\'";
            //     }
            //      next = $"{cur},\'{next}\'";
            //      return next;
            // } );
            // var res2 = test.Aggregate((cur,next)=>string.IsNullOrEmpty(cur) ? $"{cur}" : $"{cur},{next}" ); 
            // var res3 = test.Aggregate((cur,next)=> $"{cur},\'{next}\'" ); 
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
