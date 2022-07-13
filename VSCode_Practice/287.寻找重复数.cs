/*
 * @lc app=leetcode.cn id=287 lang=csharp
 *
 * [287] 寻找重复数
 */

// @lc code=start
public class Solution287 {
    public void Test()
    {
        var nums = new int[]{3,1,3,4,2};
        var ans = FindDuplicate(nums);
    }

    public int FindDuplicate(int[] nums) {
        var slow = 0;
        var fast = 0;
        slow = nums[0];
        fast = nums[nums[0]];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        int pre1 = 0;
        int pre2 = slow;
        while (pre1 != pre2)
        {
            pre1 = nums[pre1];
            pre2 = nums[pre2];
        }
        return pre1;
    }
}
// @lc code=end

