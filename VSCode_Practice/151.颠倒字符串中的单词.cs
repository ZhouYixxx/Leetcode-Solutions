/*
 * @lc app=leetcode.cn id=151 lang=csharp
 *
 * [151] 颠倒字符串中的单词
 */

// @lc code=start
using System.Text;

public class Solution151 {
    public void Test(){
        var s = "EPY2giL";
        var ans =  ReverseWords(s);
    }

    public string ReverseWords(string s) {
        var builder = new StringBuilder();
        int right = s.Length-1;
        int left = s.Length-1;
        while (left >= 0 && right >= 0)
        {
            if (s[right] == ' ')
            {
                right--;
                continue;
            }
            if (IsChar(s[right]))
            {
                left = right;
                //固定right，left向左寻找单词的左边界
                while (left >= 0 && IsChar(s[left]))
                {
                    left--;
                }
                //[left+1, right]范围内就是完整单词
                var subStr = s.Substring(left+1, right - left);
                //单词中间需要添加空格
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }
                builder.Append(subStr);
            }
            right = left+1;
            right--;
        }
        return builder.ToString();
    }

    private bool IsChar(char c){
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
    }
}
// @lc code=end

