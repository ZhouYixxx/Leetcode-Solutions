/*
 * @lc app=leetcode.cn id=684 lang=csharp
 *
 * [684] 冗余连接
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution684 {
    public void Test()
    {
        var edges = new int[][]
        {
            new int[]{1,2},
            new int[]{1,3},
            new int[]{5,6},
            new int[]{2,4},
            new int[]{2,5},
            new int[]{3,6},
        };
        var ans = TopoSort(edges);
    }

    /// <summary>
    /// DFS方法
    /// </summary>
    /// <param name="edges"></param>
    /// <returns></returns>
    public int[] FindRedundantConnection(int[][] edges) 
    {
        var graph = new Dictionary<int, List<int>>();
        var n = edges.Length;
        var visited = new bool[n+1];
        for (int i = 0; i < n; i++)
        {
            var edge = edges[i];
            var from = edge[0];
            var to = edge[1];
            //两个顶点都已经在图中，才会考虑成环的可能
            if (graph.ContainsKey(from) && graph.ContainsKey(to))
            {
                Array.Fill(visited, false);
                var hasPath = DFS(from, to, visited, graph);
                //发现从顶点from到顶点to已经存在通路
                if (hasPath)
                {
                    return edge;
                }
            }
            //无向图，添加两条边
            AddEdge(from, to, graph);
            AddEdge(to, from, graph);
        }
        return null;
    }

    private void AddEdge(int u, int v, Dictionary<int, List<int>> graph)
    {
        if (graph.ContainsKey(u))
        {
            graph[u].Add(v);
        }
        else
        {
            graph[u] = new List<int>(){v};
        }
    }

    /// <summary>
    /// 查找图中从source到target的路径是否存在
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="visited"></param>
    /// <param name="graph"></param>
    /// <returns></returns>
    private bool DFS(int source, int target, bool[] visited, Dictionary<int, List<int>> graph)
    {
        if (source == target)
        {
            return true;
        }
        visited[source] = true;
        var nodes = graph[source];
        for (int i = 0; i < nodes.Count; i++)
        {
            if (visited[nodes[i]]) continue;
            var hasPath = DFS(nodes[i], target, visited, graph);
            if (hasPath)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 并查集
    /// </summary>
    /// <param name="edges"></param>
    /// <returns></returns>
    public int[] FindRedundantConnection_UnionFind(int[][] edges)
    {
        var n = edges.Length;
        var unionFind = new int[n+1];
        //并查集初始化
        for (int i = 0; i < n; i++)
        {
            unionFind[i] = i;
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var u = edges[i][0];
            var v = edges[i][1];
            var parent_u = Find(u, unionFind);
            var parent_v = Find(v, unionFind);
            if (parent_u == parent_v)
            {
                return edges[i];
            }
            unionFind[parent_u] = parent_v;
        }
        return null;
    }

    private int Find(int x, int[] root)
    {
        if (root[x] == x)
        {
            return x;
        }
        root[x] = Find(root[x], root);
        return root[x];
    }

    /// <summary>
    /// 拓扑排序
    /// </summary>
    /// <param name="edges"></param>
    /// <returns></returns>
    public int[] TopoSort(int[][] edges)
    {
        var n = edges.Length;
        var graph = new List<int>[n+1];
        var enterDeg = new int[n+1];
        //构建邻接表和入度表（无向图，初始入度为1）
        for (int i = 0; i < n; i++)
        {
            var edge = edges[i];
            if (graph[edge[0]] == null)
                graph[edge[0]] = new List<int>(){edge[1]};
            else
                graph[edge[0]].Add(edge[1]);

            if (graph[edge[1]] == null)
                graph[edge[1]] = new List<int>(){edge[0]};
            else
                graph[edge[1]].Add(edge[0]);
            
            enterDeg[edge[0]]+=1;
            enterDeg[edge[1]]+=1;
        }
        int count = 0;
        var queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            if (enterDeg[i] == 1)
            {
                queue.Enqueue(i);
                count++;
            }
        }
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            enterDeg[node] = 0;
            var neighbors = graph[node];
            foreach (var neighbor in neighbors)
            {
                if (enterDeg[neighbor] == 0)
                {
                    continue;
                }
                enterDeg[neighbor] -= 1;
                if (enterDeg[neighbor] == 1)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }
        for (int i = n-1; i >= 0; i--)
        {
            if (enterDeg[edges[i][0]] > 1 && enterDeg[edges[i][1]] > 1)
            {
                return edges[i];
            }
        }
        return null;
    } 
}
// @lc code=end

