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
        // var stations = new int[10][];
        // stations[0] = new int[]{12575,171159};
        // stations[1] = new int[]{81909,101253};
        // stations[2] = new int[]{163732,164401};
        // stations[3] = new int[]{190025,65493};
        // stations[4] = new int[]{442889,31147};
        // stations[5] = new int[]{481202,166081};
        // stations[6] = new int[]{586028,206379};
        // stations[7] = new int[]{591952,52748};
        // stations[8] = new int[]{595013,9163};
        // stations[9] = new int[]{611883,217156};
        // var ans = MinRefuelStops1(1000000,70768, stations);
        var stations = new int[4][];
        stations[0] = new int[]{10,60};
        stations[1] = new int[]{20,30};
        stations[2] = new int[]{30,30};
        stations[3] = new int[]{60,40};
        var ans = MinRefuelStops2(100,10, stations);
    }
    
    //贪心加优先队列的方式
    public int MinRefuelStops(int target, int startFuel, int[][] stations) 
    {
        //使用sortedSet代替优先队列
        var sortedSet = new SortedSet<Tuple<int,int>>(new MyComparer());
        int mile = startFuel;
        int fuelIndex = 0;
        int count=0;
        while (mile < target)
        {
            //将驶过的加油站，按照油量排序存入sortedList
            while (fuelIndex < stations.Length && stations[fuelIndex][0] <= mile)
            {
                sortedSet.Add(new Tuple<int, int>(stations[fuelIndex][1], stations[fuelIndex][0]));
                fuelIndex++;
            }
            if (sortedSet.Count == 0)
                break;
            //没油了,选中途最多油的加油站，更新mile
            var maxFuel = sortedSet.Max;
            mile += maxFuel.Item1;
            sortedSet.Remove(maxFuel);
            count++;   
        }
        return mile < target ? -1 : count;
    }

    public class MyComparer : IComparer<Tuple<int, int>>
    {
        public int Compare(Tuple<int, int> x, Tuple<int, int> y)
        {
            if (x.Item1 > y.Item1)
            {
                return 1;
            }
            if (x.Item1 == y.Item1)
            {
                return x.Item2.CompareTo(y.Item2);
            }
            return -1;
        }
    }

    //动态规划方式
    public int MinRefuelStops1(int target, int startFuel, int[][] stations) 
    {
        //dp[i][j] = s,表示经过i个加油站，加油j次，能够行驶的最大距离为s,j <= i <= n
        var dp = new int[stations.Length+1][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[stations.Length+1];
            dp[i][0] = startFuel;
        }
        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                if (dp[i-1][j] >= stations[i-1][0])
                {
                    dp[i][j] = dp[i-1][j];
                }
                if (dp[i-1][j-1] >= stations[i-1][0])
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[i-1][j-1] + stations[i-1][1]);
                }
            }
        }
        //dp[n][0...n]遍历，找到最小的加油次数
        for (int i = 0; i < dp[dp.Length-1].Length; i++)
        {
            if (dp[dp.Length-1][i] >= target)
            {
                return i;
            }
        }
        return -1;
    }

    //滚动数组实现状态压缩
    public int MinRefuelStops2(int target, int startFuel, int[][] stations) 
    {
        //dp[i] = s,加油i次，能够行驶的最大距离为s,i <= n
        var dp = new int[stations.Length+1];
        dp[0] = startFuel;
        for (int i = 0; i < dp.Length; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                if (dp[j] >= stations[i-1][0])
                {
                    dp[j] = dp[j];
                }
                if (dp[j-1] >= stations[i-1][0])
                {
                    dp[j] = Math.Max(dp[j], dp[j-1] + stations[i-1][1]);
                }
            }
        }
        //dp[n][0...n]遍历，找到最小的加油次数
        for (int i = 0; i < dp.Length; i++)
        {
            if (dp[i] >= target)
            {
                return i;
            }
        }
        return -1;
    }

}

// @lc code=end

