/*
 * @lc app=leetcode.cn id=797 lang=csharp
 *
 * [797] 所有可能的路径
 */

// @lc code=start
using System.Collections.Generic;

public class Solution797 
{
    public void Test()
    {
        var s = "[[4,3,1],[3,2,4],[3],[4],[]]";
        var g = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var res = AllPathsSourceTarget(g);
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) 
    {
        return AllPathsSourceTarget_BFS(graph);
    }

    private IList<IList<int>> AllPathsSourceTarget_DFS(int[][] graph)
    {
        var n = graph.Length;
        var res = new List<IList<int>>();
        //起点是固定的，在递归外处理
        var path = new List<int>(){0};
        DFS(0, n, path, res, graph);
        return res;
    }

    private void DFS(int i, int n, List<int> path, List<IList<int>> res, int[][] graph)
    {
        if (i == n-1)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int j = 0; j <  graph[i].Length; j++)
        {
            //有向图不用visited
            var next = graph[i][j];
            //visited[next] = true;
            path.Add(next);
            DFS(next, n, path, res, graph);
            path.RemoveAt(path.Count-1);
            //visited[next] = false;
        }
    }

    public IList<IList<int>> AllPathsSourceTarget_BFS(int[][] graph) 
    {
        var n = graph.Length;
        var res = new List<IList<int>>();
        //队列应当存储所有路径，而非单纯的节点
        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>(){0});
        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            var node = path[path.Count-1];
            if (node == n-1)
            {
                res.Add(new List<int>(path));
                continue;
            }
            for (int i = 0; i < graph[node].Length; i++)
            {
                var tempPath = new List<int>(path);
                tempPath.Add(graph[node][i]);
                queue.Enqueue(tempPath);
            }
        }
        return res;
    }
}
// @lc code=end

