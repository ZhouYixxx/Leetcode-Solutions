/*
 * @lc app=leetcode.cn id=2475 lang=csharp
 *
 * [2475] 数组中不等三元组的数目
 */

// @lc code=start
using System.Collections;

public class Solution_LCR05 {
    public void Test()
    {
        var words = new string[]{"abcw","baz","foo","bar","fxyz","abcdef"};
        var ans = MaxProduct(words);
    }

    public int MaxProduct(string[] words) {
        int n = words.Length;
        var masks = new int[n];
        var bitArrays = new List<BitArray>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                masks[i] = masks[i] | (1 << (int)(words[i][j] -'a'));
            }
            bitArrays.Add(new BitArray(new int[]{masks[i]}));
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                //不包含相同字符
                if ((masks[i] & masks[j]) == 0)
                {
                    ans = Math.Max(ans, words[i].Length * words[j].Length);
                }
            }
        }
        return ans;
    }
}
// @lc code=end

