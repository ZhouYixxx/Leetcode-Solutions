/*
 * @lc app=leetcode.cn id=217 lang=csharp
 *
 * [217] 存在重复元素
 */

// @lc code=start
using System.Collections.Generic;

public class Solution217 {
    public void Test()
    {
        var nums =new int[]{1,3,4,2,5,2};
        var ans = ContainsDuplicate(nums);
    }

    public bool ContainsDuplicate(int[] nums) {
        var set = new HashSet<int>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Add(nums[i]))
            {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

