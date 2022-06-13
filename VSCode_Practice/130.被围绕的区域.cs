/*
 * @lc app=leetcode.cn id=130 lang=csharp
 *
 * [130] 被围绕的区域
 */

// @lc code=start
using System.Collections.Generic;

public class Solution130 {
    public void Test()
    {
        var s = "[['O','X','O'],['X','O','X'],['O','X','O']]";
        var board = DataStructureHelper.ConvertStringToTwoDimenCharArray(s);
        Solve(board);
    }
    bool isClosed = false;

    public void Solve(char[][] board) {
        var m = board.Length;
        var n = board[0].Length;
        var q = new Queue<int[]>();
        var used = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            used[i] = new bool[n];
        }
        var directions = new int[][]{
            new int[]{0,1},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{-1,0},
        };
        var res = new List<int[]>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'X' || used[i][j]) continue;
                isClosed = i != 0 && i != m-1 && j != 0 && j != n-1;
                used[i][j] = true;
                q.Enqueue(new int[]{i,j});
                while (q.Count > 0)
                {
                    var p = q.Dequeue();
                    res.Add(p);
                    foreach (var direction in directions)
                    {
                        var newX = p[0] + direction[0];
                        var newY = p[1] + direction[1];
                        if (newX >= m || newY >= n || newX < 0 || newY < 0 || used[newX][newY] || board[newX][newY] == 'X')
                        {
                            continue;
                        }
                        if (newX == 0 || newX == m-1 || newY == 0 || newY == n-1)
                        {
                            isClosed = false;
                        }
                        used[newX][newY] = true;
                        q.Enqueue(new int[]{newX,newY});
                    }   
                }
                if (isClosed)
                {
                    foreach (var item in res)
                    {
                        board[item[0]][item[1]] = 'X';
                    }
                }
                res.Clear();
            }
        }
    }
}
// @lc code=end

