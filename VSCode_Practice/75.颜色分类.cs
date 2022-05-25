/*
 * @lc app=leetcode.cn id=75 lang=csharp
 *
 * [75] 颜色分类
 */

// @lc code=start
public class Solution75 {
    public void Test()
    {
        var nums = new int[]{2,0,1,2,1,0,0,1};
        SortColors(nums);
    }

    public void SortColors(int[] nums) {
        var idx = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                Swap(nums,i, idx++);
            }
        }
        for (int i = idx; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                Swap(nums,i, idx++);
            }
        }
    }

    private void Swap(int[] nums,int idx1, int idx2)
    {
        if (idx1 == idx2)
        {
            return;
        }
        var temp = nums[idx1];
        nums[idx1] = nums[idx2];
        nums[idx2] = temp;
    }
}
// @lc code=end

