/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
using System;

public class Solution739 {
    public void Test()
    {
        var temperatures  = new int[]{73, 74, 75, 71, 69, 72, 76, 73};
        var ans = DailyTemperatures(temperatures);
    }
    public int[] DailyTemperatures(int[] T) 
    {
        var res = new int[T.Length];
        var lastHigh = 0;
        var highTemp = T[0];
        for (int i = 1; i < T.Length; i++)
        {
            if (highTemp < T[i])
            {
                for (int j = lastHigh; j < i; j++)
                {
                    res[j] = i-lastHigh;
                }
                lastHigh = i;
                highTemp = T[i];
            }
        }
        return res;
    }
}
// @lc code=end

