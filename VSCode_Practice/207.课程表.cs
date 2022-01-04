/*
 * @lc app=leetcode.cn id=207 lang=csharp
 *
 * [207] 课程表
 */

// @lc code=start

using System.Collections.Generic;
using System.Linq;
public class Solution207 {
    public void Test()
    {
        var s = "[[1,0]]";
        var n = 2;
        var g = DataStructureHelper.ConvertStringToTwoDimenArray(s);
        var ans = CanFinish(n,g);
    }


    int unVisited = 0;
    int visited = 1;
    int visiting = 2;

     
    public bool CanFinish(int numCourses, int[][] prerequisites) 
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
        //存储每个节点的状态：0-未访问，1-曾经访问过, 2-当前递归流程中正在访问
        var status = new int[numCourses];
        for (int i = 0; i < graph.Length; i++)
        {
            if (status[i] == unVisited)
            {
                var isvalid = DFS(i, graph, status);
                if (!isvalid)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// DFS判断是否有环
    /// </summary>
    /// <param name="i"></param>
    /// <param name="graph"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    private bool DFS(int i, List<int>[] graph, int[] status)
    {
        //本轮递归出现第二次访问，说明成环
        if (status[i] == visiting)
        {
            return false;
        }
        //别的节点递归访问过，说明不会成环，否则早已返回false
        if (status[i] == visited)
        {
            return true;
        }
        status[i] = visiting;
        for (int j = 0; j < graph[i].Count; j++)
        {
            var newNode = graph[i][j];
            var isvalid = DFS(newNode, graph, status);
            if (!isvalid)
            {
                return false;
            }   
        }
        status[i] = visited;
        return true;
    }

    /// <summary>
    /// 拓扑排序
    /// </summary>
    /// <param name="numCourses"></param>
    /// <param name="prerequisites"></param>
    /// <returns></returns>
    private bool TopoSort(int numCourses, int[][] prerequisites)
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
        
        var total = 0;
        //队列当中存储入度为0的节点
        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegrees[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        while (queue.Count > 0)
        {
            var v = queue.Dequeue();
            total++;
            var nextNodes = graph[v];
            foreach (var node in nextNodes)
            {
                if (indegrees[node] <= 0)
                    continue;
                //后继节点的入度减1
                indegrees[node] -= 1;
                //入度为0，入队
                if (indegrees[node] == 0)
                {
                    queue.Enqueue(node);
                }
            }
        }
        return numCourses == total;
    }
}
// @lc code=end

