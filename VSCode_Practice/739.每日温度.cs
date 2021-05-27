/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution739 {
    public void Test()
    {
        var temperatures  = new int[]{73, 74, 75, 71, 69, 72, 76, 73};
        var ans = DailyTemperatures(temperatures);
    }

    //找下一个最大最小，单调栈问题
    public int[] DailyTemperatures(int[] T) 
    {
        var res = new int[T.Length];
        //单调栈存储下标
        var stack = new Stack<int>();
        for (int i = 0; i < T.Length; i++)
        {
            while (true)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                    break;
                }
                //找下一个最大值，栈应该从底部开始是递减的
                //找下一个最小值，栈应该从底部开始是递增的
                var preIndex = stack.Peek();
                if (T[i] > T[preIndex])
                {
                    stack.Pop();
                    res[preIndex] = i - preIndex;
                }
                else
                {
                    stack.Push(i);
                    break;
                }
            } 
        }
        return res;
    }
}
// @lc code=end

