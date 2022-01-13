/*
 * @lc app=leetcode.cn id=47 lang=csharp
 *
 * [47] 全排列 II
 */

// @lc code=start
using System.Collections.Generic;
public class Solution47 {
    public void Test()
    {
        var nums = new int[]{2,1,1,1};
        var ans = PermuteUnique(nums);
    }
    
    public IList<IList<int>> PermuteUnique(int[] nums) 
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        var visited = new bool[nums.Length];
        BackTrack(nums, path, res, visited);
        return res;
    }

    private void BackTrack(int[] nums, List<int> path, List<IList<int>> res, bool[] visited)
    {
        if (path.Count == nums.Length)
        {
            res.Add(new List<int>(path));
            return;
        }
        var duplicated = new HashSet<int>();//在本层循环中，如果出现重复的数字则直接跳过
        for (int i = 0; i < nums.Length; i++)
        {
            if (visited[i] || duplicated.Contains(nums[i]))
            {
                continue;
            }
            var num = nums[i];
            visited[i] = true;
            path.Add(num);
            duplicated.Add(num);
            BackTrack(nums, path, res, visited);
            visited[i] = false;
            //used.Remove(num);
            path.RemoveAt(path.Count-1);
        }
    }
}
// @lc code=end

