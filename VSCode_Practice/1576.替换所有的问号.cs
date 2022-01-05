/*
 * @lc app=leetcode.cn id=1576 lang=csharp
 *
 * [1576] 替换所有的问号
 */

// @lc code=start
public class Solution1576 
{
    public void Test()
    {
        var s = "??yw?ipkj?";
        var ans = ModifyString(s);
    }
    
    public string ModifyString(string s) 
    {
        var chars = s.ToCharArray();
        for (int i = 0; i < s.Length; i++)
        {
            var candidate = 'a';
            var ch = chars[i];
            if (ch != '?')
                continue;
            var next = i == s.Length-1 ? ' ' : chars[i+1];
            var pre = i == 0 ? ' ' : chars[i-1];
            while (candidate == pre || candidate == next)
            {
                candidate++;
            }
            chars[i] = candidate;
        }
        return new string(chars);
    }
}
// @lc code=end

