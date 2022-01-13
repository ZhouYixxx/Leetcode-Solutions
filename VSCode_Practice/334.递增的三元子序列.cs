/*
 * @lc app=leetcode.cn id=334 lang=csharp
 *
 * [334] 递增的三元子序列
 */

// @lc code=start
public class Solution334 {
    public void Test()
    {
        var nums = new int[]{1,1,-2,6};
        var ans = IncreasingTriplet(nums);
    }
    
    /// <summary>
    /// 贪心思路
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool IncreasingTriplet(int[] nums) 
    {
        var small = int.MaxValue;
        var mid = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= small)
            {
                small = nums[i];
                continue;
            }
            if (nums[i] <= mid)
            {
                mid = nums[i];
                continue;
            }
            if (nums[i] > mid)
            {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

