/*
 * @lc app=leetcode.cn id=263 lang=csharp
 *
 * [263] 丑数
 */

// @lc code=start
public class Solution263 {
    public bool IsUgly(int n) 
    {
        if (n <= 0)
        {
            return false;
        }
        if (n == 1)
        {
            return true;
        }
        while (n % 2 == 0) n = n / 2;
        while (n % 3 == 0) n = n / 3;
        while (n % 5 == 0) n = n / 5;
        return n == 1;
    }
}
// @lc code=end

