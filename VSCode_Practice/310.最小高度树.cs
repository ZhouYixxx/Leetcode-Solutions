/*
 * @lc app=leetcode.cn id=310 lang=csharp
 *
 * [310] 最小高度树
 */

// @lc code=start
public class Solution310 {
    public void Test()
    {
        var n = 6;
        var s = "[[3,0],[3,1],[3,2],[3,4],[5,4]]";
        var edges = DataStructureHelper.ConvertStringToTwoDimenNumArray(s); 
        var res = FindMinHeightTrees(n, edges);
    }

    /// <summary>
    /// 拓扑排序思路
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <returns></returns>
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        var ans = new List<int>();
        if (n == 1)
        {
            ans.Add(0);
            return ans;
        }
        //构造邻接表
        var adj = new List<int>[n];
        //入度表
        var degrees = new int[n];
        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];
            //邻接表
            if (adj[from] == null)
            {
                adj[from] = new List<int>();
            }
            adj[from].Add(to);
            if (adj[to] == null)
            {
                adj[to] = new List<int>();
            }
            adj[to].Add(from);
            //入度表
            degrees[from]++;
            degrees[to]++;
        }

        //层序遍历
        var queue = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (degrees[i] == 1)
            {
                queue.Enqueue(i);
            }
        }
        var remainCount = n;
        while (remainCount > 2)
        {
            var count = queue.Count;
            remainCount -= count;
            for (int i = 0; i < count; i++)
            {
                var cur = queue.Dequeue();
                foreach (var neighbor in adj[cur])
                {
                    if (--degrees[neighbor] == 1)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        while (queue.Count > 0)
        {
            ans.Add(queue.Dequeue());
        }
        return ans;
    }
}
// @lc code=end

