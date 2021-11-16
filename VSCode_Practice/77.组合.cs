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
        int k = 5;
        var ans = Combine(n,k);
    }

    public IList<IList<int>> Combine(int n, int k) 
    {
        var ans = Recursive(0,n,k);
        return ans;
    }

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
}
// @lc code=end

