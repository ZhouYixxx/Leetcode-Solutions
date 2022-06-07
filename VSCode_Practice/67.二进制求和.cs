/*
 * @lc app=leetcode.cn id=67 lang=csharp
 *
 * [67] 二进制求和
 */

// @lc code=start
public class Solution67 {
    public void Test()
    {
        var a = "11101";
        var b = "11011101";
        var ans = AddBinary(a, b);
    }

    public string AddBinary(string a, string b) {
        int idx1 = a.Length-1;
        int idx2 = b.Length-1;
        int carry = 0;
        var ans = new char[Math.Max(a.Length, b.Length) + 1];
        var idx = ans.Length-1;
        while (idx1 >= 0 || idx2 >= 0)
        {
            var val1 = idx1 < 0 ? 0 : a[idx1--] - '0';
            var val2 = idx2 < 0 ? 0 : b[idx2--] - '0';
            var val = val1 + val2 + carry;
            if (val >= 2)
            {
                carry = 1;
                val -= 2;
            }
            else
            {
                carry = 0;
            }
            ans[idx--] = (char)(val + '0');
        }
        if (carry == 1)
        {
            ans[idx] = '1';
        }
        //根据是否进位确定最终的结果
        if (ans[0] != '1')
        {
            return new string(ans,1, ans.Length-1);
        }
        return new string(ans);
    }
}
// @lc code=end

