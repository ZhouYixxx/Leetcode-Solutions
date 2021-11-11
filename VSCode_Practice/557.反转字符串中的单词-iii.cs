/*
 * @lc app=leetcode.cn id=557 lang=csharp
 *
 * [557] 反转字符串中的单词 III
 */

// @lc code=start
public class Solution557 {
    public void Test()
    {
        var s = "abc";
        var res = "s'teL ekat edoCteeL tsetnoc";
        var ans = ReverseWords(s);
        var test = res == ans;
    }

    public string ReverseWords(string s) 
    {
        int l = 0;
        int r = 0;
        var charArray = s.ToCharArray();
        for (int i = 0; i < s.Length; i++)
        {
            if (charArray[i] == ' ' || i == charArray.Length -1)
            {
                r = i == charArray.Length-1 ? i : i-1;
                while (l < r)
                {
                    var temp = charArray[l];
                    charArray[l] = charArray[r];
                    charArray[r] = temp;
                    l++;
                    r--;
                }
                l = i+1;
                r = i+1;
                continue;    
            }
            r++;
        }
        var res = new string(charArray);
        return res;
    }
}
// @lc code=end

