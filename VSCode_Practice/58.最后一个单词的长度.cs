/*
 * @lc app=leetcode.cn id=58 lang=csharp
 *
 * [58] 最后一个单词的长度
 */

// @lc code=start
public class Solution58 {
    public void Test()
    {
        var s = "day";
        var ans = LengthOfLastWord(s);
    }

    public int LengthOfLastWord(string s) {
        int start = 0;
        int end = s.Length-1;
        for (int i = s.Length-1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                continue;
            }
            end = i;
            break;
        }
        for (start = end; start >= 0; start--)
        {
            if (s[start] != ' ')
            {
                continue;
            }
            return end-start;
        }
        return end - start;
    }
}
// @lc code=end

