/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution84 {
    public void Test()
    {
        var nums = new int[]{0,1,0,2,1,0,1,3,2,1,2,1};
        //var nums = new int[]{2,1,5,6,2,3};
        var ans = LargestRectangleArea(nums);
    }

    //以第i个柱子的高度为矩形高，该矩形的宽度 W = right_i - left_i - 1;
    //其中left_i，right_i是i左边和右边第一个比它矮的柱子的索引
    //要找数组中下一个比某个值更小的元素，用递增单调栈
    public int LargestRectangleArea(int[] heights) 
    {
        var stack = new Stack<int>();
        var max = 0;
        var newHeights = new int[heights.Length+2];
        for (int i = 1; i < newHeights.Length-1; i++)
        {
            newHeights[i] = heights[i-1];
        }
        for (int i = 0; i < newHeights.Length; i++)
        {
            while (stack.Count != 0 && newHeights[stack.Peek()] > newHeights[i])
            {
                var top = stack.Pop();
                if (stack.Count == 0)
                {
                    max = Math.Max(max, newHeights[top]);
                    break;
                }
                var right = i;//矩形右边界是i（开区间）
                var left = stack.Peek();//矩形左边界是当前栈顶元素位置（开区间）
                max = Math.Max(max,newHeights[top]*(right-left-1));
            }
            stack.Push(i);
        }
        return max;
    }
}
// @lc code=end

