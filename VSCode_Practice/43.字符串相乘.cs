/*
 * @lc app=leetcode.cn id=43 lang=csharp
 *
 * [43] 字符串相乘
 */

// @lc code=start
using System.Text;
public class Solution43 {
    public void Test()
    {
        var num1 = "123";
        var num2 = "789";
        var test = Add(num1, num2);
        var ans = Multiply_optimize(num1, num2);
    }

    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }
        var carry = 0;
        var ans = "";
        int expandCount = 0;
        for (int i = num2.Length-1; i >= 0; i--)
        {
            var str = "";
            for (int j = num1.Length-1; j >= 0; j--)
            {
                var val = (num1[j]-'0') * (num2[i]-'0') + carry;
                carry = val / 10;
                var digit = val % 10;
                str = $"{digit}{str}";
            }
            if (carry != 0)
            {
                str = $"{carry}{str}";
                carry = 0;
            }
            for (int k = 0; k < expandCount; k++)
            {
                str = str + "0";
            }
            ans = Add(ans, str);
            expandCount++;
        }
        return ans;
    }

    /// <summary>
    /// 优化的竖式
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public string Multiply_optimize(string num1, string num2) {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }
        var numArray = new List<int>[num1.Length + num2.Length];
        for (int i = 0; i < numArray.Length; i++)
        {
            numArray[i] = new List<int>();
        }
        int offset = 0;
        for (int i = num2.Length-1; i >= 0; i--)
        {
            var startPos = numArray.Length - 1  - offset;
            for (int j = num1.Length-1; j >= 0; j--)
            {
                var val = (num1[j] - '0') *(num2[i] - '0');
                if (val < 10)
                {
                    numArray[startPos].Add(val);
                }
                else
                {
                    var val1 = val % 10;
                    var val2 = val / 10;
                    numArray[startPos].Add(val1);
                    numArray[startPos-1].Add(val2);
                }
                startPos--;
            }
            offset++;
        }
        int carry = 0;
        var res = new char[numArray.Length];
        for (int i = numArray.Length-1; i >= 0; i--)
        {
            var sum = numArray[i].Sum() + carry;
            carry = sum / 10;
            var digit = sum % 10;
            res[i] = (char)(digit + '0');
        }
        var ans = new string(res);
        if (ans[0] <= '0' || ans[0] > '9')
        {
            ans = ans.Substring(1,ans.Length-1);
        }
        return ans;
    }

    private string Add(string num1, string num2)
    {
        if (string.IsNullOrEmpty(num1))
        {
            return num2;
        }
        if (string.IsNullOrEmpty(num2))
        {
            return num1;
        }
        if (num1.Length < num2.Length)
        {
            var temp = num1;
            num1 = num2;
            num2 = temp;
        }
        int idx1 = num1.Length-1;
        int idx2 = num2.Length-1;
        int carry = 0;
        var sum = new int[num1.Length+1];
        int sum_idx = sum.Length-1;
        while (idx1 >= 0)
        {
            var val1 = num1[idx1]-'0';
            var val2 = idx2 >= 0 ? num2[idx2]-'0' : 0;
            var digit = (val1 + val2 + carry) % 10;
            carry = (val1 + val2 + carry) / 10;
            sum[sum_idx] = digit;
            sum_idx--;
            idx1--;
            idx2--;
        }
        if (carry != 0)
        {
            sum[0] = carry;
        }
        var sb = new StringBuilder(sum.Length);
        for (int i = 0; i < sum.Length; i++)
        {
            if (i == 0 && sum[i] == 0) continue;
            sb.Append(sum[i].ToString());
        }
        return sb.ToString();
    }
}
// @lc code=end

