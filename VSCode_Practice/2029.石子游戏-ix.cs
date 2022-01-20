/*
 * @lc app=leetcode.cn id=2029 lang=csharp
 *
 * [2029] 石子游戏 IX
 */

// @lc code=start
using System;

public class Solution2029 {
    public bool StoneGameIX(int[] stones) 
    {
        return StoneGameIX_Gambling(stones);
    }

    private bool StoneGameIX_Gambling(int[] stones)
    {
        var s = new int[3];
        for (int i = 0; i < stones.Length; i++)
        {
            var r = stones[i] % 3;
            s[r] += 1;
        }
        if (s[0] % 2 == 0)
        {
            return s[1] != 0 && s[2] != 0;
        }
        else
        {
            return Math.Abs(s[1] - s[2]) > 2;
        }
    } 
}
// @lc code=end

