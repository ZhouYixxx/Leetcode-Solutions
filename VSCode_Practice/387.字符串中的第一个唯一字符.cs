/*
 * @lc app=leetcode.cn id=387 lang=csharp
 *
 * [387] 字符串中的第一个唯一字符
 */

// @lc code=start
using System.Collections.Generic;

public class Solution387 {
    public void Test()
    {
        var s = "leetcode";
        var ans = FirstUniqChar(s);
    }
    public int FirstUniqChar(string s) {
        var cntDic = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!cntDic.ContainsKey(s[i]))
            {
                cntDic[s[i]] = 0;
            }
            cntDic[s[i]]++;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (cntDic[s[i]] == 1)
            {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

