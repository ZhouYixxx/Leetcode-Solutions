/*
 * @lc app=leetcode.cn id=228 lang=csharp
 *
 * [228] 汇总区间
 */

// @lc code=start
public class Solution228 {
    public void Test(){
        var nums = new int[]{0,1,2,3,4,5};
        var ans = SummaryRanges(nums);
    }

    public IList<string> SummaryRanges(int[] nums) {
        var ans = new List<string>();
        int start = 0, end = 0;
        while (end < nums.Length)
        {
            while (end != nums.Length-1 && nums[end] == nums[end+1] - 1)
            {
                end++;
            }
            if (end == start)
            {
                ans.Add($"{nums[start]}");
            }
            else
            {
                ans.Add($"{nums[start]}->{nums[end]}");
            }
            start = end+1;
            end++;
        }
        return ans;
    }
}
// @lc code=end

