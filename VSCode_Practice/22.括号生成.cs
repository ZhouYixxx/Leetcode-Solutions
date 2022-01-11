/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution22 {
    public void Test()
    {
        var n = 3;
        var ans = GenerateParenthesis(n);
    }

    public IList<string> GenerateParenthesis(int n) 
    {
        var res = new List<string>();
        var path = new List<char>();
        DFS(n,0,0, res,path);
        return res;
    }

    private void DFS(int n, int left, int right, List<string> res, List<char> path)
    {
        if (left > n || right > n || left < right)
        {
            return;
        }
        if (left == right && left == n)
        {
            var str = new string(path.ToArray());
            res.Add(str);
            return;
        }
        path.Add('(');
        DFS(n, left+1, right, res, path);
        path.RemoveAt(path.Count-1);
        path.Add(')');  
        DFS(n, left, right+1, res, path);
        path.RemoveAt(path.Count-1);
    }
}
// @lc code=end

