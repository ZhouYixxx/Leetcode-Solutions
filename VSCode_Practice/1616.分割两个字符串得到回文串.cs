/*
 * @lc app=leetcode.cn id=1616 lang=csharp
 *
 * [1616] 分割两个字符串得到回文串
 */

// @lc code=start
using System;

public class Solution1616 {
    public void Test()
    {
        var a = "aejbaalflrmkswrydwdkdwdyrwskmrlfqizjezd";
        var b = "uvebspqckawkhbrtlqwblfwzfptanhiglaabjea";
        var ans = CheckPalindromeFormation(a,b);
    }


    public bool CheckPalindromeFormation(string a, string b) 
    {
        return PalindromicSearch(a,b) || PalindromicSearch(b,a);
    }

    //考虑a在前，b在后的形式能否形成回文串
    private bool PalindromicSearch(string a, string b)
    {
        int l = 0, r = a.Length-1;
        
        while (l <= r)
        {
            if (a[l] != b[r])
            {
                //不相等不代表不能分割为回文串，还要判断b[l...r]或a[l...r]是否是回文
                var isPalindromic = IsSubStrPalindromic(b,l,r) || IsSubStrPalindromic(a,l,r);
                return isPalindromic;
            }
            l++;
            r--;
        }

        //l > r，必然可以形成回文串
        return true;
    }

    private bool IsSubStrPalindromic(string s, int start, int end)
    {
        int l = start, r = end;
        while (l <= r)
        {
            if (s[l++] != s[r--])
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

