/*
 * @lc app=leetcode.cn id=166 lang=csharp
 *
 * [166] 分数到小数
 */

// @lc code=start
using System.Text;
public class Solution166 {
    public void Test(){
        var num1 = -1;
        var num2 = -2147483648;
        var ans = FractionToDecimal(num1, num2);
    }

    public string FractionToDecimal(int numerator, int denominator) {
        //可能溢出的唯一情况
        if (numerator == int.MinValue && denominator == -1)
        {
            return numerator.ToString().Substring(1);
        }
        var intPart = numerator / denominator;
        var remain = numerator % denominator;
        //直接整除的情况
        if (remain == 0)
        {
            return $"{intPart}";
        }
        bool isNeg =( numerator < 0 && denominator > 0) || ( numerator > 0 && denominator < 0);
        //将数字全部转化为负数，若转化为正数，int.MinValue绝对值比int.MaxValue大1，有溢出的可能
        if (remain > 0)
        {
            remain *= -1;
        }
        if (denominator > 0)
        {
            denominator *= -1;
        }
        var decmialPart = TrueFractionToDecimal((long)remain, (long)denominator, out var noRemain);
        //能够除尽
        var ans = "";
        if (noRemain)
        {
            ans = intPart == 0 ? $"0.{decmialPart}" : $"{intPart}.{decmialPart}";   
        }
        //循环小数
        else
        {
            ans = intPart == 0 ? $"0.{decmialPart}" : $"{intPart}.{decmialPart}";  
        }
        if (isNeg && intPart == 0)
        {
            ans = $"-{ans}";
        }
        return ans;
    }

    /// <summary>
    /// 真分数转小数
    /// </summary>
    /// <param name="numerator"></param>
    /// <param name="denominator"></param>
    /// <param name="noRemainder"></param>
    /// <returns></returns>
    private string TrueFractionToDecimal(long numerator, long denominator, out bool noRemainder)
    {
        //key:存储被除数，value：存储当前被除数的顺序
        var existSet = new Dictionary<long ,int>();
        var builder = new StringBuilder();
        noRemainder = false;
        int dupllIndex = 0;
        int idx = 0;
        while (true)
        {
            numerator *= 10;
            var remain = numerator % denominator;
            var digit = (int)(numerator / denominator);
            //能够整除
            if (remain == 0 && digit > 0)
            {
                builder.Append($"{digit}");
                noRemainder = true;
                break;
            }
            //发现循环
            if (existSet.ContainsKey(numerator))
            {
                dupllIndex = existSet[numerator];
                break;
            }
            else
            {
                existSet.Add(numerator, idx++);
            }
            numerator = remain;
            builder.Append($"{digit}");
        }
        //循环部分添加括号
        if (!noRemainder)
        {
            //找到循环的起始位置
            builder.Insert(dupllIndex,'(');
            builder.Append(')');
            return builder.ToString();   
        }
        return  builder.ToString();
    }
}
// @lc code=end

