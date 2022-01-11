/*
 * @lc app=leetcode.cn id=210 lang=csharp
 *
 * [210] 课程表 II
 */

// @lc code=start
using System.Collections.Generic;

public class Solution210 
{
    public void Test()
    {
        var s = "[]";
        var g = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var n = 1;
        var ans = FindOrder(n,g);
    }

    int unvisited = 0;
    int visited = 1;
    int visiting = 2;

    bool isvalid = true;
    
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        return FindOrder_DFS(numCourses, prerequisites);
    }

    /// <summary>
    /// DFS
    /// </summary>
    /// <param name="numCourses"></param>
    /// <param name="prerequisites"></param>
    /// <returns></returns>
    public int[] FindOrder_DFS(int numCourses, int[][] prerequisites)
    {
        //有向图：构造邻接表
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }
        for (int i = 0; i < prerequisites.Length; i++)
        {
            var from = prerequisites[i][1];
            var to = prerequisites[i][0];
            graph[from].Add(to);
        }
        var path = new List<int>();
        var status = new int[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            if (status[i] == unvisited)
            {
                DFS(i, graph, status, path);
                if (!isvalid)
                {
                    return new int[0];
                }
            }
        }
        path.Reverse();
        return path.ToArray();
    }

    private void DFS(int i, List<int>[] graph, int[] status, List<int> path)
    {
        if (status[i] == visiting)
        {
            isvalid = false;
            return;
        }
        if (status[i] == visited)
        {
            return;
        }
        status[i] = visiting;
        for (int j = 0; j < graph[i].Count; j++)
        {
            var node = graph[i][j];
            DFS(node, graph, status, path);
            if (!isvalid)
            {
                return;
            }
        }
        status[i] = visited;
        //完成了所有后续节点的递归后，最后再将该节点加入列表
        path.Add(i);
    }

    /// <summary>
    /// 拓扑排序/BFS
    /// </summary>
    /// <param name="numCourses"></param>
    /// <param name="prerequisites"></param>
    /// <returns></returns>
    public int[] FindOrder_TopoSort(int numCourses, int[][] prerequisites)
    {
        //入度表
        var indegrees = new int[numCourses];
        //邻接表
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }
        for (int i = 0; i < prerequisites.Length; i++)
        {
            var from = prerequisites[i][1];
            var to = prerequisites[i][0];
            indegrees[to] += 1;
            graph[from].Add(to);
        }
        var path = new int[numCourses];
        var q = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegrees[i] == 0)
            {
                q.Enqueue(i);
            }
        }
        int index = 0;
        while (q.Count > 0)
        {
            var u = q.Dequeue();
            path[index++] = u;
            for (int v = 0; v < graph[u].Count; v++)
            {
                var next = graph[u][v];
                if (indegrees[next] > 0)
                {
                    indegrees[next] -= 1;
                    if (indegrees[next] == 0)
                    {
                        q.Enqueue(next);
                    }
                }
            }
        }
        return index == numCourses ? path : new int[0];
    }
}
// @lc code=end

