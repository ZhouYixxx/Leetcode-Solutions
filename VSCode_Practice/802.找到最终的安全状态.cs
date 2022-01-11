/*
 * @lc app=leetcode.cn id=802 lang=csharp
 *
 * [802] 找到最终的安全状态
 */

// @lc code=start
using System.Collections.Generic;

public class Solution802 
{
    public void Test()
    {
        var s = "[[1,2],[2,3],[5],[0],[5],[],[]]";
        var graph = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var ans = EventualSafeNodes(graph);
    }

    public IList<int> EventualSafeNodes(int[][] graph) 
    {
        var res = new List<int>();
        var n = graph.Length;
        //标记数组：0-未访问，1-成环，2-安全
        var mark = new int[n];
        for (int i = 0; i < n; i++)
        {
            var isSafe = DFS(i, graph, mark);
            if (isSafe)
            {
                res.Add(i);
            } 
        }
        return res;
    }

    private bool DFS(int i, int[][] graph, int[] mark)
    {
        if (mark[i] == 1)
        {
            return false; 
        }
        if (mark[i] == 2)
        {
            return true;
        }
        mark[i] = 1;
        for (int j = 0; j < graph[i].Length; j++)
        {
            var isSafe = DFS(graph[i][j], graph, mark);
            //有一个成环，则递归上所有节点均不安全
            if (!isSafe)
            {
                return false;
            }
        }
        mark[i] = 2;
        return true;
    }
}
// @lc code=end

