/*
 * @lc app=leetcode.cn id=871 lang=csharp
 *
 * [871] 最低加油次数
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution871 {
    public void Test()
    {
        var stations = new int[1][];
        stations[0] = new int[]{10,60};
        // stations[1] = new int[]{20,30};
        // stations[2] = new int[]{30,30};
        // stations[3] = new int[]{60,40};
        var ans = MinRefuelStops(70,20, stations);
    }
    
    public int MinRefuelStops(int target, int startFuel, int[][] stations) 
    {
        Array.Sort(stations,(t1,t2)=>t1[1].CompareTo(t2[1]));
        int mile = startFuel;
        int fuelIndex = stations.Length-1;
        while (mile < target && fuelIndex >= 0)
        {
            var fuelCount = stations[fuelIndex][1];
            mile+=fuelCount;
            fuelIndex--;
        }
        if (mile < target)
        {
            return -1;
        }
        return stations.Length - fuelIndex-1;
    }
}
// @lc code=end

