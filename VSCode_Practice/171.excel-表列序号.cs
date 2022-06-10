/*
 * @lc app=leetcode.cn id=171 lang=csharp
 *
 * [171] Excel 表列序号
 */

// @lc code=start
public class Solution171 {
    public void Test(){
        var a = "AAB";
        var ans = TitleToNumber(a);
    }

    public int TitleToNumber(string columnTitle) {
        var column = 0;
        for (int i = 0; i < columnTitle.Length; i++)
        {
            var c = columnTitle[i];
            var digit = (int)(c - 'A' + 1);
            column = column * 26 + digit;
        }
        return column;
    }
}
// @lc code=end

