/*
 * @lc app=leetcode.cn id=139 lang=csharp
 *
 * [139] 单词拆分
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public void Test()
    {
        var s ="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
        var wordDic = new List<string>(){
            "a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"
        };
        var ans = WordBreak(s, wordDic);
    }
    public bool WordBreak(string s, IList<string> wordDict) 
    {
        var dic = new HashSet<string>(wordDict);
        var memo = new int[s.Length];
        var res = dfs(0, s, dic, memo);
        return res;
    }

    /// <summary>
    /// DFS
    /// </summary>
    /// <returns></returns>
    private bool dfs(int index, string s, HashSet<string> dic, int[] memo)
    {
        if (index == s.Length)
        {
            return true;
        }
        //记忆化, memo[i] = 1 表示s[0....i]子串可以用字典中的词拼接
        if (memo[index] != 0)
        {
            return memo[index] == 1 ? true : false;
        }
        for (int i = index; i < s.Length; i++)
        {
            var word = s.Substring(index, i-index+1);
            if (!dic.Contains(word))
            {
                continue;
            }
            var isValid = dfs(i+1, s, dic, memo);
            if (isValid)
            {
                memo[i] = 1;
                return true;
            }
        }
        memo[index] = -1;
        return false;
    }
}
// @lc code=end

