/*
 * @lc app=leetcode.cn id=264 lang=csharp
 *
 * [264] 丑数 II
 */

// @lc code=start
using System;

public class Solution264 {
    public void Test(){
        var n = 11;
        var ans = NthUglyNumber(n);
    }

    public int NthUglyNumber(int n) 
    {
        if (n == 1)
        {
            return 1;
        }
        var res = new int[n];
        res[0] = 1;
        int i = 0, j = 0, k = 0, cur = 1;
        while (cur < n)
        {
            var num1 = res[i]*2;
            var num2 = res[j]*3;
            var num3 = res[k]*5;
            var ans = Math.Min(num1, Math.Min(num2, num3));
            res[cur++] = ans;
            if (ans == num1)
            {
                i++;
            }
            if (ans == num2)
            {
                j++;
            }
            if (ans == num3)
            {
                k++;
            }
        }
        return res[n-1];
    }

    public int NthSuperUglyNumber_20220715(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        var dp = new int[n+1];
        dp[1] = 1;
        int p2 = 1, p3 = 1, p5 = 1;
        for (int i = 2; i <= n; i++)
        {
            var a = dp[p2]*2;
            var b = dp[p3]*3;
            var c = dp[p5]*5;
            var min = Math.Min(a, Math.Min(b,c));
            if (min == a) p2++;
            if (min == b) p3++;
            if (min == c) p5++;
        }
        return dp[n];
    }
}
// @lc code=end

