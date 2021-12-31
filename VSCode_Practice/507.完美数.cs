/*
 * @lc app=leetcode.cn id=507 lang=csharp
 *
 * [507] 完美数
 */

// @lc code=start
public class Solution507 {
    public void Test()
    {
        var num = 28;
        var ans = CheckPerfectNumber(num);
    }

    public bool CheckPerfectNumber(int num) 
    {
        if (num == 1)
        {
            return false;
        }
        int ans = 1;
        for (int i = 2; i <= num/i; i++)
        {
            if (num % i == 0)
            {
                ans += i;
                if (i * i != num)
                {
                    ans += num/i;
                }
            }
        }
        return ans == num;
    }
}
// @lc code=end

