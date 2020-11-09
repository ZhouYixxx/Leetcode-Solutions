using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CodePractice.LeetCode.Array
{
    public class ArrayIntersection_349
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var set = new HashSet<int>();
            var set1 = new HashSet<int>(nums1);
            foreach (var num in nums2)
            {
                if (set1.Contains(num))
                {
                    set.Add(num);
                }
            }
            var array = new int[set.Count];
            int i = 0;
            foreach (var num in set)
            {
                array[i] = num;
                i++;
            }

            return array;
        }



        public void Test()
        {
            var nums1 = new int[]{ 4, 9, 5 };
            var nums2 = new int[]{ 9, 4, 9, 8, 4 };
            var array = Intersection(nums1, nums2);
            foreach (var num in array)
            {
                Console.Write(num+",");
            }
            Console.ReadKey();
        }
    }
}