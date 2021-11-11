/*
 * @lc app=leetcode.cn id=695 lang=csharp
 *
 * [695] 岛屿的最大面积
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution695 {
    public void Test()
    {
        // var grid = new int[][]
        // {
        //     new int[]{0,0,1,0,0,0,0,1,0,0,0,0,0},
        //     new int[]{0,0,0,0,0,0,0,1,1,1,0,0,0},
        //     new int[]{0,1,1,0,1,0,0,0,0,0,0,0,0},
        //     new int[]{0,1,0,0,1,1,0,0,1,0,1,0,0},
        //     new int[]{0,1,0,0,1,1,0,0,1,1,1,0,0},
        //     new int[]{0,0,0,0,0,0,0,0,0,0,1,0,0},
        //     new int[]{0,0,0,0,0,0,0,1,1,1,0,0,0},
        //     new int[]{0,0,0,0,0,0,0,1,1,0,0,0,0},
        // };
        var grid = new int[][]
        {
            new int[]{1}
        };
        var ans = MaxAreaOfIsland(grid);
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        var ans = BFS(grid);
        return ans;
    }

    /// <summary>
    /// BFS解法
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int BFS(int[][] grid) 
    {
        var visited = new bool[grid.Length][];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[grid[i].Length];
        }
        var maxArea = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0 || visited[i][j])
                    continue;
                var queue = new Queue<Tuple<int,int>>();
                queue.Enqueue(new Tuple<int, int>(i,j));
                visited[i][j] = true;
                int area = 0;
                while (queue.Count > 0)
                {
                    var head = queue.Dequeue();
                    var curRow = head.Item1;
                    var curCol = head.Item2;
                    area++;
                    var top = curRow == 0 ? -1 : grid[curRow-1][curCol];
                    if (top == 1 && !visited[curRow-1][curCol])
                    {
                        visited[curRow-1][curCol] = true;
                        queue.Enqueue(new Tuple<int, int>(curRow-1,curCol));
                    }

                    var left = curCol == 0 ? -1 : grid[curRow][curCol-1];
                    if (left == 1 && !visited[curRow][curCol-1])
                    {
                        visited[curRow][curCol-1] = true;
                        queue.Enqueue(new Tuple<int, int>(curRow,curCol-1));
                    }

                    var bot = curRow == grid.Length-1 ? -1 : grid[curRow+1][curCol];
                    if (bot == 1 && !visited[curRow+1][curCol])
                    {
                        visited[curRow+1][curCol] = true;
                        queue.Enqueue(new Tuple<int, int>(curRow+1,curCol));
                    }

                    var right = curCol == grid[curRow].Length-1 ? -1 : grid[curRow][curCol+1];
                    if (right == 1 && !visited[curRow][curCol+1])
                    {
                        visited[curRow][curCol+1] = true;
                        queue.Enqueue(new Tuple<int, int>(curRow,curCol+1));
                    }
                }
                maxArea = Math.Max(maxArea,area);
            }
        }
        return maxArea;
    }

}
// @lc code=end

