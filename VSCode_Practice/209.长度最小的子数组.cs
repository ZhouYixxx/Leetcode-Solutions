/*
 * @lc app=leetcode.cn id=209 lang=csharp
 *
 * [209] 长度最小的子数组
 */

// @lc code=start
public class Solution209 {
    public void Test()
    {
        var nums = new int[]{2,3,1,2,4,3};
        var target = 7;
        var ans = MinSubArrayLen(target, nums);
    }

    public int MinSubArrayLen(int target, int[] nums) {
        int ans = int.MaxValue;
        int start = 0, end = 0;
        var sum = 0;
        //滑动窗口，记录[start，end]区间内所有数字的和sum
        while (end < nums.Length)
        {
            sum += nums[end];
            while (sum >= target)
            {
                ans = Math.Min(ans, end-start+1);
                sum -= nums[start];
                start++;
            }
            end++;
        }
        return ans == int.MaxValue ? 0 : ans;
    }
}
// @lc code=end

