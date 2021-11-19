/*
 * @lc app=leetcode.cn id=784 lang=csharp
 *
 * [784] 字母大小写全排列
 */

// @lc code=start
using System.Collections.Generic;

public class Solution784 {
    public void Test()
    {
        var s = "ab";
        var res = LetterCasePermutation(s);
    }

    public IList<string> LetterCasePermutation(string s) 
    {
        var res = new List<string>();
        var charArray = s.ToCharArray();
        //BackTrack(res, s, new List<char>(), 0);
        BackTrack(res, s, charArray, 0);
        return res;
    }

    private void BackTrack(List<string> res,string s, List<char> tempRes, int cur)
    {
        if (cur == s.Length)
        {
            var str = new string(tempRes.ToArray());
            res.Add(str);
            return;
        }
        if (s[cur] <= '9' && s[cur] >= '0')
        {
            tempRes.Add(s[cur]);
            BackTrack(res, s, tempRes, cur+1);
        }
        if (s[cur] >= 'A' && s[cur] <= 'Z')
        {
            tempRes.Add(s[cur]);
            BackTrack(res, s, tempRes, cur+1);
            tempRes[cur] = (char)((int)s[cur]+32);
            for (int i = tempRes.Count-1; i > cur; i--)
            {
                tempRes.RemoveAt(i);
            }
            BackTrack(res, s, tempRes, cur+1);
        }
        if (s[cur] >= 'a' && s[cur] <= 'z')
        {
            tempRes.Add(s[cur]);
            BackTrack(res, s, tempRes, cur+1);
            tempRes[cur] = (char)((int)s[cur]-32);
            for (int i = tempRes.Count-1; i > cur; i--)
            {
                tempRes.RemoveAt(i);
            }
            BackTrack(res, s, tempRes, cur+1);
        }
    }

    private void BackTrack(List<string> res,string s, char[] tempRes, int cur)
    {
        if (cur == s.Length)
        {
            var str = new string(tempRes);
            res.Add(str);
            return;
        }
        if (s[cur] <= '9' && s[cur] >= '0')
        {
            tempRes[cur] = s[cur];
            BackTrack(res, s, tempRes, cur+1);
        }
        if (s[cur] >= 'A' && s[cur] <= 'Z')
        {
            tempRes[cur] = s[cur];
            BackTrack(res, s, tempRes, cur+1);
            tempRes[cur] = (char)((int)s[cur]+32);
            BackTrack(res, s, tempRes, cur+1);
        }
        if (s[cur] >= 'a' && s[cur] <= 'z')
        {
            tempRes[cur] = s[cur];
            BackTrack(res, s, tempRes, cur+1);
            tempRes[cur] = (char)((int)s[cur]-32);
            BackTrack(res, s, tempRes, cur+1);
        }
    }
    
}
// @lc code=end

