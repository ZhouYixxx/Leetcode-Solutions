using System;
using System.IO;
using System.Security.Cryptography;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class GasStation_134 : LeetCodeBase
    {
        public void Test()
        {
            //var gas = new int[] { 1, 2, 3, 4, 5 };
            //var cost = new int[] { 3, 4, 5, 1, 2 };
            var gas = new int[] { 1, 2, 3, 4, 5 };
            var cost = new int[] { 3, 4, 5, 1, 2 };
            Console.Write(CanCompleteCircuit(gas, cost));
            Console.ReadKey();
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int rest = 0, start = 0, sum = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                //总油量和总消耗的比较
                sum += gas[i] - cost[i];
                //到第i站后余下油量
                rest += gas[i] - cost[i];
                //无法到达i+1站点，这证明：1.从[0，i]中间任何一站出发都不可能通过i+1，应该从i+1站点重新出发，start = i+1；
                //2. 从0到i区间是可以到达的
                if (rest < 0)
                {
                    start = i + 1;
                    rest = 0;
                }
            }
            //sum<0说明总油量小于总消耗，肯定不能闭环
            return sum < 0 ? -1 : start;
        }

        public GasStation_134() : base("GasStation_134")
        {
            Test();
        }
    }
}