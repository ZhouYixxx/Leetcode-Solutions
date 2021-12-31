/*
 * @lc app=leetcode.cn id=785 lang=csharp
 *
 * [785] 判断二分图
 */

// @lc code=start
public class Solution785 {
    public void Test()
    {
        var s ="[[1,2,3],[0,2],[0,1,3],[0,2]]";
        var g = DataStructureHelper.ConvertStringToTwoDimenArray(s);
        var ans = IsBipartite(g);
    }

    public bool IsBipartite(int[][] graph) 
    {
        return IsBipartite_DFS(graph);
    }

    /// <summary>
    /// DFS方法
    /// </summary>
    /// <param name="graph"></param>
    /// <returns></returns>
    public bool IsBipartite_DFS(int[][] graph)
    {
        var n = graph.Length;
        var visited = new bool[n];
        //染色:0-白色(未访问)，1-黑色, 2-红色
        var colors = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (colors[i] != 0)
            {
                continue;
            }
            var isvalid = DFS(i, graph, colors, 1);
            if (!isvalid)
            {
                return false;
            }
        }
        return true;
    }

    private bool DFS(int i, int[][] graph, int[] colors, int color)
    {
        if (colors[i] != 0 && color != colors[i])
        {
            return false;
        }
        colors[i] = color;
        var newColor = color == 1 ? 2 : 1;
        var neighbors = graph[i];
        foreach (var neighbor in neighbors)
        {
            //邻居节点未访问过，递归处理
            if (colors[neighbor] == 0)
            {
                var isvalid = DFS(neighbor, graph,colors, newColor);
                if (!isvalid)
                {
                    return false;
                }   
            }
            //邻居节点已经访问过，直接比较邻居节点与当前节点的颜色，颜色相同说明无法成为二分图
            else
            {
                if (colors[neighbor] == colors[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

