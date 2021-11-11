/*
 * @lc app=leetcode.cn id=567 lang=csharp
 *
 * [567] 字符串的排列
 */

// @lc code=start
using System.Collections.Generic;

public class Solution567 {
    public void Test()
    {
        var s1 = "hello";
        var s2 = "ooolleoooleh";
        var ans = CheckInclusion(s1,s2);
    }

    public bool CheckInclusion(string s1, string s2) 
    {
        if (s1.Length > s2.Length)
        {
            return false;
        }
        var countDic = new Dictionary<char, int>();//记录每个字母出现的次数
        for (int i = 0; i < s1.Length; i++)
        {
            if (countDic.TryGetValue(s1[i], out int count))
            {
                countDic[s1[i]] = count+1;
                continue;
            }
            countDic.Add(s1[i], 1);
        }
        var countDic2 = new Dictionary<char,int>();
        int l = 0, r = s1.Length-1;//滑动窗口
        while (r < s2.Length)
        {
            var subStr = s2.Substring(l,r-l+1);
            if (countDic2.Count == 0)
            {
                //需要重新开始
                for (int i = l; i <= r; i++)
                {
                    if (!countDic.ContainsKey(s2[i]))
                    {
                        l = i+1;
                        r = l+s1.Length-1;
                        countDic2.Clear();
                        break;
                    }
                    else
                    {
                        if (countDic2.TryGetValue(s2[i], out int count))
                        {
                            countDic2[s2[i]] = count+1;
                        }
                        else
                        {
                            countDic2.Add(s2[i], 1);   
                        }
                    }
                }
            }
            else
            {
                countDic2[s2[l-1]] = countDic2[s2[l-1]]-1;
                if (!countDic.ContainsKey(s2[r]))
                {
                    countDic2.Clear();
                    l = r+1;
                    r = l+s1.Length-1;
                    continue;   
                }
                else
                {
                    if (countDic2.TryGetValue(s2[r], out int count))
                    {
                        countDic2[s2[r]] = count+1;
                    }
                    else
                    {
                        countDic2.Add(s2[r], 1);   
                    }
                }
            }
            if (countDic2.Count == 0)
            {
                continue;
            }
            if (IsEqual(countDic, countDic2))
            {
                return true;
            }
            l++;
            r++;
        }
        return false;
    }

    private bool IsEqual(Dictionary<char,int> dic1,Dictionary<char,int> dic2)
    {
        if (dic1.Count != dic2.Count)
        {
            return false;
        }
        foreach (var item in dic1)
        {
            if (dic2[item.Key] != item.Value)
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

