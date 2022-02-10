/*
 * @lc app=leetcode.cn id=1447 lang=csharp
 *
 * [1447] 最简分数
 */

// @lc code=start
using System.Collections.Generic;
public class Solution1447 {
    public void Test()
    {
        var n = 6;
        var s = gcd(35, 98);
        var ans = SimplifiedFractions(n);
    }

    public IList<string> SimplifiedFractions(int n) 
    {
        if (n == 1)
        {
            return new List<string>();
        }
        var ans = new List<string>();
        for (int i = 1; i < n; i++)
        {
            if (gcd1(i,n) == 1)
            {
                ans.Add(new string($"{i}/{n}"));
            }
        }
        var ans1 = SimplifiedFractions(n-1);
        ans.AddRange(ans1);
        return ans;
    }

    private int gcd(int a, int b)
    {
        var r = a % b;
        var temp = 0;
        while (r != 0)
        {
            temp = r;
            r = b % r;
            b = temp;
        }
        return b;
    }

    private int gcd1(int a, int b)
    {
        var r = a % b;
        if (r == 0)
        {
            return b;
        }
        return gcd1(b, r);
    }
}
// @lc code=end

