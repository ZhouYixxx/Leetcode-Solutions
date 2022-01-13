/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 */

// @lc code=start
using System.Collections.Generic;
public class Solution78 
{
    public void Test()
    {
        var nums = new int[]{1,2,3};
        var ans = Subsets(nums);
    }

    public IList<IList<int>> Subsets(int[] nums) 
    {
        var ans = new List<IList<int>>();
        Backtrack(0, nums, ans, new List<int>());
        return ans; 
    }

    private void Backtrack(int start, int[] nums, List<IList<int>> ans, List<int> path)
    {
        if (start > nums.Length)
        {
            return;
        }
        ans.Add(new List<int>(path));
        for (int i = start; i < nums.Length; i++)
        {
            path.Add(nums[i]);
            Backtrack(i+1,nums,ans, path);
            path.RemoveAt(path.Count-1);
        }
    }
}
// @lc code=end

