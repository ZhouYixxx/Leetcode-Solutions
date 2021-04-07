/*
 * @lc app=leetcode.cn id=1423 lang=csharp
 *
 * [1423] 可获得的最大点数
 */

// @lc code=start
using System;
public class Solution1423 {
    
    public void Test()
    {
        var nums = new int[]{3};
        MaxScore(nums,1);
    }
    public int MaxScore(int[] cardPoints, int k) {
        var n = cardPoints.Length;
        //求大小为n-k的滑动窗口的最小值
        var start = 0;
        var end = n-k-1;
        var total = 0;
        var subTotal = 0;
        for (int i = 0; i < n; i++)
        {
            if (i <= end)
            {
                subTotal += cardPoints[i];
            }
            total += cardPoints[i];
        }
        var min = subTotal;
        while(end < n-1)
        {
            end++;
            subTotal += cardPoints[end]-cardPoints[start];
            if(subTotal < min)
                min = subTotal;
            start++;
        }
        return total - min;
    }
}
// @lc code=end

