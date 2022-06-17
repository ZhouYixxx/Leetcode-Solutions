/*
 * @lc app=leetcode.cn id=137 lang=csharp
 *
 * [137] 只出现一次的数字 II
 */

// @lc code=start
public class Solution137 {
    public void Test()
    {
        var nums = new int[]{3,4,3,4,3,4,99};
        var ans = SingleNumber(nums);
    }
    
    public int SingleNumber(int[] nums) {
        var ans = 0;
        var cnt = new int[32];
        foreach (var num in nums)
        {
            for (int i = 0; i < 32; i++)
            {
                int digit = (num >> i) & 1;
                cnt[i] += digit;
            }
        }
        for (int i = 0; i < cnt.Length; i++)
        {
            cnt[i] = cnt[i] % 3;
            ans += (cnt[i] << i);
        }
        return ans;
    }
}
// @lc code=end

