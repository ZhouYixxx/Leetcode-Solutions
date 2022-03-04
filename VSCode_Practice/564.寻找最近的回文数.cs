/*
 * @lc app=leetcode.cn id=564 lang=csharp
 *
 * [564] 寻找最近的回文数
 */

// @lc code=start
using System;
using System.Linq;
using System.Text;
public class Solution564 {
    public void Test()
    {
        var x = "787";
        var ans = NearestPalindromic(x);
    }

    public string NearestPalindromic(string n) {
        //特殊情况1：小于10
        if (n.Length == 1)
        {
            var val = n[0] - '0' - 1;
            return val.ToString();
        }
        //特殊情况2：形如999...
        for (int i = 0; i < n.Length; i++)
        {
            if (n[i] != '9')
            {
                break;
            }
            if (i == n.Length-1)
            {
                var res = new char[n.Length+1];
                for (int j = 0; j < res.Length; j++)
                {
                    res[j] = j == 0 || j == res.Length-1 ? '1' : '0';
                }
                return new string(res);
            }
        }

        //特殊情况3：形如100, 10000...
        for (int i = 0; i < n.Length; i++)
        {
            if (i == 0 && n[i] != '1')
            {
                break;
            }
            if (i != 0 && i != n.Length-1 && n[i] != '0')
            {
                break;
            }
            if (i == n.Length-1 && n[i] != '0' && n[i] != '1')
            {
                break;
            }
            if (i == n.Length-1)
            {
                var res = new char[n.Length-1];
                for (int j = 0; j < res.Length; j++)
                {
                    res[j] = '9';
                }
                return new string(res);
            }
        }
        //一般情况
        var num = GetNearestPld(n);
        return num;
    }

    /// <summary>
    /// 获取回文数: n的前半部分，前半部分+1,前半部分-1，分别形成三个回文数，选择其中最近的
    /// </summary>
    /// <returns></returns>
    private string GetNearestPld(string n)
    {
        //找前半部分
        var start = (n.Length+1)/2;
        var prefix = 0;
        for (int i = 0; i < start; i++)
        {
            prefix = prefix*10+n[i] - '0';
        }
        //第一个数字
        var num1 = GetPldByPrefix(prefix, n);
        //第二个数字
        var num2 = GetPldByPrefix(prefix+1, n);
        //第三个数字
        var num3 = GetPldByPrefix(prefix-1, n);
        //选择最近的
        var num = ToInt(n);
        var nums = new long[3]{num1, num2, num3};
        long nearstNum = num1;
        long distance = int.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            var tempDis = Math.Abs(nums[i] - num);
            if (tempDis == 0) continue;
            if (tempDis < distance || 
                (tempDis == distance && nearstNum > nums[i]))
            {
                distance = Math.Abs(nums[i] - num);
                nearstNum = nums[i];
            }
        }
        return nearstNum.ToString();
    }

    /// <summary>
    /// 通过前缀49生成回文数4994或494
    /// </summary>
    /// <param name="prefix"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    private long GetPldByPrefix(int prefix, string n)
    {
        long num1 = prefix;
        //补全后面的部分
        var num_chars1 = prefix.ToString();
        //位数奇数和偶数情况有不同
        var start = (n.Length & 1) == 0 ? num_chars1.Length-1 : num_chars1.Length-2;
        for (int i = start; i >= 0; i--)
        {
            num1 = num1*10 + num_chars1[i]-'0';
        }
        return num1;
    }

    private long ToInt(string n)
    {
        long res = 0;
        for (int i = 0; i < n.Length; i++)
        {
            res = res*10 + n[i]-'0';
        }
        return res;
    }

}
// @lc code=end

