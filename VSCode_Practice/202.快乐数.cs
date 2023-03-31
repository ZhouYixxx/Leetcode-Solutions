/*
 * @lc app=leetcode.cn id=202 lang=csharp
 *
 * [202] 快乐数
 */

// @lc code=start
public class Solution202 {
    public void Test(){
        var n = 2;
        var ans = IsHappy(n);
    }

    public bool IsHappy(int n) {
        var existed = new HashSet<int>();
        while (true)
        {
            int ans = 0;
            while (n != 0)
            {
                var digit = n % 10;
                ans += digit*digit;
                n = n / 10;
            }
            if (ans == 1)
            {
                return true;
            }
            if (!existed.Add(ans))
            {
                return false;
            }
            n = ans;   
        }
    }
}
// @lc code=end

