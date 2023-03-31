/*
 * @lc app=leetcode.cn id=31 lang=csharp
 *
 * [31] 下一个排列
 */

// @lc code=start
public class Solution31 {
    public void Test(){
        var num = new int[]{1,4,4,4,4};
        NextPermutation(num);
    }

    public void NextPermutation(int[] nums) {
        int i = nums.Length-2;
        //寻找到nums[i] < nums[i+1]的数对
        while (i>=0 && nums[i] >= nums[i+1])
        {
            i--;
        }
        if (i < 0)
        {
            Reverse(nums, 0, nums.Length-1);
            return;
        }
        int k = nums.Length-1;
        //在(i, end]区间由右向左寻找比nums[i]大的数nums[k]
        while (k > i)
        {
            if (nums[k] > nums[i])
            {
                //交换i, k
                Swap(nums, i , k);
                //[i+1, end]区间逆序
                Reverse(nums,i+1, nums.Length-1);
                break;
            }
            k--;
        }

    }

    private void Swap(int[] nums, int i, int k)
    {
        var temp = nums[i];
        nums[i] = nums[k];
        nums[k] = temp;
    }

    private void Reverse(int[] nums, int i, int k)
    {
        int left = i, right = k;
        while (left < right)
        {
            Swap(nums, left++, right--);
        }
    }
}
// @lc code=end

