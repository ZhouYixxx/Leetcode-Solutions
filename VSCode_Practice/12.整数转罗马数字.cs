/*
 * @lc app=leetcode.cn id=12 lang=csharp
 *
 * [12] 整数转罗马数字
 */

// @lc code=start

using System.Collections.Generic;
using System.Text;

public class Solution012 {
    public void Test()
    {
        var s = 1;
        var ans = IntToRoman(s);
    }
    Dictionary<string, int> romanDic = new Dictionary<string, int>(){{"M", 1000},{"CM", 900},
        {"D", 500},{"CD",400},{"C",100},{"XC",90},{"L",50},{"XL",40},{"X",10},{"IX",9},{"V",5},{"IV",4},{"I",1}
    };

    public string IntToRoman(int num) {
        var sb = new StringBuilder();
        while (num != 0)
        {
            foreach (var item in romanDic)
            {
                if (num >= item.Value)
                {
                    num -= item.Value;
                    sb.Append(item.Key);
                    break;
                }
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

