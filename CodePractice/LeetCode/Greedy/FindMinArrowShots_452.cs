using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Greedy
{
    public class FindMinArrowShots_452 : LeetCodeBase
    {
        public FindMinArrowShots_452() : base("FindMinArrowShots_452")
        {
            var arrows = new int[][] {new[] { 9, 12}, new[] { 1, 10}, new []{4,11}, new []{8,12}, new []{3,9}, new []{6,9}, new []{6,7}};
            //var arrows = new int[][] {new[] { -3,-1 }, new[] { 20, 30}};
            Console.WriteLine(FindMinArrowShots(arrows));
            Console.ReadKey();
        }

        public int FindMinArrowShots(int[][] points)
        {
            if (points.Length <= 1)
                return points.Length;
            //按照左端点从小到大排列
            System.Array.Sort(points, Comparison);
            int count = 1;
            int i = 0;
            while (i < points.Length - 1)
            {
                int[] cur = points[i];
                int lastIndex = i + 1;
                int left = cur[0];
                int right = cur[1];
                while (lastIndex < points.Length && points[lastIndex][0] <= right)
                {
                    right = System.Math.Min(right, points[lastIndex][1]);
                    lastIndex++;
                }
                i = lastIndex;
                if (lastIndex < points.Length)
                {
                    count++;
                }
            }
            return count;
        }

        private int Comparison(int[] x, int[] y)
        {
            return (x[0] <= y[0]) ? -1 : 1;
        }

    }
}