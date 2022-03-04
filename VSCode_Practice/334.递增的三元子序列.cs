/*
 * @lc app=leetcode.cn id=334 lang=csharp
 *
 * [334] 递增的三元子序列
 */

// @lc code=start
public class Solution334 {
    public void Test()
    {
        var nums = new int[]{2,1,5,0,4,6};
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

    /// <summary>
    /// 20220225
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool IncreasingTriplet1(int[] nums) {
        var small = int.MaxValue;
        var mid = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (small >= nums[i])
            {
                small = nums[i];
                continue;
            }
            if (mid >= nums[i])
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

