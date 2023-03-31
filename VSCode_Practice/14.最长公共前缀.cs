/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

// @lc code=start
using System.Text;

public class Solution14 {
    public void Test()
    {
        var strs =new string[]{"flower","flow","flight"};
        var ans = LongestCommonPrefix(strs);
    }

    public string LongestCommonPrefix(string[] strs) {
        var sb = new StringBuilder();
        int idx = 0;
        bool flag = true;
        while (flag)
        {
            if (idx >= strs[0].Length)
            {
                break;
            }
            char c = strs[0][idx];
            for (int i = 1; i < strs.Length; i++)
            {
                var isValid = strs[i].Length > idx && strs[i][idx] == c;
                if (!isValid)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                sb.Append(c);
            }
            idx++;  
        }
        return sb.ToString();
    }
}
// @lc code=end

