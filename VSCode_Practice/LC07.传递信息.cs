using System;
using System.Collections.Generic;

public class Solution_LC07 
{
    public void Test()
    {
        var n = 5;
        var relation = new int[7][]
        {
            new int[]{0,2},
            new int[]{2,1},
            new int[]{3,4},
            new int[]{2,3},
            new int[]{1,4},
            new int[]{2,0},
            new int[]{0,4},
        };
        var k = 3;
        var ans = NumWays(n, relation, k);
    }

    public int NumWays(int n, int[][] relation, int k) 
    {
        var ans = BFS(n, relation,k);
        return ans;
    }

    public int BFS(int n, int[][] relation, int k)
    {
        //记录每个索引可以到达的下一个位置
        var memoDic = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < relation.Length; i++)
        {
            var pre = relation[i][0];
            var next = relation[i][1];
            if (memoDic.ContainsKey(pre))
            {
                memoDic[pre].Add(next);
            }
            else
            {
                memoDic.Add(pre, new HashSet<int>(){next});
            }
        }
        var quene = new Queue<int>();
        quene.Enqueue(0);
        int steps  = 0;
        while (steps <= k && quene.Count > 0)
        {
            var size = quene.Count;
            while (size>0)
            {
                var index = quene.Dequeue();
                if (!memoDic.ContainsKey(index))
                {
                    size--;
                    continue;
                }
                var nextPositions = memoDic[index];
                foreach (var nextPosition in nextPositions)
                {
                    quene.Enqueue(nextPosition);
                }
                size--;
            }
            steps++;
        }
        int ans = 0;
        while (quene.Count > 0)
        {
             var top = quene.Dequeue();
             if (top == n-1)
             {
                 ans++;
             }
        }
        return ans;
    }

    public int DFS(int n, int[][] relation, int k)
    {
        return 0;
    }

    public int DP(int n, int[][] relation, int k)
    {
        return 0;
    }
}