/*
 * @lc app=leetcode.cn id=306 lang=csharp
 *
 * [306] 累加数
 */

// @lc code=start
using System.Collections.Generic;
using System.Text;
public class Solution306 {
    public void Test()
    {
        var num = "198019823962";
        //var num = "198199397";
        var ans = IsAdditiveNumber(num);
    }

    public bool IsAdditiveNumber(string num) 
    {
        var list = new List<long>();
        var ans = DFS(num, 0, list);
        return ans;
    }

    private bool DFS(string num, int index, List<long> numList)
    {
        if (index >= num.Length)
        {
            return numList.Count > 2;
        }
        long cur = 0;
        //如果是0，只能单独作为0，不能以0开头
        if (num[index] == '0')
        {
            if (numList.Count >= 2)
            {
                var pre = numList[numList.Count-1];
                var pre_pre = numList[numList.Count-2];
                return pre + pre_pre == 0; 
            }
            else
            {
                numList.Add(0);
                if(DFS(num ,index+1, numList))
                {
                    return true;
                }
                numList.RemoveAt(numList.Count -1);
                return false; 
            }
        }
        for (int i = index; i < num.Length; i++)
        {
            var number = (int)(num[i] - '0');
            cur = cur*10+number;
            if (numList.Count >= 2)
            {
                var pre = numList[numList.Count-1];
                var pre_pre = numList[numList.Count-2];
                if (cur < pre + pre_pre)
                    continue;
                if (cur > pre + pre_pre)
                    return false;
            }
            numList.Add(cur);
            if (DFS(num, i+1, numList))
            {
                return true;
            }
            numList.RemoveAt(numList.Count-1);
        }
        return false;
    }

    private bool DFS(string num, int index, List<string> numList)
    {
        if (index >= num.Length)
        {
            return numList.Count > 2;
        }
        var charList = new List<char>();
        //如果是0，只能单独作为0，不能以0开头
        if (num[index] == '0')
        {
            if (numList.Count >= 2)
            {
                var pre = numList[numList.Count-1];
                var pre_pre = numList[numList.Count-2];
                var sum = Add(pre, pre_pre);
                return Compare(sum, "0") == 0; 
            }
            else
            {
                numList.Add("0");
            }
            return DFS(num ,index+1, numList);
        }
        for (int i = index; i < num.Length; i++)
        {
            charList.Add(num[i]);
            var cur = new string(charList.ToArray());
            if (numList.Count >= 2)
            {
                var pre = numList[numList.Count-1];
                var pre_pre = numList[numList.Count-2];
                var sum = Add(pre, pre_pre);
                if (Compare(cur,sum) < 0)
                    continue;
                if (Compare(cur,sum) > 0)
                    return false;
            }
            numList.Add(cur);
            if (DFS(num, i+1, numList))
            {
                return true;
            }
            numList.RemoveAt(numList.Count-1);
        }
        return false;
    }

    private string Add(string add1, string add2)
    {
        var sb = new StringBuilder(add1.Length + add2.Length);
        int i = add1.Length-1;
        int j = add2.Length-1;
        int carry = 0;//进位
        while (i >= 0 || j >= 0)
        {
            var num1 = i >= 0 ? (int)(add1[i]-'0') : 0;
            var num2 = j >= 0 ? (int)(add2[j]-'0') : 0;
            var num = num1 + num2 + carry;
            carry = num >= 10 ? 1 : 0;
            sb.Append((char)(num%10 + 48));
            i--;
            j--;
        }
        if (carry == 1)
        {
            sb.Append('1');
        }
        var chars = new char[sb.Length];
        for (int k = 0; k < chars.Length; k++)
        {
            chars[k] = sb[sb.Length-k-1];
        }
        return new string(chars);
    }

    /// <summary>
    /// 比较两个数，0：相等，1：num1 > num2,2：num1 < num2
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    private int Compare(string num1, string num2)
    {
        if (num1.Length > num2.Length)
        {
            return 1;
        }
        if (num1.Length < num2.Length)
        {
            return -1;
        }
        for (int i = 0; i < num1.Length; i++)
        {
            if (num1[i] > num2[i])
            {
                return 1;
            }
            if (num1[i] < num2[i])
            {
                return -1;
            }
        }
        return 0;
    }
}
// @lc code=end

