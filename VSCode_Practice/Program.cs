using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace study
{
    class Program
    {
        private static int[] _nums = new int[1000];
        static void Main(string[] args)
        {
            var sol = new Solution215();
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
