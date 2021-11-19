/*
 * @lc app=leetcode.cn id=120 lang=csharp
 *
 * [120] 三角形最小路径和
 */

// @lc code=start
using System.Collections.Generic;
using System.Linq;
using System;

public class Solution120 {
    public void Test()
    {
        var triangle = new List<IList<int>>()
        {
            new List<int>(){2},
            new List<int>(){3,4},
            new List<int>(){6,5,7},
            new List<int>(){4,1,8,3},
        };
        var res = new List<List<int>>();
        var visited = new bool[triangle.Count][];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[triangle[i].Count];
        }
        DFS(triangle,0,0,new List<int>(),res);
        var min = int.MaxValue;
        for (int i = 0; i < res.Count; i++)
        {
            var sum = res[i].Sum();
            min = Math.Min(sum,min);
        }
        //var ans = MinimumTotal(triangle);
    }

    public int MinimumTotal(IList<IList<int>> triangle) 
    {
        var m = triangle.Count;
        var dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[triangle[i].Count];
            dp[i][0] = i == 0 ? triangle[0][0] : dp[i-1][0] + triangle[i][0];
        }
        for (int i = 1; i < m; i++)
        {
            var n = dp[i].Length;
            for (int j = 1; j < n; j++)
            {
                if (j > i-1)
                {
                    dp[i][j] = dp[i-1][j-1] + triangle[i][j];
                }
                else
                {
                    dp[i][j] = Math.Min(dp[i-1][j-1], dp[i-1][j]) + triangle[i][j];   
                }
            }
        }
        var min = Int32.MaxValue;
        for (int i = 0; i < dp[m-1].Length; i++)
        {
            min = Math.Min(min,dp[m-1][i]);
        }
        return min;
    }

    public void DFS(IList<IList<int>> triangle, int i, int j, List<int> path, List<List<int>> res)
    {
        if (i == triangle.Count)
        {
            res.Add(new List<int>(path));
            return;
        }
        path.Add(triangle[i][j]);
        var count = path.Count;
        DFS(triangle,i+1,j,path,res);
        for (int k = path.Count-1; k >= count; k--)
        {
            path.RemoveAt(k);
        }
        //如果已经是最后一行，没必要走下去，否则会重复写入相同的路径数组
        if (i == triangle.Count -1)
        {
            return;
        }
        DFS(triangle,i+1,j+1,path,res);
        for (int k = path.Count-1; k >= count; k--)
        {
            path.RemoveAt(k);
        }
    }

}
// @lc code=end

