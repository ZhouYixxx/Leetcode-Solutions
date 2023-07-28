/*
 * @lc app=leetcode.cn id=279 lang=csharp
 *
 * [279] 完全平方数
 */

// @lc code=start
public class Solution279 {
    public void Test()
    {
    }
    public int NumSquares(int n) {
        int[] f = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            int minn = int.MaxValue;
            for (int j = 1; j * j <= i; j++) {
                minn = Math.Min(minn, f[i - j * j]);
            }
            f[i] = minn + 1;
        }
        return f[n];
    }


}
// @lc code=end

