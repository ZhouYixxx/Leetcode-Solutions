//https://leetcode.cn/problems/A1NYOS/

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution_Offer11
{
    public void Test()
    {
        var nums = new int[] { 0,1,0,0,0,1,1,1,1,0,0};
        var ans = FindMaxLength(nums);
    }

    public int FindMaxLength(int[] nums) {
        int ans = 0;
        int sum = 0;
        //字典记录每个前缀和的首次出现的下标，key = 前缀和，value = 首次出现的下标
        //例如map[4] = 3,说明当数组[0,3]区间内，前缀和为4
        //如果后续发现map[4] = 7,说明当数组[0,7]区间内，前缀和为4，故而[3,7]区间中0和1数量相等
        var map = new Dictionary<int,int>();
        map.Add(0, -1);
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i] == 1 ? 1 : -1;//0看成-1方便计算
            sum += num;
            //之前已经出现过该前缀和
            if (map.ContainsKey(sum))
            {
                var len =  i - map[sum];
                ans = Math.Max(ans, len);
            }
            else
            {
                map.Add(sum, i);
            }
        }
        return ans;
    }
}