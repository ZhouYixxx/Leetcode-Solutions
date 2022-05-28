/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
public class Solution007 {
    public void Test()
    {
        var x = int.MaxValue;
        var ans = Reverse(x);
        x = int.MinValue;
        ans = Reverse(x);
    }

    public int Reverse(int x) {
        var ans = 0;
        int digit = 0;
        while (x != 0)
        {
            digit = x % 10;
            x = x / 10;
            //超限检查
            if (digit >= 0 && (int.MaxValue - digit) / 10 < ans)
            {
                return 0;
            }
            if (digit <= 0 && (int.MinValue - digit) / 10 > ans)
            {
                return 0;
            }
            ans = ans*10 + digit;   
        }
        return ans;
    }
}
// @lc code=end

