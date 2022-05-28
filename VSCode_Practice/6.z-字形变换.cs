/*
 * @lc app=leetcode.cn id=6 lang=csharp
 *
 * [6] Z 字形变换
 */

// @lc code=start
public class Solution006 {
    public void Test(){
        var s = "PAYPALISHIRING";
        var rows = 13;
        var ans = Convert(s, rows);
    }

    /// <summary>
    /// 空间复杂度O(1)的做法
    /// </summary>
    /// <param name="s"></param>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public string Convert(string s, int numRows) {
        if (numRows == 1 || numRows >= s.Length)
        {
            return s;
        }
        var chars = new char[s.Length];
        int cnt = 0;
        var curRow = 0;
        while (cnt < s.Length && curRow < numRows)
        {
            var col = 0;
            int index_pre = 0, index_next = 0;
            while (index_next < s.Length && cnt < s.Length)
            {
                index_pre = 2*col*(numRows-1) - curRow;
                index_next = 2*col*(numRows-1) + curRow;
                if (index_pre >= 0 && index_pre < s.Length && curRow != numRows-1)
                {
                    chars[cnt++] = s[index_pre];
                }
                if (index_next < s.Length && index_next != index_pre)
                {
                    chars[cnt++] = s[index_next];
                }
                col++;   
            }
            curRow++;
        }
        var ans = new string(chars);
        return ans;
    }
}
// @lc code=end

