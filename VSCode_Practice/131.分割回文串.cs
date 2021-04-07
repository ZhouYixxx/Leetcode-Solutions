/*
 * @lc app=leetcode.cn id=131 lang=csharp
 *
 * [131] 分割回文串
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution131 {
    public void Test()
    {
        var s ="abba";
        var ans = Partition(s);
    }

    public IList<IList<string>> Partition(string s) {
        var ans = new List<IList<string>>();
        var memo = Pretreatment(s);
        Dfs(s, 0, memo, new List<string>(), ans);
        //var ans2 = Dfs2(s,0,memo);
        return ans;
    }

    private void Dfs(string s, int start, bool[][] memo,List<string> subList, List<IList<string>> all)
    {
        if (start == s.Length)
        {
            //subList.Add(s.Substring(start,1));
            all.Add(subList);
            return;
        }
        for (int i = start; i < s.Length; i++)
        {
            if (memo[start][i])
            {
                var newList = new List<string>(subList);
                newList.Add(s.Substring(start,i-start+1));                
                Dfs(s,i+1, memo, newList, all);
            }
        }
    }

    //第二种递归方式
    public List<IList<string>> Dfs2(string s, int start, bool[][] memo)
    {
        var list = new List<IList<string>>();
        if (start == s.Length)
        {
            list.Add(new List<string>());
            return list;
        }
        for (int i = start; i < s.Length; i++)
        {
            if (memo[start][i])
            {
                var subList = Dfs2(s,i+1, memo);
                foreach (var newList in subList)
                {
                    newList.Insert(0, s.Substring(start,i-start+1));
                    list.Add(newList);
                }
            }
        }
        return list;
    }

    //用DP记录所有回文子串
    private bool[][] Pretreatment(string s)
    {
        var ans = new bool[s.Length][];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = new bool[s.Length];
            for (int j = i; j >= 0; j--)
            {
                if (i - j == 0)
                {
                    ans[j][i] = true;
                    continue;
                }
                if (i - j == 1)
                {
                    ans[j][i] = s[i] == s[j];
                    continue;
                }
                ans[j][i] = s[i] == s[j] && ans[j+1][i-1];
            }
        }
        return ans;
    }
}
// @lc code=end

