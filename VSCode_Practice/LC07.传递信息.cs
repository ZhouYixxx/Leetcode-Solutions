using System;
using System.Collections.Generic;

public class Solution_LC07 
{
    int ans1 = 0;
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
        // var relation = new int[2][]
        // {
        //     new int[]{0,2},
        //     new int[]{2,1},
        // };
        // var k = 2;
        // var n = 3;
        var ans = NumWays(n, relation, k);
    }

    public int NumWays(int n, int[][] relation, int k) 
    {
        var ans = DP(n, relation,k);
        return ans;
    }

    //O(nᵏ)
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
        while (steps < k && quene.Count > 0)
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
        dfs(k,n,0,0,memoDic);
        return ans1;
    }

    private void dfs(int k, int n,int index, int steps,  Dictionary<int, HashSet<int>> memoDic)
    {
        if (steps == k)
        {
            if (index == n-1)
            {
                ans1++;
            }
            return;
        }
        if (!memoDic.ContainsKey(index))
        {
            return;
        }
        var nextPositions = memoDic[index];
        foreach (var nextPosition in nextPositions)
        {
            dfs(k,n,nextPosition,steps+1,memoDic);
        }
    }

    //O(nk)
    public int DP(int n, int[][] relation, int k)
    {
        var dp = new int[k+1][];
        for (int i = 0; i <= k; i++)
        {
            dp[i] = new int[n];
        }
        dp[0][0] = 1;
        for (int i = 1; i <= k; i++)
        {
            for (int p = 0; p < relation.Length; p++)
            {
                var pre = relation[p][0];
                var next = relation[p][1];
                dp[i][next] += dp[i-1][pre];
            }
        }
        return dp[k][n-1];
    }
}