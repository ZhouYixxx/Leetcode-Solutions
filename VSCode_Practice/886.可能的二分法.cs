/*
 * @lc app=leetcode.cn id=886 lang=csharp
 *
 * [886] 可能的二分法
 */

// @lc code=start
using System.Collections.Generic;

public class Solution886 
{
    public void Test()
    {
        var n = 5;
        var s = "[[1,2],[2,3],[3,4],[4,5],[1,5]]";
        var g = DataStructureHelper.ConvertStringToTwoDimenArray(s);
        var ans = PossibleBipartition(n, g);
    }

    public bool PossibleBipartition(int n, int[][] dislikes) 
    {
        return PossibleBipartition_DFS(n, dislikes);
    }

    private bool PossibleBipartition_DFS(int n, int[][] dislikes) 
    {
        //无向图初始化
        var graph = new List<int>[n+1];
        for (int i = 0; i <= n; i++)
        {
            graph[i] = new List<int>();
        }
        for (int i = 0; i < dislikes.Length; i++)
        {
            var node1 = dislikes[i][0];
            var node2 = dislikes[i][1];
            graph[node1].Add(node2);
            graph[node2].Add(node1);
        }
        //判断二分图
        //0：未染色，1：红色，2：黑色
        var colors = new int[n+1];
        for (int i = 1; i <= n; i++)
        {
            if (colors[i] == 0)
            {
               var isvalid = DFS1(i, colors, graph, 1);
               if (!isvalid)
               {
                   return false;
               }
            }
        }
        return true;
    }

    private bool DFS(int i, int[] colors, List<int>[] graph, int color)
    {
        //已经染色过且颜色与当前颜色不同，说明不能形成二分图，返回false
        if (colors[i] != 0 && colors[i] != color)
        {
            return false;
        }
        colors[i] = color;
        var newColor = color == 1 ? 2 : 1;
        foreach (var node in graph[i])
        {
            if (colors[node] == 0)
            {
                var isvalid = DFS(node, colors, graph, newColor);
                if (!isvalid)
                {
                    return false;
                }     
            }
            else if (colors[node] != newColor)
            {
                return false;
            }
        }
        return true;
    }


    /// <summary>
    /// DFS优化
    /// </summary>
    /// <param name="i"></param>
    /// <param name="colors"></param>
    /// <param name="graph"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    private bool DFS1(int i, int[] colors, List<int>[] graph, int color)
    {
        //已经染色过且颜色与当前颜色不同，说明不能形成二分图，返回false
        if (colors[i] != 0)
        {
            return colors[i] == color;
        }
        colors[i] = color;
        var newColor = color == 1 ? 2 : 1;
        foreach (var node in graph[i])
        {
            var isvalid = DFS(node, colors, graph, newColor);
            if (!isvalid)
            {
                return false;
            }  
        }
        return true;
    }
}
// @lc code=end

