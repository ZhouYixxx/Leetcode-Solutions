/*
1281. 整数的各位积和之差
给你一个整数 n(1 <= n <= 10^5)，请计算并返回该整数「各位数字之积」与「各位数字之和」的差。

示例 1：
输入：n = 234
输出：15 
解释：
各位数之积 = 2 * 3 * 4 = 24 
各位数之和 = 2 + 3 + 4 = 9 
结果 = 24 - 9 = 15

 */

namespace CodePractice.LeetCode.Math
{
    public class ProductAndSum_1281
    {
        public int SubtractProductAndSum(int n)
        {
            int sum = 0;
            int product = 1;
            int digit = 0;
            while (n != 0)
            {
                digit = n % 10;
                sum += digit;
                product *= digit;
                n /= 10;
            }
            return product - sum;
        }
    }
}