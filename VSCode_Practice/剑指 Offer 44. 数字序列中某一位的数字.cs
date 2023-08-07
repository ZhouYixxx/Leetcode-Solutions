using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution_Offer44
{
    private char[] chars = new char[0];
    public void Test()
    {
        var sb = new StringBuilder(); 
        for (int i = 0; i < 1000; i++)
        {
            sb.Append(i.ToString());
        }
        chars = sb.ToString().ToCharArray();
        var num = 2147483647;
        var ans = FindNthDigit(num);
    }

    public int FindNthDigit(int n) {
        if (n < 10)
        {
            return n;
        }
        //判断是k位数
        int k = 1;
        
        while (n > GetKthDigitLength(k))
        {
            n -= (int)GetKthDigitLength(k);
            k++;
        }
        if (n == 0)
        {
            return 1;
        }
        //判断经过了多少个完整的k位数
        var remain = (n+1) % k;
        long num = (long)Math.Pow(10,k-1) + n / k;
        //现在第n位 = 数字num的第remain位数字
        return GetKthDigit(num, remain == 0 ? k : remain, k);
    }



    /// <summary>
    /// 获取数字num的第K位数
    /// </summary>
    /// <param name="num"></param>
    /// <param name="k"></param>
    /// <param name="numDigits"></param>
    /// <returns></returns>
    private int GetKthDigit(long num, int k, int numDigits)
    {
        long res = num;
        long digit = 0;
        while (numDigits >= k)
        {
            digit = res % 10;
            res /= 10;
            numDigits--;
        }
        return (int)digit;
    }

    /// <summary>
    /// 获取K位数占据的总长度,如两位数占据180个位置，3位数占据2700个位置
    /// </summary>
    private long GetKthDigitLength(int k)
    {
        if (k == 1)
        {
            return 10;
        }
        return (long)Math.Pow(10, k-1) * k * 9;
    }

    /// <summary>
    /// 获取K位数以下所有数字占据的总长度,如k=2时返回190，表示1位数和2位数共占据190个位置
    /// </summary>
    private long GetAllDightLenLessthanK(int k)
    {
        if (k == 1)
        {
            return 10;
        }
        //错位相减法可计算通项和公式
        return (long)(k * Math.Pow(10, k) - 5 * (k-1) * Math.Pow(10, k-2));

    }


    
}