/*
 * @lc app=leetcode.cn id=224 lang=csharp
 *
 * [224] 基本计算器
 */

// @lc code=idx
public class Solution224 {
    public void Test(){
        //var s = "(1+(4+5+2)-3)+(6+8)";
        var s = "1 + 1";
        var ans = Calculate(s);
    }

    private int idx = 0;

    public int Calculate(string s) {
        if (idx >= s.Length)
        {
            return 0;
        }
        int res = 0;
        var sign = '+';
        while (idx < s.Length)
        {
            if (s[idx] == ' ') {
                idx++;
                continue;
            }
            int cur = 0;
            while (idx < s.Length && s[idx] >= '0' && s[idx] <= '9')
            {
                cur = cur * 10 + (s[idx] - '0');
                idx++;
            }
            if (idx < s.Length && s[idx] == '(')
            {
                idx++;
                cur = Calculate(s);
            }
            if (sign == '+') res += cur;
            else if (sign == '-') res -= cur;
            if (idx < s.Length && (s[idx] == '+' || s[idx] == '-')) sign = s[idx];
            if (idx < s.Length && s[idx] == ')')
            {
                idx++;
                return res;
            }
            idx++;
        }
        return res;
    }
}
// @lc code=end

