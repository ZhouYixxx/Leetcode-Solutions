/*
 * @lc app=leetcode.cn id=27 lang=csharp
 *
 * [27] 移除元素
 */

// @lc code=start
public class Solution27 {
    public void Test(){
        var nums = new int[]{0,1,2,2,3,0,4,2};
        var val = 2;
        var ans = RemoveElement(nums, val);
    }

    public int RemoveElement(int[] nums, int val) {
        int slowIndex = nums.Length-1;
        int fastIndex = nums.Length-1;
        //快慢指针
        while (fastIndex >= 0)
        {
            if (nums[fastIndex] == val)
            {
                Swap(nums, fastIndex, slowIndex);
                slowIndex--;
            }
            fastIndex--;
        }
        return slowIndex+1;
    }

    private void Swap(int[] nums, int i, int j)
    {
        if (i == j)
        {
            return;
        }
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
// @lc code=end

