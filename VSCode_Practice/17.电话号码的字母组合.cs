/*
 * @lc app=leetcode.cn id=17 lang=csharp
 *
 * [17] 电话号码的字母组合
 */

// @lc code=start
using System;
using System.Text;
using System.Collections.Generic;

public class Solution017 
{
    public void Test()
    {
        var digits = "2";
        var ans = LetterCombinations(digits);
    }

    public IList<string> LetterCombinations(string digits) 
    {
        var ans = new List<string>();
        if (digits.Length == 0)
        {
            return ans;
        }
        var letterDic = new Dictionary<char,string>()
        {
            {'2',"abc"},{'3',"def"},{'4',"ghi"},{'5',"jkl"},{'6',"mno"},{'7',"pqrs"},{'8',"tuv"},{'9',"wxyz"}
        };
        Backtrace(digits,0,letterDic,ans,"");
        return ans;
    }

    private void Backtrace(string digits, int index, Dictionary<char,string> letterDic, List<string> result, string tempResult)
    {
        if (index >= digits.Length)
        {
            result.Add(tempResult);
            return;
        }
        var letters = letterDic[digits[index]];
        foreach (var letter in letters)
        {
            Backtrace(digits,index+1, letterDic, result, tempResult+letter);
        }
    }

    #region 2022.01.11

    public IList<string> LetterCombinations2(string digits) 
    {
        var ans = new List<string>();
        if (digits.Length == 0)
        {
            return ans;
        }
        var letterDic = new Dictionary<char,string>()
        {
            {'2',"abc"},{'3',"def"},{'4',"ghi"},{'5',"jkl"},{'6',"mno"},{'7',"pqrs"},{'8',"tuv"},{'9',"wxyz"}
        };
        Backtrace(digits,0,letterDic,ans,"");
        return ans;
    }

    private void BackTrack2(int i, string digits, Dictionary<char,string> letterDic, List<string> ans, string tempRes)
    {
        if (i == digits.Length)
        {
            ans.Add(tempRes);
            return;
        }
        var options = letterDic[digits[i]];
        for (int j = 0; j < options.Length; j++)
        {
            BackTrack2(i+1, digits, letterDic, ans, tempRes + options[j]);
        }
    }
         
    #endregion
}
// @lc code=end

