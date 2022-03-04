/*
 * @lc app=leetcode.cn id=13 lang=csharp
 *
 * [13] 罗马数字转整数
 */

// @lc code=start
using System.Collections.Generic;
using System;
public class Solution013 {
    public void Test()
    {
        var s = "MMMCMXCIX";
        var ans = RomanToInt(s);
    }
    
    Dictionary<char, int> romanDic = new Dictionary<char, int>(){
        {'I',1},{'V',5},{'X',10},{'L',50},{'C',100},{'D', 500},{'M', 1000}
    };

    public int RomanToInt(string s) {
        var ans = 0;
        int i = 0;
        while (i < s.Length)
        {
            if (i == s.Length-1)
            {
                ans += romanDic[s[i]];
                i++;
                continue;
            }
            if (s[i] == 'I' && s[i+1] == 'V')
            {
                ans += 4;
                i+=2;
                continue;
            }
            if (s[i] == 'I' && s[i+1] == 'X')
            {
                ans += 9;
                i+=2;
                continue;
            }
            if (s[i] == 'X' && s[i+1] == 'L')
            {
                ans += 40;
                i+=2;
                continue;
            }
            if (s[i] == 'X' && s[i+1] == 'C')
            {
                ans += 90;
                i+=2;
                continue;
            }
            if (s[i] == 'C' && s[i+1] == 'D')
            {
                ans += 400;
                i+=2;
                continue;
            }
            if (s[i] == 'C' && s[i+1] == 'M')
            {
                ans += 900;
                i+=2;
                continue;
            }
            ans += romanDic[s[i]];
            i++;
        }
        return ans;
    }
}
// @lc code=end

