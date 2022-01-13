/*
 * @lc app=leetcode.cn id=1593 lang=csharp
 *
 * [1593] 拆分字符串使唯一子字符串的数目最大
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution1593 {
    public void Test()
    {
        var s = "wwwzfvedwfvhsww";
        var ans = MaxUniqueSplit(s);
    }

    private int max = 0;
    private int maxSplit = 1;
    public int MaxUniqueSplit(string s) 
    {
        var path = new HashSet<string>();
        BackTrack(0, s, path);
        //backtrack2(0,0,s, path);
        return max;
    }

    private void BackTrack(int start, string s, HashSet<string> path)
    {
        if (start >= s.Length)
        {
            max = Math.Max(path.Count, max);
            return;
        }
        string sb = "";
        for (int i = start; i < s.Length; i++)
        {
            //剪枝：剩下的子串按最大计（每个字符作为一个子串），都不能超过max，则可以直接返回
            var leftCount = s.Length - i + 1;
            if (path.Count + leftCount <= max)
            {
                return;
            }
            sb += s[i];
            if (path.Contains(sb))
            {
                continue;
            }
            path.Add(sb);
            BackTrack(i+1, s, path);
            path.Remove(sb);
        }
    }

    public void backtrack2(int index, int split, string s, HashSet<string> path) 
    {
        int length = s.Length;
        if (index >= length) 
        {
            if (maxSplit < split)
            {
                maxSplit = split;
            }
        } 
        else 
        {
            for (int i = index; i < length; i++) 
            {
                var substr = s.Substring(index, i + 1-index);
                if (path.Add(substr)) 
                {
                    backtrack2(i + 1, split + 1, s, path);
                    path.Remove(substr);
                }
            }
        }
    }
}
// @lc code=end

