/*
 * @lc app=leetcode.cn id=168 lang=csharp
 *
 * [168] Excel表列名称
 */

// @lc code=start
using System.Text;

public class Solution168 {
    public void Test()
    {
        var num = 29;
        var name = ConvertToTitle(num);
    }

    public string ConvertToTitle(int columnNumber) {
        var res = new StringBuilder();
        int DIGIT = 26;
        while (columnNumber != 0)
        {
            var num = columnNumber % DIGIT;
            columnNumber = columnNumber / DIGIT;
            if (num == 0)
            {
                num += DIGIT;
                columnNumber--;
            }
            var charVal = (char)(num + 'A' -1 );
            res.Append(charVal);
        }
        var ans = res.ToString();
        var chars = new char[res.Length];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = ans[chars.Length - 1 - i];
        }
        return new string(chars);
    }
}
// @lc code=end

