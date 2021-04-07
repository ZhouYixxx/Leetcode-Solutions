/*
 * @lc app=leetcode.cn id=485 lang=csharp
 *
 * [485] 最大连续1的个数
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class SolutionLCP18 {
    public void Test()
    {
        var staple = new int[]{3,4};
        var drinks = new int[]{1};
        BreakfastNumber(staple, drinks,5);
    }

    public int BreakfastNumber(int[] staple, int[] drinks, int x) 
    {
        Array.Sort(staple);
        Array.Sort(drinks);
        int number = 0;
        int mod = (int)(1E9+7);
        int j = drinks.Length -1;
        for (int i = 0; i < staple.Length; i++)
        {
            if (staple[i] >= x)
            {
                continue;
            }
            while (j>=0 && staple[i] + drinks[j] > x)
            {
                j--;
            }
            if (j == -1)
            {
                break;
            }
            number += j+1;
        }
        return number %= mod;
    }
}

