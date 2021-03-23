/*
 * @lc app=leetcode.cn id=887 lang=csharp
 *
 * [887] 鸡蛋掉落
 */

// @lc code=start
using System;

public class Solution {
    public int SuperEggDrop(int k, int n) {
        // dp[i][j] i 个鸡蛋扔 j 次能确定的最大区间的层数
        int[,] dp = new int[k + 1, n + 1];

        for (int j = 1; j <= n; j++)
            for (int i = 1; i <= k; i++)
            {
                dp[i, j] = dp[i - 1, j - 1] + dp[i, j - 1] + 1;
                if (dp[i, j] >= n)
                    return j;
            }
        return n;
    }
}
// @lc code=end

