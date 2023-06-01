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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index">loop from n-1 to -1, n is the count of matchStickes</param>
    /// <param name="edgeLength">the edge length of square</param>
    /// <param name="edges">the array contains four edge length of square</param>
    /// <param name="matches">the match array</param>
    /// <returns></returns>
    private bool DFS_Ver2(int index, int edgeLength, int[] edges, int[] matches)
    {
        if (index < 0)
        {
            return edges[0] == edges[1] && edges[1] == edges[2] && edges[2] == edges[3];
        }
        for (int i = 0; i < 4; i++)
        {
            //剪枝条件1：edges[i] + matches[index] > edgeLength，说明matches[index]不能放在edges[i]下，直接跳过
            if (edges[i] + matches[index] > edgeLength)
            {
                continue;
            }
            //剪枝条件2：既然循环走到了edges[i]，说明edges[i-1]的尝试已经失败了,因为DFS是一条道走到底的，
            //因此如果edges[i] == edges[i-1]，edges[i]必然也无法成功，直接跳过
            if (i > 0 && edges[i] == edges[i-1])
            {
                continue;
            }
            edges[i] += matches[index];
            var isValid = DFS_Ver2(index-1, edgeLength, edges, matches);
            if (isValid)
            {
                return true;
            }
            edges[i] -= matches[index];
        }
        return false;
    }
}
// @lc code=end

