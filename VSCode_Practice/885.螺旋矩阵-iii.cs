/*
 * @lc app=leetcode.cn id=885 lang=csharp
 *
 * [885] 螺旋矩阵 III
 */

// @lc code=start
using System;

public class Solution885 {
    public void Test()
    {
        var ans = SpiralMatrixIII(3,3,1,0);
    }


    public int[][] SpiralMatrixIII(int R, int C, int r0, int c0) {
        var ans = new int[R*C][];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = new int[2];
        }
        ans[0][0] = r0;
        ans[0][1] = c0;
        if (R*C == 1)
        {
            return ans;
        }
        int index = 1;
        int step = 1;
        int stepCount = 1;
        int dir = 0;//四个方向
        while (index < R*C)
        {
            if (stepCount > 2)
            {
                stepCount = 1;
                step++;
            }
            for (int i = 0; i < step; i++)
            {
                //向东
                if (dir == 0)
                {
                    c0++;
                    if (r0 < R && r0 >= 0 && c0 < C && c0 >= 0)
                    {
                        ans[index][0] = r0;
                        ans[index][1] = c0;
                        index++;
                    }
                }
                //向南
                if (dir == 1)
                {
                    r0++;
                    if (r0 < R && r0 >= 0 && c0 < C && c0 >= 0)
                    {
                        ans[index][0] = r0;
                        ans[index][1] = c0;
                        index++;
                    }
                } 
                //向西
                if (dir == 2)
                {
                    c0--;
                    if (r0 < R && r0 >= 0 && c0 < C && c0 >= 0)
                    {
                        ans[index][0] = r0;
                        ans[index][1] = c0;
                        index++;
                    }
                }    
                //向北
                if (dir == 3)
                {
                    r0--;
                    if (r0 < R && r0 >= 0 && c0 < C && c0 >= 0)
                    {
                        ans[index][0] = r0;
                        ans[index][1] = c0;
                        index++;
                    }
                }           
            }
            dir = dir == 3 ? 0 : dir+1;
            stepCount++;
        }
        return ans;
    }
}
// @lc code=end

