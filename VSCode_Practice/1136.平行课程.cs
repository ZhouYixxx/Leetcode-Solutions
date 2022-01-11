using System.Collections.Generic;

public class Solution1136
{
    public void Test()
    {
        var s = "[[1,2],[2,3],[3,1]]";
        int n = 3;
        var relations = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var ans = MinimumSemesters(n, relations);
    }

    /// <summary>
    /// 拓扑排序/BFS
    /// </summary>
    /// <param name="n"></param>
    /// <param name="relations"></param>
    /// <returns></returns>
    public int MinimumSemesters(int n, int[][] relations) 
    {
        var in_degrees = new int[n+1];
        var graph = new List<int>[n+1];
        for (int i = 0; i <= n; i++)
        {
            graph[i] = new List<int>();
        }
        for (int i = 0; i < relations.Length; i++)
        {
            var from = relations[i][0];
            var to = relations[i][1];
            graph[from].Add(to);
            in_degrees[to] += 1;
        }
        var q = new Queue<int>();
        int totalSemesters = 0;
        for (int i = 1; i <= n; i++)
        {
            if (in_degrees[i] == 0)
            {
                q.Enqueue(i);
            }
        }
        var courseNum = 0;
        while (q.Count > 0)
        {
            int count = q.Count;
            while (count-- > 0)
            {
                var u = q.Dequeue();
                courseNum++;
                for (int v = 0; v < graph[u].Count; v++)
                {
                    var next = graph[u][v];
                    if (in_degrees[next] > 0)
                    {
                        in_degrees[next] -= 1;
                        if (in_degrees[next] == 0)
                        {
                            q.Enqueue(next);
                        }
                    }
                }
            }
            totalSemesters++;
        }
        return courseNum == n ? totalSemesters : -1;
    }
}