/*
 * @lc app=leetcode.cn id=189 lang=csharp
 *
 * [189] 旋转数组
 */

// @lc code=start
public class Solution189 {
    public void Test()
    {
        var nums = new int[]{1,2,3,4,5,6,7};
        var k = 7;
        Rotate(nums,k);
    }

    public void Rotate(int[] nums, int k) 
    {
        var n = nums.Length;
        k = k %  n;
        Reverse(nums, 0, n-1);
        Reverse(nums, 0, k-1);
        Reverse(nums, k, n-1);
    }

    private void Reverse(int[] nums, int start, int end)
    {
        var l = start;
        var r = end;
        while (l < r)
        {
            var temp = nums[l];
            nums[l++] = nums[r];
            nums[r--] = temp;
        }
    }
}
// @lc code=end

