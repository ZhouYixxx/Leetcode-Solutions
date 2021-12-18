/*
 * @lc app=leetcode.cn id=51 lang=csharp
 *
 * [51] N 皇后
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution51 {
    public void Test()
    {
        var n = 8;
        var ans = SolveNQueens(n);
    }

    public IList<IList<string>> SolveNQueens(int n) 
    {
        var res = new List<IList<string>>();
        var path = new List<string>();
        var used = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            used[i] = new bool[n];
        }
        BackTrack(n, res, path, used);
        return res;
    }

    private void BackTrack(int n, IList<IList<string>> res, List<string> path, bool[][] used)
    {
        if (path.Count == n)
        {
            res.Add(new List<string>(path));
            return;
        }
        for (int i = 0; i < n; i++)
        {
            var row = path.Count;
            if (!IsValid(row,i,path))
            {
                continue;
            }
            var chars = new char[n];
            Array.Fill(chars, '.');
            chars[i] = 'Q';
            var strValue = new string(chars);
            path.Add(strValue);
            BackTrack(n, res, path, used);
            path.Remove(strValue);
        }
    }


    private bool IsValid(int row, int col, List<string> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            var invalidRow = i;
            var invalidCol = path[i].IndexOf('Q');
            if (row == invalidRow || col == invalidCol || Math.Abs(row - invalidRow) == Math.Abs(col - invalidCol))
            {
                return false;
            }
        }
        return true;
    }

    private void UpdateStatus(int row, int col, int n, bool[][] used, bool status)
    {
        for (int i = row; i < n; i++)
        {
            used[i][col] = status;
        }
        for (int i = col; i < n; i++)
        {
            used[row][i] = status;
        }
        var newRow = row;
        var newCol = col;
        while (newRow < n && newCol < n)
        {
            used[newRow++][newCol++] = status;
        }
        newRow = row;
        newCol = col;
        while (newRow < n && newCol >= 0)
        {
            used[newRow++][newCol--] = status;
        }
    }
}
// @lc code=end

