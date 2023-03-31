/*
 * @lc app=leetcode.cn id=128 lang=csharp
 *
 * [128] 最长连续序列
 */

// @lc code=start
public class Solution128 {
    public void Test(){
        var nums = new int[]{100,4,200,1,3,2};
        var ans = LongestConsecutive(nums);
    }

    public int LongestConsecutive(int[] nums) {
        return LongestConsecutive_2(nums);
    }

    /// <summary>
    /// 哈希set
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    private int LongestConsecutive_1(int[] nums){
        if (nums.Length <= 1)
        {
            return nums.Length;
        }
        int ans = 0;
        var hashSet = new HashSet<int>();
        foreach (var num in nums)
        {
            hashSet.Add(num);
        }
        foreach (var x in hashSet)
        {
            //如果能够以x-1为起点，那么一定不会用x为起点
            if (hashSet.Contains(x-1))
            {
                continue;
            }
            int y = x;
            while (hashSet.Contains(y+1))
            {
                y++;
            }
            ans = Math.Max(ans, y-x+1);
        }
        return ans;
    }

    /// <summary>
    /// 哈希set优化
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    private int LongestConsecutive_2(int[] nums){
        if (nums.Length <= 1)
        {
            return nums.Length;
        }
        int ans = 0;
        //key：当前数，value：当前数能到达的最右边界
        var dic = new Dictionary<int,int>();
        foreach (var num in nums)
        {
            dic[num] = num;
        }
        foreach (var num in nums)
        {
            if (dic.ContainsKey(num-1))
            {
                continue;
            }
            var right = dic[num];
            //与方法1相比的主要优化代码
            while (dic.ContainsKey(right+1))
            {
                right = dic[right+1];
            }
            dic[num] = right;
            ans = Math.Max(ans, right - num + 1);
        }
        return ans;
    }
}
// @lc code=end

