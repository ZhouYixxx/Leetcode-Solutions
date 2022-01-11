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
        var ans = SolveNQueens2(n);
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

    #region 2022.01.06

    public IList<IList<string>> SolveNQueens2(int n) 
    {
        var res = new List<IList<string>>();
        var path = new int[n][];
        for (int i = 0; i < n; i++)
        {
            path[i] = new int[n];
        }
        BackTrack2(n, 0, res, path);
        return res;
    }

    private void BackTrack2(int n, int row, List<IList<String>> res, int[][] path)
    {
        if (row == n)
        {
            var pathList = ConvertToStr(path);
            res.Add(pathList);
            return;
        }
        
        for (int col = 0; col < n; col++)
        {
            if (!IsValid2(row, col, path))
            {
                continue;
            }
            path[row][col] = 1;
            BackTrack2(n, row+1, res, path);
            path[row][col] = 0;
        }
    }

    private List<string> ConvertToStr(int[][] path)
    {
        var res = new List<string>();
        int n = path.Length;
        for (int i = 0; i < n; i++)
        {
            var chars = new char[n];
            for (int j = 0; j < n; j++)
            {
                chars[j] = path[i][j] == 1 ? 'Q' : '.';
            }
            res.Add(new string(chars));
        }
        return res;
    }

    private bool IsValid2(int row, int col, int[][] path)
    {
        var n = path.Length;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (path[i][j] == 0)
                {
                    continue;
                }
                if (row == i || col == j || Math.Abs(row - i) == Math.Abs(col - j))
                {
                    return false;
                }
            }
        }
        return true;
    }

    #endregion
}
// @lc code=end

