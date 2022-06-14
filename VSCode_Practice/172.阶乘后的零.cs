/*
 * @lc app=leetcode.cn id=172 lang=csharp
 *
 * [172] 阶乘后的零
 */

// @lc code=start
public class Solution172 {
    public void Test()
    {
        var n = 6;
        var ans = TrailingZeroes(n);
    }

    public int TrailingZeroes(int n) {
        int count = 0;
        while ( n != 0)
        {
            n /= 5;
            count += n;
        }
        return count;
    }
}
// @lc code=end

