/*
 * @lc app=leetcode.cn id=344 lang=csharp
 *
 * [344] 反转字符串
 */

// @lc code=start
using System;

public class Solution344 {
    public void ReverseString(char[] s) {
        int l = 0, r = s.Length-1;
        while (l < r)
        {
            var temp = s[l];
            s[l] = s[r];
            s[r] = temp;
            l++;
            r--;
        }
    }
}
// @lc code=end

