/*
 * @lc app=leetcode.cn id=338 lang=csharp
 *
 * [338] 比特位计数
 */

// @lc code=start
using System;

public class Solution338 {
    public void Test()
    {
        var ans = CountBits(8);
    }

    public int[] CountBits(int num) {
        var array = new int[num+1];
        array[0] = 0;
        for (int i = 1; i < array.Length; i++)
        {
            //i是偶数
            if ((i & 1) == 0)
            {
                array[i] = array[i/2];
                continue;
            }
            //i是奇数
            array[i] = array[i-1]+1;
        }
        return array;
    }
}
// @lc code=end

