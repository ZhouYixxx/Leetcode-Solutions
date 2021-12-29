/*
 * @lc app=leetcode.cn id=547 lang=csharp
 *
 * [547] 省份数量
 */

// @lc code=start

using System;
using System.Collections.Generic;

public class Solution547 {
    public void Test()
    {
        var s = "[[1,1,0,0,0,0,0,1,0,0,0,0,0,0,0],[1,1,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,1,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,1,0,1,1,0,0,0,0,0,0,0,0],[0,0,0,0,1,0,0,0,0,1,1,0,0,0,0],[0,0,0,1,0,1,0,0,0,0,1,0,0,0,0],[0,0,0,1,0,0,1,0,1,0,0,0,0,1,0],[1,0,0,0,0,0,0,1,1,0,0,0,0,0,0],[0,0,0,0,0,0,1,1,1,0,0,0,0,1,0],[0,0,0,0,1,0,0,0,0,1,0,1,0,0,1],[0,0,0,0,1,1,0,0,0,0,1,1,0,0,0],[0,0,0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,1,0,1,0,0,0,0,1,0],[0,0,0,0,0,0,0,0,0,1,0,0,0,0,1]]";
        var isc = DataStructureHelper.ConvertStringToTwoDimenArray(s);
        var ans = FindCircleNum(isc);
    }

    private int[] root;
    private int[] rank;

    /// <summary>
    /// 并查集
    /// </summary>
    /// <param name="isConnected"></param>
    /// <returns></returns>
    public int FindCircleNum(int[][] isConnected) 
    {
        //并查集初始化
        var n = isConnected.Length;
        Init(n);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    Union(i,j);
                }
            }
        }
        var set = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            var root_i = Find(root[i]);
            set.Add(root_i);
        }
        return set.Count;
    }

    public void Init(int n)
    {
        root = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            root[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (x == root[x])
        {
            return x;
        }
        root[x] = Find(root[x]);
        return root[x];
    }

    public void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);
        if (rootX == rootY)
        {
            return;
        }
        if (rank[rootX] > rank[rootY])
        {
            root[rootY] = rootX;
        }
        else if (rank[rootX] < rank[rootY])
        {
            root[rootX] = rootY;
        }
        else
        {
            root[rootY] = rootX;
            rank[rootX] += 1;
        }
    }

    /// <summary>
    /// DFS方法：用DFS查找与每个城市相连的城市，并将其标记为访问过
    /// </summary>
    /// <param name="isConnected"></param>
    /// <returns></returns>
    public int FindCircleNum_DFS(int[][] isConnected)
    {
        var n = isConnected.Length;
        var visited = new bool[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }
            //该城市没有访问过，说明是一条新通路
            DFS(i, visited, isConnected);
            count++;
        }
        return count;
    }

    private void DFS(int i, bool[] visited, int[][] isConnected)
    {
        visited[i] = true;
        var arr = isConnected[i];
        var n = isConnected.Length;
        for (int j = 0; j < n; j++)
        {
            if (isConnected[i][j] == 1 && visited[j] != true)
            {
                DFS(j, visited, isConnected);
            }
        }
    }

    /// <summary>
    /// BFS方法：用BFS查找与每个城市相连的城市，并将其标记为访问过
    /// </summary>
    /// <param name="isConnected"></param>
    /// <returns></returns>
    public int FindCircleNum_BFS(int[][] isConnected)
    {
        var n = isConnected.Length;
        var visited = new bool[n];
        int count = 0;
        var q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }
            visited[i] = true;
            q.Enqueue(i);
            while (q.Count > 0)
            {
                var u = q.Dequeue();
                for (int j = 0; j < n; j++)
                {
                    if (isConnected[u][j] == 1 && visited[j] != true)
                    {
                        q.Enqueue(j);
                        visited[j] = true;
                    }
                }
            }
            count++;
        }
        return count;
    }
}
// @lc code=end

