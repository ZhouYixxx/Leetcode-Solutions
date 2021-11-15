/*
 * @lc app=leetcode.cn id=994 lang=csharp
 *
 * [994] 腐烂的橘子
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution994 {
    public void Test()
    {
        var organges = new int[][]
        {
            new int[]{2,1,1},
            new int[]{1,1,0},
            new int[]{0,1,1},
        };
        var ans = OrangesRotting(organges);
    }

    public int OrangesRotting(int[][] grid) 
    {
        var ans = BFS(grid);
        return ans;
    }

    /// <summary>
    /// BFS方法
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    private int BFS(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        // var vsisited = new bool[m][];
        // for (int i = 0; i < m; i++)
        // {
        //     vsisited[i] = new bool[n];
        // }
        var freshCount = 0;
        var queue = new Queue<int[]>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 2)
                {
                    queue.Enqueue(new int[]{i,j});
                    //vsisited[i][j] = true;
                }
                if (grid[i][j] == 1)
                {
                    freshCount++;
                }
            }
        }
        var min = 0;
        while (queue.Count > 0 && freshCount > 0)
        {
            var size = queue.Count;
            while (size-- > 0)
            {
                var head = queue.Dequeue();
                var x = head[0];
                var y = head[1];
                var dx = new int[]{1,-1,0,0};
                var dy = new int[]{0,0,1,-1};
                for (int i = 0; i < 4; i++)
                {
                    var newX = x + dx[i];
                    var newY = y + dy[i];
                    if (newX >= 0 && newX < m && newY >= 0 && newY < n && 
                        grid[newX][newY] == 1)
                    {
                        grid[newX][newY] = 2;
                        //vsisited[newX][newY] = true;
                        queue.Enqueue(new int[]{newX,newY});
                        freshCount--;
                    }
                }
            }
            min++;
        }
        return freshCount <= 0 ? min : -1;
    }
}
// @lc code=end

