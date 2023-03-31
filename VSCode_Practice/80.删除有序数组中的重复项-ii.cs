/*
 * @lc app=leetcode.cn id=80 lang=csharp
 *
 * [80] 删除有序数组中的重复项 II
 */

// @lc code=start
public class Solution80 {
    public void Test(){
        var nums = new int[]{1,1,1,2,2,3};
        var ans = RemoveDuplicates(nums);
    }

    public int RemoveDuplicates(int[] nums) {
        var slow = 2;
        var fast = 2;
        if (nums.Length <= 2)
        {
            return nums.Length;
        }
        while (fast < nums.Length)
        {
            if (nums[slow-2] != nums[fast])
            {
                nums[slow] = nums[fast];
                slow++;
            }
            fast++;
        }
        return slow;
    }
}
// @lc code=end

