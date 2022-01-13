/*
 * @lc app=leetcode.cn id=473 lang=csharp
 *
 * [473] 火柴拼正方形
 */

// @lc code=start
using System.Collections.Generic;
using System;
public class Solution473 {
    public void Test()
    {
        var matches = new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        var ans = Makesquare(matches);
    }
    
    public bool Makesquare(int[] matchsticks) 
    {
        var sum = 0;
        for (int i = 0; i < matchsticks.Length; i++)
        {
            sum += matchsticks[i];
        }
        if (sum % 4 != 0)
        {
            return false;
        }
        Array.Sort(matchsticks);
        int len = sum / 4;
        var n = matchsticks.Length;
        var size = new int[4]{0,0,0,0};
        return DFS(n-1, len, size, matchsticks);

    }
    
    private bool DFS(int index, int len, int[] size, int[] matches)
    {
        if (index == -1)
        {
            return size[0] == size[1] && size[1] == size[2] && size[2] == size[3];
        }
        for (int i = 0; i < 4; i++)
        {
            if (i > 0 && size[i] == size[i-1])
            {
                continue;
            }
            if (size[i] + matches[index] > len)
            {
                continue;
            }
            size[i] += matches[index];
            var isOk = DFS(index-1, len, size, matches);
            if (isOk)
            {
                return true;
            }
            size[i] -= matches[index];
        }
        return false;
    }
}
// @lc code=end

