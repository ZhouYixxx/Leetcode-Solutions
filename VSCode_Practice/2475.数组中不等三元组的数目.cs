/*
 * @lc app=leetcode.cn id=2475 lang=csharp
 *
 * [2475] 数组中不等三元组的数目
 */

// @lc code=start
public class Solution2475 {
    public void Test()
    {
        var nums = new int[]{1,3,4,2,1,2,1,4,5};
        var ans = UnequalTriplets(nums);
    }

    public int UnequalTriplets(int[] nums) {
        var countDic = new Dictionary<int,int>();
        foreach (var num in nums)
        {
            if (!countDic.ContainsKey(num))
            {
                countDic.Add(num,0);
            }
            countDic[num] = countDic[num] + 1;
        }
        if (countDic.Count < 3)
        {
            return 0;
        }
        int visited = 0, cur = 0, total = 0;
        foreach (var key in countDic.Keys)
        {
            cur = countDic[key];
            total += visited * cur * (nums.Length - visited - cur);
            visited += cur;
        }
        return total;
    }
}
// @lc code=end

