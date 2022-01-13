/*
 * @lc app=leetcode.cn id=747 lang=csharp
 *
 * [747] 至少是其他数字两倍的最大数
 */

// @lc code=start
using System;

public class Solution747 {
    public void Test()
    {
        var nums = new int[]{3,5,7,0,-2,4};
        var ans = DominantIndex(nums);
    }

    public int DominantIndex(int[] nums) 
    {
        var first = int.MinValue;
        var second = int.MinValue;
        int index = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            //当前值比最大值first大，first更新为当前值，同时将第二大值更新为first
            if (nums[i] > first)
            {
                second = first;
                first = nums[i];
                index = i;   
            }
            //当前值比secod大，需要更新second
            else if (nums[i] > second)
            {
                second = nums[i];
            }
        }
        return first >= second*2 ? index : -1;
    }
}
// @lc code=end

