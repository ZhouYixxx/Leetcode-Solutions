/*
 * @lc app=leetcode.cn id=238 lang=csharp
 *
 * [238] 除自身以外数组的乘积
 */

// @lc code=start
public class Solution238 {
    public void Test(){
        var nums = new int[]{1,2,3,4};
        var ans = ProductExceptSelf1(nums);
    }

    public int[] ProductExceptSelf1(int[] nums) {
        var ans = new int[nums.Length];
        var dp1 = new int[nums.Length];//正方向上当前索引前的所有数的乘积
        dp1[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            dp1[i] = dp1[i-1]*nums[i];
        }
        var dp2 = new int[nums.Length];//反方向上当前索引后的所有数的乘积
        dp2[nums.Length-1] = nums[nums.Length-1];
        for (int i = nums.Length-2; i >= 0; i--)
        {
            dp2[i] = dp2[i+1]*nums[i];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                ans[i] = dp2[i+1];
                continue;
            }
            if (i == nums.Length-1)
            {
                ans[i]=  dp1[i-1];
                continue;
            }
            ans[i] = dp1[i-1]*dp2[i+1];
        }
        return ans;
    }


    /// <summary>
    /// O(1)空间复杂度的做法
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] ProductExceptSelf(int[] nums) {
        var ans = new int[nums.Length];
        //利用ans来放置结果
        ans[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            ans[i] = ans[i-1]*nums[i-1];
        }
        var r = 1;
        for (int i = nums.Length-1; i >= 0; i--)
        {
            ans[i] = ans[i]*r;
            r = r*nums[i];
        }
        return ans;
    }
}
// @lc code=end

