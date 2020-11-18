using System;
using System.Collections.Generic;

namespace CodePractice.LeetCode.Array
{
    public class MergeInterval_56
    {
        public int[][] Merge(int[][] intervals)
        {
            System.Array.Sort(intervals, Comparison);
            int start = intervals[0][0];
            int end = intervals[0][1];
            var mergeIntervals = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                if (i == intervals.Length -1)
                {
                    mergeIntervals.Add(new[] { start, end });
                    continue;
                }
                //比较当前区间的右端点与下一个区间的左端点，判断合并
                var nextStart = intervals[i + 1][0];
                var nextEnd = intervals[i + 1][1];
                if (end >= nextStart)
                {
                    end = System.Math.Max(end, nextEnd);
                }
                else
                {
                    mergeIntervals.Add(new[] {start, end});
                    start = System.Math.Max(start, nextStart);
                    end = System.Math.Max(end, nextEnd);
                }
            }
            return mergeIntervals.ToArray();
        }

        private int Comparison(int[] x, int[] y)
        {
            return x[0] - y[0];
        }

        public void Test()
        {
            var intervals = new int[][]
            {
                //new int[] {2, 6}, new int[] {1, 4}, new int[] {8, 12}, new int[] {15, 18}
                new int[] {1, 4}, new int[] {0, 4}
            };
            var array = Merge(intervals);
            foreach (var interval in array)
            {
                if (interval == null)
                {
                    continue;
                }
                Console.WriteLine($"{interval[0]}, {interval[1]}");
            }
            Console.ReadKey();
        }
    }
}