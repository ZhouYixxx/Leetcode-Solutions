/*
 * @lc app=leetcode.cn id=278 lang=csharp
 *
 * [278] 第一个错误的版本
 */

// @lc code=start
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
using System;

public class Solution278 
{
    public void Test()
    {
        var n = 10000;
        var ans = FirstBadVersion(n);
    }

    private bool IsBadVersion(int version)
    {
        return version >= 1;
    }

    public int FirstBadVersion(int n) 
    {
        var l = 1;
        var r = n;
        while (l <= r)
        {
             if (l == r)
             {
                 if (IsBadVersion(l))
                 {
                    return l; 
                 }
                 return l-1;
             }
             var mid = l+(r-l)/2;
             var isBad = IsBadVersion(mid);
             if (isBad)
             {
                 r = mid;
             }
             else
             {
                 l = mid+1;
             }
             
        }
        return -1;
    }
}
// @lc code=end

