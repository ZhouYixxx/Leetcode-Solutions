/*
 * @lc app=leetcode.cn id=1079 lang=csharp
 *
 * [1079] 活字印刷
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution1079 
{
    public void Test()
    {
        var s = "ABA";
        var ans = NumTilePossibilities(s);
    }

    private int count;
    public int NumTilePossibilities(string tiles) 
    {
        var charArry = tiles.ToCharArray();
        //Array.Sort(charArry);
        var path = new List<string>();
        var used = new bool[tiles.Length];
        Backtrack(charArry, used);
        return count;    
    }

    private void Backtrack(char[] tiles, bool[] used)
    {
        var dupSet = new HashSet<char>();
        for (int i = 0; i < tiles.Length; i++)
        {
            if (dupSet.Contains(tiles[i]) || used[i])
            {
                continue;
            }
            dupSet.Add(tiles[i]);
            used[i] = true;
            count++;
            Backtrack(tiles, used);
            used[i] = false;
        }
    }
}
// @lc code=end

