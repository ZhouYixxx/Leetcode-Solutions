using System;
using System.Collections.Generic;

public class Solution323 
{
    public void Test()
    {
        var edges = new int[][]
        {
            new int[]{0,1}, new int[]{1,2}, new int[]{3,4},
        };
        var n = 5;
        var ans = CountComponents(n, edges);
    }

    /// <summary>
    /// DFS
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <returns></returns>
    public int CountComponents(int n, int[][] edges) 
    {
        var adj = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>());
        }
        for (int i = 0; i < edges.Length; i++)
        {
            adj[edges[i][0]].Add(edges[i][1]);
            adj[edges[i][1]].Add(edges[i][0]);
        }
        //DFS
        int count = 0;
        var visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }
            DFS(adj, i, visited);
            count++;
        }
        return count;
    }

    private void DFS(List<List<int>> adj, int i, bool[] visited)
    {
        visited[i] = true;
        var list = adj[i];
        for (int k = 0; k < list.Count; k++)
        {
            if (visited[list[k]])
            {
                continue;
            }
            DFS(adj, list[k], visited);
        }
    }    
}