/*
 * @lc app=leetcode.cn id=875 lang=csharp
 *
 * [875] 爱吃香蕉的珂珂
 */

// @lc code=start
using System;

public class Solution875 {
    public void Test()
    {
        var piles = new int[]{29,18};
        var h = 6;
        var ans = MinEatingSpeed(piles,h);
    }

    public int MinEatingSpeed(int[] piles, int h) 
    {
        var maxSpeed = 0;
        var minSpeed = 1;
        for (int i = 0; i < piles.Length; i++)
        {
            maxSpeed = Math.Max(maxSpeed, piles[i]);
        }
        //找到最大速度后，在最小最大速度之间使用二分法
        while (minSpeed <= maxSpeed)
        {
            var mid = minSpeed + (maxSpeed-minSpeed)/2;
            var eatingHours = GetEatingTime(piles, mid);
            //速度太慢
            if (eatingHours > h)
            {
                minSpeed = mid+1;   
            }
            //速度已经足够快，但是否可以慢一点
            else
            {
                maxSpeed = mid-1;
            }
        }
        return minSpeed;
    }

    private int GetEatingTime(int[] piles, int speed)
    {
        int hours = 0;
        for (int i = 0; i < piles.Length; i++)
        {
            int hour = (int)Math.Ceiling(1.0d*piles[i]/speed);
            hours += hour;
        }
        return hours;
    }
}
// @lc code=end

