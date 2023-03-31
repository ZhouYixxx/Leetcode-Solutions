/*
 * @lc app=leetcode.cn id=260 lang=csharp
 *
 * [260] 只出现一次的数字 III
 */

// @lc code=start
public class Solution260 {
    public void Test()
    {
        var nums = new int[]{1,2,1,3,2,5};
        var ans = SingleNumber(nums);
    }

    public int[] SingleNumber(int[] nums) {
        var sum = 0;
        foreach (var num in nums)
        {
            sum = sum ^ num;
        }
        //找到sum二进制表示下的最低位的1，如sum = 1100，将得到100,根据异或的性质，这说明x1、x2在最低位的1的位置处一定是一个为0，一个为1，可以利用该性质进行区分
        var mark = sum & (-sum);
        int x1 = 0, x2 = 0;
        foreach (var num in nums)
        {
            if ((num & mark) == 0)
            {
                x1 = x1 ^ num;
            }
            else
            {
                x2 = x2 ^ num;
            }
        }
        var ans = new int[2]{x1,x2};
        return ans;
    }
}
// @lc code=end

