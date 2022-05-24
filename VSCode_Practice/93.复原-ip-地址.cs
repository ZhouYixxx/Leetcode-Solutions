/*
 * @lc app=leetcode.cn id=93 lang=csharp
 *
 * [93] 复原 IP 地址
 */

// @lc code=start
using System.Collections.Generic;
using System.Text;

public class Solution93 {
    public void Test(){
        //var s = "(1+(4+5+2)-3)+(6+8)";
        var s = "101023";
        var ans = RestoreIpAddresses(s);
    }

    public IList<string> RestoreIpAddresses(string s) {
        var ans = new List<string>();
        if (s.Length < 4 || s.Length > 12)
        {
            return ans;
        }
        var path = new List<int>();
        Dfs(0, s, path, ans);
        return ans;
    }

    /// <summary>
    /// Dfs回溯
    /// </summary>
    /// <param name="start"></param>
    /// <param name="s"></param>
    /// <param name="path"></param>
    /// <param name="ans"></param>
    private void Dfs(int start, string s, List<int> path, List<string> ans)
    {
        if (start < s.Length && path.Count == 4)
        {
            return;
        }
        if (start >= s.Length && path.Count == 4)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < path.Count; i++)
            {
                sb.Append(path[i].ToString());
                if (i != path.Count -1)
                {
                    sb.Append(".");
                }
            }
            ans.Add(sb.ToString());
            return;
        }
        for (int i = start; i <= start+2 && i < s.Length; i++)
        {
            //不允许前导0出现
            if (i != start && s[start] == '0')
            {
                break;
            }
            var num = int.Parse(s.Substring(start,i-start+1));
            if (num > 255)
            {
                break;
            }
            path.Add(num);
            Dfs(i+1, s, path, ans);
            path.RemoveAt(path.Count-1);
        }
    }
}
// @lc code=end

