/*
 * @lc app=leetcode.cn id=2006 lang=csharp
 *
 * [2006] 差的绝对值为 K 的数对数目
 */

// @lc code=start
using System.Collections.Generic;

public class Solution2006 {
    public void Test()
    {
        var nums = new int[]{3,4};
        int k = 2;
        var ans = CountKDifference(nums, k);
    }

    public int CountKDifference(int[] nums, int k) 
    {
        var ans = 0;
        var cntDic = new Dictionary<int, int>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            ans += cntDic.ContainsKey(nums[i] + k) ? cntDic[nums[i] + k] : 0;
            ans += cntDic.ContainsKey(nums[i] - k) ? cntDic[nums[i] - k] : 0;
            cntDic[nums[i]] = cntDic.ContainsKey(nums[i]) ? cntDic[nums[i]] + 1 : 1;
        }
        return ans;
    }
}
// @lc code=end

