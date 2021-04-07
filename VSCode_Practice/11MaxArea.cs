/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
using System;
public class Solution11 {

    public void Test()
    {
        var height = new int[]{2,3,4,5,18,17,6};
        var max = MaxArea(height);
    }
    public int MaxArea(int[] height) {
        if (height.Length == 0)
        {
            return 0;
        }
        var start = 0;
        var end = height.Length-1;
        var max = 0;
        while (start < end)
        {
            max = Math.Max(max,(end-start)*Math.Min(height[end],height[start]));
            if(height[start] < height[end])
            {
                start++;
            }
            else{
                end--;
            }
        }
        return max;
    }
}
// @lc code=end

