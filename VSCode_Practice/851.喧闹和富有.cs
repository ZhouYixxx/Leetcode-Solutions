/*
 * @lc app=leetcode.cn id=851 lang=csharp
 *
 * [851] 喧闹和富有
 */

// @lc code=start
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution851 {
    public void  Test()
    {
        var richer = new int[][]
        {
            new int[]{1,0},new int[]{2,1},new int[]{3,1},new int[]{3,7},new int[]{4,3},
            new int[]{5,3},new int[]{6,3},
        };
        var quiet = new int[]{3,2,5,4,6,1,7,0};
        var ans = LoudAndRich(richer,quiet);
    }

    public int[] LoudAndRich(int[][] richer, int[] quiet) 
    {
        return DFS(richer, quiet);
        //return Brute(richer, quiet);
    }

    /// <summary>
    /// 暴力法，时间复杂度O(mn²) 
    /// </summary>
    /// <param name="richer"></param>
    /// <param name="quiet"></param>
    /// <returns></returns>
    public int[] Brute(int[][] richer, int[] quiet) 
    {
        var ans = new int[quiet.Length];
        
        for (int i = 0; i < quiet.Length; i++)
        {
            var richerList = FindRicher(richer, i);
            var mostQuiet = int.MaxValue;
            var mostQuietIndex = -1;
            for (int j = 0; j < richerList.Count; j++)
            {
                if (mostQuiet > quiet[richerList[j]])
                {
                    mostQuiet = quiet[richerList[j]];
                    mostQuietIndex = richerList[j];
                }
            }
            ans[i] = mostQuietIndex;
        }
        return ans;
    }

    /// <summary>
    /// 时间复杂度O(m*n)
    /// </summary>
    /// <param name="richer"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private List<int> FindRicher(int[][] richer, int index)
    {
        var res = new HashSet<int>(){index};
        var queue = new Queue<int>();
        queue.Enqueue(index);
        while (queue.Count > 0)
        {
            var target = queue.Dequeue();
            for (int i = 0; i < richer.Length; i++)
            {
                if (richer[i][1] == target)
                {
                    queue.Enqueue(richer[i][0]);
                    res.Add(richer[i][0]);
                }
            }
        }
        return res.ToList();
    }

    /// <summary>
    /// 记忆化搜索，时间复杂度O(m+n) 
    /// </summary>
    /// <param name="richer"></param>
    /// <param name="quiet"></param>
    /// <returns></returns>
    public int[] DFS(int[][] richer, int[] quiet) 
    {
        var n = quiet.Length;
        var ans = new int[quiet.Length];
        Array.Fill(ans,-1);

        //建图
        //g[i]记录了比person[i]富有的人的索引列表
        var g = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            g[i] = new List<int>();
        }
        foreach (var r in richer)
        {
            //r[0]比r[1]富有
            g[r[1]].Add(r[0]);
        }

        //DFS
        for (int i = 0; i < n; i++)
        {
            DFSHelper(i,quiet,g,ans);
        }
        return ans;
    }

    /// <summary>
    /// 时间复杂度O(m+n)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="quiet"></param>
    /// <param name="g"></param>
    /// <param name="ans"></param>
    private void DFSHelper(int x,int[] quiet, List<int>[] g, int[] ans)
    {
        if (ans[x] != -1)
        {
            return;
        }
        ans[x] = x;
        var richerList = g[x];
        for (int i = 0; i < richerList.Count; i++)
        {
            var y = richerList[i];
            DFSHelper(y, quiet, g, ans);
            if (quiet[ans[y]] < quiet[ans[x]])
            {
                ans[x] = ans[y];
            }
        }
    }
}
// @lc code=end

