/*
 * @lc app=leetcode.cn id=367 lang=csharp
 *
 * [367] 有效的完全平方数
 */

// @lc code=start
using System;

public class Solution367 {
    public void Test()
    {
        var num = 2147395600;
        var ans = IsPerfectSquare(num);
    }

    //二分法
    public bool IsPerfectSquare(int num) 
    {
        if (num == 1)
        {
            return true;
        }
        long l = 2;
        long r = num/2;
        while (l <= r)
        {
            long mid = l + (r-l)/2;
            long res = (long)mid*(long)mid;
            if (res == num)
            {
                return true;
            }
            if (res > num)
            {
                r = mid-1;
            }
            if (res < num)
            {
                l = mid+1;
            }
        }
        return false;
    }
}
// @lc code=end

