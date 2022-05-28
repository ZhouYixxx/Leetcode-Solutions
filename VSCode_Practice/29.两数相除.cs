/*
 * @lc app=leetcode.cn id=29 lang=csharp
 *
 * [29] 两数相除
 */

// @lc code=start
public class Solution29 {
    public void Test()
    {
        var num1 = int.MaxValue;
        var num2 = 3;
        var ans = Divide(num1, num2);
    }

    public int Divide(int dividend, int divisor) {
        if (divisor == 1)
        {
            return dividend;
        }
        if (divisor == -1)
        {
            return dividend == int.MinValue ? int.MaxValue : -dividend;
        }
        int max_d = -1073741824;//超过这个数，除数不能再翻倍
        var isNeg = (dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0);
        //转化为负数
        if (dividend > 0)
        {
            dividend = -dividend;
        }
        int dividend_internal = dividend;
        if (divisor > 0)
        {
            divisor = -divisor;
        }
        int divisor_internal = divisor;
        int ans = 0;
        //被除数大于等于除数，就继续进行除法(负数则相反)
        while (dividend_internal <= divisor)
        {
            int cnt = 1;
            /**
            以 99/5 为例子，对5不断翻倍，5 -> 10 -> 20 -> 40 -> 80 -> 160，此时160超出99，即可用99-80 = 19进入下一轮。
            5 -> 80总共翻倍4次，也就是2^4=16倍，计数器+16。
            必须把正数转化为负数计算, 否则1.负数转正数可能溢出，2. 计数cnt不停乘以2可能造成溢出，因为int.Max = 2³²-1不等于2的幂
            **/
            while (divisor_internal >= max_d && dividend_internal <= (divisor_internal + divisor_internal))
            {
                divisor_internal = divisor_internal + divisor_internal;
                cnt = (cnt << 1);   
            }
            dividend_internal -= divisor_internal;
            divisor_internal = divisor;
            ans += cnt;
        }
        return isNeg ?  -ans : ans;
    }
}
// @lc code=end

