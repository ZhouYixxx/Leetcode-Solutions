/*
 * @lc app=leetcode.cn id=873 lang=csharp
 *
 * [873] 最长的斐波那契子序列的长度
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution873 {
    public void Test()
    {
        var nums = new int[]{1,2,3,4,5,6,7,8};
        var a = LenLongestFibSubseq(nums);
    }

    public int LenLongestFibSubseq(int[] arr) 
    {
/*         var n = arr.Length;
        var dp = new int[n,n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i,j] = 2;
            }
        }
        var dic = new Dictionary<int ,int>();
        for (int i = 0; i < n; i++)
        {
            dic.Add(arr[i], i);
        }

        int max = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j<n; j++)
            {
                var diff = arr[j] - arr[i];
                if (dic.ContainsKey(diff) && dic[diff] < i)
                {
                    var index = dic[diff];
                    dp[i,j] = dp[index,i] + 1;
                }
                max = Math.Max(dp[i,j], max);
            }
        }

        return max > 2 ? max : 0; */

        var n = arr.Length;
        var dp = new int[n][];
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = 2;
            }
        }
        var dic = new Dictionary<int,int>();
        for (int i = 0; i < n; i++)
        {
            dic.Add(arr[i], i);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                var diff = arr[j] - arr[i];
                if (dic.ContainsKey(diff))
                {
                    var k = dic[diff];
                    dp[i][j] = dp[k][i] + 1;
                }
                max = Math.Max(max, dp[i][j]);
            }
        }
        return max > 2 ? max : 0;
    }
}
// @lc code=end

