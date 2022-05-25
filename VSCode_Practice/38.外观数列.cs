/*
 * @lc app=leetcode.cn id=38 lang=csharp
 *
 * [38] 外观数列
 */

// @lc code=start
using System.Text;

public class Solution38 {
    public void Test()
    {
        var n = 8;
        var ans = CountAndSay(n);
    }
    public string CountAndSay(int n) {
        if (n == 1)
        {
            return "1";
        }
        var str = new StringBuilder();
        var prev = new StringBuilder("1");
        for (int i = 2; i <= n; i++)
        {
            str = GetNext(prev);
            prev = str;
        }
        return str.ToString();
    }

    private StringBuilder GetNext(StringBuilder prev)
    {
        var sb = new StringBuilder();
        int cnt = 1;
        int num = 0;
        for (int i = 0; i < prev.Length; i++)
        {
            num = prev[i] - '0';
            if (i != prev.Length-1 && prev[i] == prev[i+1])
            {
                cnt++;
                continue;
            }
            sb.Append($"{cnt}{num}");
            cnt = 1;
            num = 0;
        }
        // sb.Append($"{cnt}{num}");
        return sb;
    }
}
// @lc code=end

