/*
 * @lc app=leetcode.cn id=229 lang=csharp
 *
 * [229] 多数元素 II
 */

// @lc code=start
public class Solution229 {
    public void Test()
    {
        var nums = new int[]{1};
        var ans = MajorityElement(nums);
    }

    /// <summary>
    /// 摩尔投票法
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<int> MajorityElement(int[] nums) {
        int cand1 = nums[0], cand2 = nums[0];
        int count1 = 0, count2 = 0;
        //投票阶段
        foreach (var x in nums)
        {
            //为cand1投票
            if (x == cand1)
            {
                count1++;
                continue;
            }
            //为cand2投票
            if (x == cand2)
            {
                count2++;
                continue;
            }
            //为其他人投票，如果此时cand1计数为0，则更改cand1为当前x
            if (count1 == 0)
            {
                cand1 = x;
                count1++;
                continue;
            }
            //为其他人投票，如果此时cand2计数为0，则更改cand2为当前x
            if (count2 == 0)
            {
                cand2 = x;
                count2++;
                continue;
            }
            //为其他人投票，将cand1、cand2的计票数减1
            count1--;
            count2--;
        }
        //计票阶段
        count1 = 0;
        count2 = 0;
        foreach (var num in nums)
        {
            if (cand1 == num)
            {
                count1++;
            }
            else if (cand2 == num)
            {
                count2++;
            }
        }
        var ans = new List<int>();
        if (count1 > nums.Length/3)
        {
            ans.Add(cand1);
        }
        if (count2 > nums.Length/3)
        {
            ans.Add(cand2);
        }
        return ans;
    }
}
// @lc code=end

