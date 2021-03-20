/*
 * @lc app=leetcode.cn id=1027 lang=csharp
 *
 * [1027] 最长等差数列
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution1027 {
    public void Test()
    {
        var a = new int[]{1,1,1,1,1,2,3,4};
        var ans = LongestArithSeqLength(a);
    }

    public int LongestArithSeqLength(int[] A) {
        if(A.Length == 2)
            return 0;
        var dp = new int[A.Length][];
        var dic = new Dictionary<int,int>();
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[A.Length];
            for (int j = 0; j < A.Length; j++)
            {
                dp[i][j] = 2;
            }
        }
        int max = 2;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = i+1; j < A.Length; j++)
            {
                var target = A[i]*2-A[j];
                if (dic.ContainsKey(target))
                {
                    var index = dic[target];
                    if(index < i)
                        dp[i][j] = dp[index][i] + 1;
                    //max = Math.Max(max, dp[i][j]);
                }
                max = Math.Max(max, dp[i][j]);
            }
            //必须在i循环的最后更新dic， 保证dic中的索引为最近的一个
            if (!dic.ContainsKey(A[i]))
            {
                dic.Add(A[i],i);
                continue;
            }
            dic[A[i]] = i;
        }
        return max >= 2 ? max : 0;
    }
}
// @lc code=end

