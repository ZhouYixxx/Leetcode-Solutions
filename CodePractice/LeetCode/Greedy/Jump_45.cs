using System;
using System.Security.Cryptography.X509Certificates;
using CodePractice.Core;

namespace CodePractice.LeetCode.Greedy
{
    public class Jump_45 : LeetCodeBase
    {
        public Jump_45() : base("Jump_45")
        {
            var nums = new int[] { 3,2,3};
            Console.WriteLine(Jump(nums));
            Console.ReadKey();
        }

        public int Jump(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return 0;
            }
            int count = 0;
            int start = 0;
            int end = 1;
            if (end >= nums.Length - 1)
            {
                return 1;
            }
            int max = 0;
            while (end < nums.Length)
            {
                for (int i = start; i < end; i++)
                {
                    if (max < nums[i] + i)
                    {
                        max = nums[i] + i;
                    }
                }
                start = end;
                end = max+1;
                count++;
            }
            return count;
        }
    }
}