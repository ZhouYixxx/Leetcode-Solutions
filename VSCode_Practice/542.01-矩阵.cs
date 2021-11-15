/*
 * @lc app=leetcode.cn id=542 lang=csharp
 *
 * [542] 01 矩阵
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution542 {
    public void Test()
    {
        // var mat = new int[][]
        // {
        //     new int[]{0,0,1,0,1,1,1,0,1,1},
        //     new int[]{1,1,1,1,0,1,1,1,1,1},
        //     new int[]{1,1,1,1,1,0,0,0,1,1},
        //     new int[]{1,0,1,0,1,1,1,0,1,1},
        //     new int[]{0,0,1,1,1,0,1,1,1,1},
        //     new int[]{1,0,1,1,1,1,1,1,1,1},
        //     new int[]{1,1,1,1,0,1,0,1,0,1},
        //     new int[]{0,1,0,0,0,1,0,0,1,1},
        //     new int[]{1,1,1,0,1,1,0,1,0,1},
        //     new int[]{1,0,1,1,1,0,1,1,1,0},
        // };
        var mat = new int[][]
        {
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{1,1,1},
            new int[]{0,0,0},
        };
        mat = UpdateMatrix(mat);
    }


    public int[][] UpdateMatrix(int[][] mat) 
    {
        var mat1 = DP(mat);
        return mat1;
    }

    /// <summary>
    /// BFS（多源，将终点和起点翻转）
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    private void BFS(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var queue = new Queue<int[]>();
        //源点为0,非1
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var value = mat[i][j];
                if (value == 0)
                {
                    queue.Enqueue(new int[]{i,j});
                    continue;
                }
                //mat[i][j] = BFS_Internal(mat, i, j); //单源BFS处理方式，时间复杂度过高
                mat[i][j] = -1;
            }
        }

        while (queue.Count > 0)
        {
            var head = queue.Dequeue();
            var cur_i = head[0];
            var cur_j = head[1];
            var di = new int[]{-1,0,1,0};
            var dj = new int[]{0,-1,0,1};
            for (int k = 0; k < 4; k++)
            {
                var new_i = cur_i + di[k];
                var new_j = cur_j + dj[k];
                if (new_i >= 0 && new_i < m && new_j >= 0 && new_j < n
                    && mat[new_i][new_j] == -1)
                {
                    mat[new_i][new_j] = mat[cur_i][cur_j] + 1;
                    queue.Enqueue(new int[]{new_i,new_j});
                }
            }
        }
    }

    //单源BFS
    private int BFS_Internal(int[][] mat, int i, int j)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var vsisited = new bool[m][];
        for (int k = 0; k < m; k++)
        {
            vsisited[k] = new bool[n];
        }
        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(i,j));
        vsisited[i][j] = true;
        var dis = 1;
        while (queue.Count > 0)
        {
            var size = queue.Count;
            while (size-- > 0)
            {
                var head = queue.Dequeue();
                var cur_i = head.Item1;
                var cur_j = head.Item2;
                var top = cur_i == 0 ? -1 : mat[cur_i-1][cur_j];
                var left = cur_j == 0 ? -1 : mat[cur_i][cur_j-1];
                var bot = cur_i == m -1 ? -1 : mat[cur_i+1][cur_j];
                var right = cur_j == n-1 ? -1 : mat[cur_i][cur_j+1];
                if (top == 0 || left == 0 || bot == 0 || right == 0)
                {
                    mat[i][j] = dis;
                    return dis;
                }   
                if (top > 0 && !vsisited[cur_i-1][cur_j])
                {
                    vsisited[cur_i-1][cur_j] = true;
                    queue.Enqueue(new Tuple<int, int>(cur_i-1, cur_j));
                }
                if (left > 0 && !vsisited[cur_i][cur_j-1])
                {
                    vsisited[cur_i][cur_j-1] = true;
                    queue.Enqueue(new Tuple<int, int>(cur_i, cur_j-1));
                }
                if (bot > 0 && !vsisited[cur_i+1][cur_j])
                {
                    vsisited[cur_i+1][cur_j] = true;
                    queue.Enqueue(new Tuple<int, int>(cur_i+1, cur_j));
                }
                if (right > 0 && !vsisited[cur_i][cur_j+1] )
                {
                    vsisited[cur_i][cur_j+1] = true; 
                    queue.Enqueue(new Tuple<int, int>(cur_i, cur_j+1));
                }
            }
            dis++;
        }
        return dis;
    }

    /// <summary>
    /// 动态规划
    /// </summary>
    /// <param name="mat"></param>
    private int[][] DP(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = mat[i][j] == 0 ? 0 : 20000;
            }
        }
        //左上角开始遍历
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i >= 1)
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i-1][j]+1);
                }
                if (j >= 1)
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i][j-1]+1);
                }
            }
        }

        //右下角开始遍历
        for (int i = m-1; i >= 0; i--)
        {
            for (int j = n-1; j >= 0; j--)
            {
                if (i < m-1)
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i+1][j]+1);
                }
                if (j < n-1)
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i][j+1]+1);
                }
            }
        }

        return dp;
    }
}
// @lc code=end

