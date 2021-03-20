/*
 * @lc app=leetcode.cn id=485 lang=csharp
 *
 * [485] 最大连续1的个数
 */

// @lc code=start

using System;
using System.Collections.Generic;

public class SolutionLCP19 {
    public void Test()
    {
        var staple = new int[]{3,4};
        var drinks = new int[]{1};
        var leaves = "yry";
        var ans = minimumOperations(leaves);
        Console.WriteLine(ans);
        Console.Read();
    }

    public int minimumOperations(String leaves) 
    {
        int[][] state = new int[leaves.Length][];
        for (int i = 0; i < state.Length; i++)
        {
            state[i] = new int[3];
        }
        //初始值
        state[0][0] = leaves[0] == 'r' ? 0 : 1;
        state[0][1] = state[0][2] = (int)1E5+1;
        state[1][2] = (int)1E5+1;
        //状态转移
        for (int i = 1; i < leaves.Length; i++)
        {
            var ch = leaves[i];
            //state[i][0] = ch == 'r' ? state[i-1][0] : state[i-1][0]+1;
            if (ch == 'r')
            {
                state[i][0] = state[i-1][0];
                state[i][1] = Math.Min(state[i-1][0]+1, state[i-1][1]+1);
                if (i > 1)
                {
                    state[i][2] = Math.Min(state[i-1][1], state[i-1][2]);
                }
            }
            else
            {
                state[i][0] = state[i-1][0]+1;
                state[i][1] = Math.Min(state[i-1][0], state[i-1][1]);
                if (i > 1)
                {
                    state[i][2] = Math.Min(state[i-1][1]+1, state[i-1][2]+1);
                }
            }
        }
        return state[leaves.Length-1][2];
    }
}