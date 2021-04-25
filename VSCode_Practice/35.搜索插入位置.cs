/*
 * @lc app=leetcode.cn id=35 lang=csharp
 *
 * [35] 搜索插入位置
 */

// @lc code=start
public class Solution35 {
    public void Test()
    {
        var nums = new int[]{3};
        var target = 1;
        var ans = SearchInsert(nums, target);
    }

    public int SearchInsert(int[] nums, int target) 
    {
        var l = 0;
        var r = nums.Length-1;
        while (l <= r)
        {
            var mid = l +(r-l)/2;
            if (nums[mid] > target)
            {
                r = mid-1;
            }
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] < target)
            {
                l = mid+1;
            }
        }
        return l; 
    }
}
// @lc code=end

