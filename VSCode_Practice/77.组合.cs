/*
 * @lc app=leetcode.cn id=77 lang=csharp
 *
 * [77] 组合
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution77 {
    public void Test()
    {
        int n = 5;
        int k = 2;
        var ans = Combine2(n,k);
    }

    public IList<IList<int>> Combine(int n, int k) 
    {
        var ans = Recursive(0,n,k);
        return ans;
    }

    /// <summary>
    /// 递归法：递归函数含义：从索引start开始选择k个数，返回列表
    /// </summary>
    /// <param name="start"></param>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private List<IList<int>> Recursive(int start, int n, int k)
    {
        var newList = new List<IList<int>>();
        if (k == 1)
        {
            for (int i = start+1; i <= n; i++)
            {
                newList.Add(new List<int>(){i});
            }
            return newList;
        }
        for (int i = start+1; i <= n-k+1; i++)
        {
            var res = Recursive(i,n,k-1);
            foreach (var list in res)
            {
                list.Add(i);
            }
            newList.AddRange(res);
        }
        return newList; 
    }

    #region 2022.01.12

    public IList<IList<int>> Combine2(int n, int k) 
    {
        var res = new List<IList<int>>();
        var path = new HashSet<int>();
        BackTrack(1,n,k,res,path);
        return res;
    }

    /// <summary>
    /// 回溯法
    /// </summary>
    /// <param name="index"></param>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <param name="res"></param>
    /// <param name="path"></param>
    private void BackTrack(int index, int n, int k, List<IList<int>> res, HashSet<int> path)
    {
        if (path.Count == k)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = index; i <= n - (k - path.Count) + 1; i++)
        {
            if (path.Contains(i))
            {
                continue;
            }
            path.Add(i);
            BackTrack(i+1, n, k, res, path);
            path.Remove(i);
        }
    }

    #endregion
}
// @lc code=end

