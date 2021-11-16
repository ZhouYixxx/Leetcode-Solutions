/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution46 {
    public void Test()
    {
        var nums = new int[]{1,2,3};
        var ans = Permute(nums);
    }

    public IList<IList<int>> Permute(int[] nums) 
    {
        var list = new List<IList<int>>();
        var visited = new bool[nums.Length];
        BackTrack(nums,list,visited, new List<int>());
        return list;
    }

    private void BackTrack(int[] nums, List<IList<int>> res, bool[] visited, List<int> tempRes)
    {
        if (tempRes.Count == nums.Length)
        {
            res.Add(new List<int>(tempRes));
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (visited[i])
                continue;
            visited[i] = true;
            tempRes.Add(nums[i]);
            // var str = "";
            // foreach (var item in tempRes)
            // {
            //     str += $"{item}, ";
            // }
            // Console.WriteLine($"递归前：tempRes={str}");
            BackTrack(nums, res, visited, tempRes);
            // str = "";
            // foreach (var item in tempRes)
            // {
            //     str += $"{item}, ";
            // }
            // Console.WriteLine($"递归后：tempRes={str}");
            visited[i] = false;
            tempRes.RemoveAt(tempRes.Count-1);
        }
    }
}
// @lc code=end

