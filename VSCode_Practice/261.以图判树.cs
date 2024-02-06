/*
 * @lc app=leetcode.cn id=1576 lang=csharp
 *
 * [1576] 替换所有的问号
 */

// @lc code=start
using Microsoft.VisualBasic;

public class Solution261 
{
    public void Test()
    {
        int n = 5;
        var edges = DataStructureHelper.ConvertStringToTwoDimenNumArray("[[0,1],[0,2],[0,3],[1,4]]");
        var ans = ValidTree(n, edges);
    }
    
     IList<int>[] adjacentArr; //邻接表
    int visitCount = 0;
    bool[] visited;

    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length != n - 1) {
            return false;
        }
        BuildGraph(n, edges);
        visited = new bool[n];
        DFS(0);
        return visitCount == n;
    }

    private void BuildGraph(int n, int[][] edges)
    {
        adjacentArr = new IList<int>[n];
        for (int i = 0; i < n; i++) {
            adjacentArr[i] = new List<int>();
        }
        foreach (int[] edge in edges) {
            adjacentArr[edge[0]].Add(edge[1]);
            adjacentArr[edge[1]].Add(edge[0]);
        }
    }

    public void DFS(int node) {
        visitCount++;
        visited[node] = true;
        IList<int> adjacent = adjacentArr[node];
        foreach (int next in adjacent) {
            if (!visited[next]) {
                DFS(next);
            }
        }
    }
}
// @lc code=end

