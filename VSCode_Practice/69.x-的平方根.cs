/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 */

// @lc code=start
public class Solution69 {
    public int MySqrt(int x) {
        if (x == 0)
        {
            return x;
        }
        return (int) MySqrtFunc(x, x * 1.0);
    }

    public double MySqrtFunc(int n, double sqrt)
    {
        var newSqrt = (sqrt + n / sqrt) / 2;
        if (System.Math.Abs(sqrt - newSqrt) <= 1E-6)
        {
            return sqrt;
        }
        sqrt = newSqrt;
        //牛顿迭代法
        return MySqrtFunc(n, sqrt);
    }
}
// @lc code=end

