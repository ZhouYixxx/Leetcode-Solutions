/*
 * @lc app=leetcode.cn id=977 lang=csharp
 *
 * [977] 有序数组的平方
 */

// @lc code=start
public class Solution977 {
    public void Test()
    {
        var nums = new int[]{0,1,2,2,6,8};
        var ans = SortedSquares(nums);
    }

    public int[] SortedSquares(int[] nums) 
    {
        int l = 0, r = nums.Length-1;
        var index = nums.Length-1;
        var squareNums = new int[nums.Length];
        while (index >= 0)
        {
            var squareLeft = nums[l]*nums[l];
            var squareRight = nums[r]*nums[r];
            if (squareLeft == squareRight)
            {
                l++;
                r--;
                squareNums[index--] = squareLeft;
                if (index < 0)
                    break;
                squareNums[index--] = squareRight; 
            }
            else if (squareLeft < squareRight)
            {
                r--;
                squareNums[index--] = squareRight;
            }
            else
            {
                l++;
                squareNums[index--] = squareLeft;
            }
        }
        return squareNums;
    }
}
// @lc code=end

