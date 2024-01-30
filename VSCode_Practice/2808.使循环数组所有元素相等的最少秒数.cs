/*
 * @lc app=leetcode.cn id=2808 lang=csharp
 *
 * [2808] 使循环数组所有元素相等的最少秒数
 */

// @lc code=start
public class Solution2808 {
    public int MinimumSeconds(IList<int> nums) {
        int n = nums.Count;
        var dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Count; i++)
        {
            if (dic.TryGetValue(nums[i], out var lst))
                lst.Add(i);
            else
                dic.Add(nums[i], new List<int>(){i});
        }
        var ans = int.MaxValue;
        foreach (IList<int> positions in dic.Values) {
            int mx = positions[0] + n - positions[positions.Count - 1];
            for (int i = 1; i < positions.Count; ++i) {
                mx = Math.Max(mx, positions[i] - positions[i - 1]);
            }
            ans = Math.Min(ans, mx / 2);
        }
        return ans;
    }
}
// @lc code=end

