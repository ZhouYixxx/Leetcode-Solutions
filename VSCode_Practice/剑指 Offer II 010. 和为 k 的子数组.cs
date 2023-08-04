using System;
using System.Collections.Generic;
using System.Linq;

public class Solution_Offer10_ii
{
    public void Test()
    {
        var nums = new int[] { 0,1,2,3, -2, 4,0,1,-2};
        int k =  0;
        var ans = SubarraySum(nums, k);
    }

    /// <summary>
    /// 如果有负数则不能使用双指针法
    /// </summary>
    public int SubarraySum(int[] nums, int k) {
        int ans = 0;
        int sum = 0;
        //字典记录每个前缀和的出现次数，key = 前缀和，value = 数量
        var countMap = new Dictionary<int,int>();
        countMap.Add(0, 1);
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            int count = countMap.ContainsKey(sum - k) ? countMap[sum-k] : 0;
            if (count > 0)
            {
                ans += count;
            }
            if (!countMap.ContainsKey(sum))
            {
                countMap.Add(sum, 0);
            }
            countMap[sum] += 1;
        }
        return ans;
    }
}