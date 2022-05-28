/*
 * @lc app=leetcode.cn id=384 lang=csharp
 *
 * [384] 打乱数组
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution384 {

    int[] origin = new int[16];
    public Solution384(int[] nums) {
        origin = new int[nums.Length];
        Array.Copy(nums, origin, origin.Length);
    }
    
    public int[] Reset() {
        var res = new int[origin.Length];
        Array.Copy(origin, res, origin.Length);
        return res;
    }
    
    public int[] Shuffle() {
        var res = new int[origin.Length];
        var temp = new List<int>(origin.Length);
        for (int i = 0; i < origin.Length; i++)
        {
            temp.Add(origin[i]);
        }
        var used = new bool[origin.Length];
        var random = new Random();
        for (int i = 0; i < res.Length; i++)
        {
            var random_index = random.Next(0,temp.Count);
            res[i] = temp[random_index];
            temp.RemoveAt(random_index);
        }
        return res;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */
// @lc code=end

