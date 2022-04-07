/*
 * @lc app=leetcode.cn id=239 lang=csharp
 *
 * [239] 滑动窗口最大值
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution239 {

    public void Test()
    {
        var nums = new int[]{1,3,-1,-3,5,3,6,7};
        var k = 5;
        var ans = MaxSlidingWindow(nums, k);
    }

    public int[] MaxSlidingWindow(int[] nums, int k) {
        var ans = new int[nums.Length-k+1];
        //[index, value]格式
        var heap = new Heap<int[]>(false, MyCompare);
        int i = 0;
        while (i < nums.Length)
        {
            heap.Add(new int[2]{i, nums[i]});
            if (heap.Count < k)
            {
                i++;
                continue;
            }
            var l = i - k + 1;
            while (heap.Top()[0] < l)
            {
                heap.Pop();
            }
            ans[l] = heap.Top()[1];
        }
        return ans;
    }

    private int MyCompare(int[] x, int[] y)
    {
        if (x[1] == y[1])
        {
            return y[0].CompareTo(x[0]);
        }
        return x[1].CompareTo(y[1]);
    }

    private int FindMaxIndex(int[] nums, int l, int r)
    {
        int idx = l;
        for (int i = l+1; i <= r; i++)
        {
            if (nums[i] > nums[idx])
            {
                idx = i;
            }
        }
        return idx;
    }
}
// @lc code=end

