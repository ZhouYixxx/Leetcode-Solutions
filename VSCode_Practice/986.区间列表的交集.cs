/*
 * @lc app=leetcode.cn id=986 lang=csharp
 *
 * [986] 区间列表的交集
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution986 {
    public void Test()
    {
        var firstList  = new int[][]
        {
            new int[]{0,2},
            new int[]{5,10},
            new int[]{13,23},
            new int[]{24,25},
        };
        var secondList = new int[][]
        {
            new int[]{1,5},
            new int[]{8,12},
            new int[]{15,24},
            new int[]{25,26},
        };
        var ans = IntervalIntersection(firstList,secondList);
    }
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) 
    {
        var ans = new List<int[]>();
        int index1 = 0, index2 = 0;
        while (index1 < firstList.Length && index2 < secondList.Length)
        {
            var first = firstList[index1];
            var second = secondList[index2];
            //不相交
            if (first[0] > second[1])
            {
                index2++;
                continue;
            }
            else if (first[1] < second[0])
            {
                index1++;
                continue;
            }
            //相交
            var start = Math.Max(first[0], second[0]);
            var end = Math.Min(first[1], second[1]);
            var intersect = new int[]{start, end};
            ans.Add(intersect);
            if (end == second[1])
            {
                index2++;
            }
            else if (end == first[1])
            {
                index1++;
            }

        }
        return ans.ToArray();
    }
}
// @lc code=end

