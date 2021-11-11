/*
 * @lc app=leetcode.cn id=283 lang=csharp
 *
 * [283] 移动零
 */

// @lc code=start
public class Solution283 {
    public void Test()
    {
        var nums = new int[]{1};
        MoveZeroes(nums);
    }

    public void MoveZeroes(int[] nums) 
    {
        var index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }
            nums[index++] = nums[i];
        }
        for (int i = index; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}
// @lc code=end

