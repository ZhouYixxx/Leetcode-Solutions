/*
 * @lc app=leetcode.cn id=140 lang=csharp
 *
 * [140] 单词拆分 II
 */

// @lc code=start
using System.Collections.Generic;
using System;
using System.Text;

public class Solution141 {
    public void Test()
    {
        var s ="pineapplepenapple";
        var wordDic = new List<string>(){
            "apple","pen","applepen","pine","pineapple"
        };
        var ans = WordBreak(s, wordDic);
    }

    List<string> res = new List<string>();

    public IList<string> WordBreak(string s, IList<string> wordDict) {
        var path = new List<string>();
        var wordDic = new HashSet<string>(wordDict);
        var memo = new Dictionary<int, List<string>>();
        dfs(0, s, wordDic, path, memo);
        return res;
    }

    private void dfs(int index, string s, HashSet<string> wordDict, List<string> path,  Dictionary<int, List<string>> memo){
        if (index == s.Length)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < path.Count; i++)
            {
                sb.Append(path[i]);
                if (i != path.Count -1)
                {
                    sb.Append(" ");   
                }
            }
            res.Add(sb.ToString());
            return;
        }

        for (int i = index; i < s.Length; i++)
        {
            var subStr = s.Substring(index, i-index+1);
            if (!wordDict.Contains(subStr))
            {
                continue;
            }
            path.Add(subStr);
            dfs(i+1, s, wordDict, path, memo);
            path.RemoveAt(path.Count-1);
        }
        //memo[index] = new List<string>(path);
    }
}
// @lc code=end

