/*
 * @lc app=leetcode.cn id=258 lang=csharp
 *
 * [258] 各位相加
 */

// @lc code=start
public class Solution258 {
    public void Test()
    {
        var ans = AddDigits(4);
    }

    public int AddDigits(int num) {
        int sum = 0;
        while (true)
        {
            while (num != 0)
            {
                var digit = num % 10;
                sum += digit;
                num = num / 10;
            }
            if (sum < 10)
            {
                return sum;
            }
            num = sum;
            sum = 0;
        }
    }
}
// @lc code=end

