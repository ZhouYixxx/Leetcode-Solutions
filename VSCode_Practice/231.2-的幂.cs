/*
 * @lc app=leetcode.cn id=231 lang=csharp
 *
 * [231] 2 的幂
 */

// @lc code=start
public class Solution231 {
    public bool IsPowerOfTwo(int n) 
    {
        var ans = n & (n-1);//将最低位1置0
        return n > 0 && ans == 0;

        var ans1 = n & (-n);//只保留最低位的1，其他全置0
        return n > 0 && ans1 == n;
    }
}
// @lc code=end

