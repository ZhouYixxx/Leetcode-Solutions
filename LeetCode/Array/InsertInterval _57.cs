using System;
using System.Collections.Generic;

namespace CodePractice.LeetCode.Array
{
    public class InsertInterval__57
    {
        /// <summary>
        /// 使用While循环
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int index = 0;
            List<int[]> result = new List<int[]>();
            while (index < intervals.Length && intervals[index][1] < newInterval[0])
            {
                //寻找需要合并的区间
                result.Add(intervals[index]);
                index++;
            }

            while (index < intervals.Length && intervals[index][0] <= newInterval[1])
            {
                //待合并区间头小于当前区间尾
                newInterval[0] = System.Math.Min(newInterval[0], intervals[index][0]); //更新待合并区间头
                newInterval[1] = System.Math.Max(newInterval[1], intervals[index][1]); //更新待合并区间尾
                index++;
            }
            result.Add(newInterval);// 加入合并区间

            while (index < intervals.Length)
            {
                // 加入剩余区间
                result.Add(intervals[index]);
                index++;
            }
            return result.ToArray();
        }

        public void Test()
        {
            int[][] intervals = new int[][] { new []{6, 8} };
            int[] newInterval = new[] { 2, 3};
            var array = Insert(intervals, newInterval);
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