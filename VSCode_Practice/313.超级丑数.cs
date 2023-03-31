/*
 * @lc app=leetcode.cn id=313 lang=csharp
 *
 * [313] 超级丑数
 */

// @lc code=start
public class Solution313 {
    public void Test(){
        var n = 12;
        var primes = new int[]{2,7,13,19};
        var ans = NthSuperUglyNumber(n, primes);
    }

    public int NthSuperUglyNumber(int n, int[] primes) {
        if (n == 1)
        {
            return 1;
        }
        var dp = new int[n+1];
        dp[1] = 1;
        var indeies = new int[primes.Length];
        for (int i = 0; i < indeies.Length; i++)
        {
            indeies[i] = 1;
        }
        for (int i = 2; i <= n; i++)
        {
            int min = int.MaxValue;
            for (int j = 0; j < primes.Length; j++)
            {
                min = Math.Min(min, dp[indeies[j]] * primes[j]);
            }
            dp[i] = min;
            for (int j = 0; j < primes.Length; j++)
            {
                if (min == primes[j] * dp[indeies[j]])
                {
                    indeies[j] += 1;
                }
            }
        }
        return dp[n];
    }
}
// @lc code=end

