/*
 * @lc app=leetcode.cn id=42 lang=csharp
 *
 * [42] 接雨水
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution42 {
    public void Test()
    {
        var nums = new int[]{0,1,0,2,1,0,1,3,2,1,2,1};
        var ans = Trap(nums);
    }

    //单调栈方法O(N)
    public int Trap(int[] height) 
    {
        //递减的单调栈
        var stack = new Stack<int>();
        int index = 0;
        int ans = 0;
        while (index < height.Length)
        {
            if (stack.Count == 0)
            {
                stack.Push(index++);
                continue;
            }
            var top = stack.Peek();
            //当前位置高度 <= 栈顶位置高度,入栈,否则出栈
            while (stack.Count != 0 && height[top] < height[index])
            {
                var bottom = stack.Pop();
                if (stack.Count == 0)
                {
                    break;
                }
                var left = stack.Peek();
                var right = index;
                var w = right-left-1;
                var h = Math.Min(height[left], height[right]) - height[bottom];
                ans += w*h;
                top = left;    
            }
            stack.Push(index++);
        }
        return ans;
    }

    //双指针方法O(N)
    public int Trap2(int[] height) 
    {
        var left = 0;
        var right = height.Length-1;
        var left_max = 0;
        var right_max = 0;
        var ans = 0;

        //在某个位置i处，它能存的水，取决于它左右两边的最大值中较小的一个。
        //对于left而言，left_max一定是左边最大的值，但是right_max不一定是右边最大的值，对于right同理
        //如果此时left_max <= right_max,无论右边将来会不会出现更大的right_max都不影响i处能存储的水量，因此此时要处理left下标并更新left_max
        //如果此时left_max > right_max,无论左边将来会不会出现更大的left_max都不影响i处能存储的水量，因此此时要处理right下标并更新right_max
        while (left <= right)
        {
            if (left_max < right_max)
            {
                ans += Math.Max(0,left_max-height[left]);
                left_max = Math.Max(left_max,height[left]);
                left++;
            }
            else
            {
                ans += Math.Max(0,right_max-height[right]);
                right_max = Math.Max(right_max,height[right]);
                right--;
            }
        }
        return ans;
    }
}
// @lc code=end

