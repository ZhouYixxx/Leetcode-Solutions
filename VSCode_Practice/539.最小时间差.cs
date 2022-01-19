/*
 * @lc app=leetcode.cn id=539 lang=csharp
 *
 * [539] 最小时间差
 */

// @lc code=start
using System.Collections.Generic;
using System.Linq;
using System;

public class Solution539 {
    public void Test()
    {
        var t = new List<string>(){"00:00","23:52","00:00"};
        var ans = FindMinDifference(t);
    }

    public int FindMinDifference(IList<string> timePoints) 
    {
        return FindMinDifference_Bucket(timePoints);
    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="timePoints"></param>
    /// <returns></returns>
    public int FindMinDifference_Sort(IList<string> timePoints) 
    {
        int MAX_Minute_Count = 24*60;
        if (timePoints.Count > MAX_Minute_Count)
        {
            return 0;
        }
        timePoints = timePoints.OrderBy(t=>t).ToList();
        var first = GetMinute(timePoints[0]);
        var last = GetMinute(timePoints[timePoints.Count-1]);
        var interval = first + MAX_Minute_Count - last;
        for (int i = 1; i < timePoints.Count; i++)
        {
            var value = GetMinute(timePoints[i]) - GetMinute(timePoints[i-1]);
            interval = Math.Min(value, interval);
        }
        return interval;
    }

    public int FindMinDifference_Bucket(IList<string> timePoints) 
    {
        int MAX_Minute_Count = 24*60;
        if (timePoints.Count > MAX_Minute_Count)
        {
            return 0;
        }
        var buckets = new int[MAX_Minute_Count];
        for (int i = 0; i < timePoints.Count; i++)
        {
            var minute = GetMinute(timePoints[i]);
            if (buckets[minute] > 0)
            {
                return 0;
            }
            buckets[minute] += 1;
        }
        var interval = int.MaxValue;
        int first = 0, last = -1;
        for (int i = 0; i < buckets.Length; i++)
        {
            if (buckets[i] == 0)
            {
                continue;
            }
            if (last == -1)
            {
                first = i;
            }
            else
            {
                interval = Math.Min(interval, i - last);
            }
            last = i;
        }
        interval = Math.Min(interval, first + MAX_Minute_Count - last);
        return interval;
    }

    private int GetMinute(string timeStr)
    {
        var timeArray = timeStr.Split(':').ToArray();
        var hour = int.Parse(timeArray[0]);
        var min = int.Parse(timeArray[1]);
        return hour *60 + min;
    }
}
// @lc code=end

