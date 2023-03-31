/*
 * @lc app=leetcode.cn id=16 lang=csharp
 *
 * [16] 最接近的三数之和
 */

// @lc code=start
public class Solution16 {
    public void Test(){
        var nums = new int[]{-1,2,1,-4};
        var target = 1;
        var ans = ThreeSumClosest(nums, target);
    }


    public int ThreeSumClosest(int[] nums, int target) {
        int closest = 0;
        int interval = int.MaxValue;
        Array.Sort(nums);
        //固定一个索引i，然后双指针
        for (int i = 0; i < nums.Length; i++)
        {
            var a = nums[i];
            var l = i+1;
            var r = nums.Length-1;
            while (l < r)
            {
                var b = nums[l];
                var c = nums[r];
                var sum = a + b + c;
                if (sum == target)
                {
                    return sum;
                }
                var temp_interval = Math.Abs(sum-target);
                if (interval > temp_interval)
                {
                    closest = sum;
                    interval = temp_interval;
                }
                if (sum > target)
                {
                    r--;
                }
                else
                {
                    l++;
                }
            }
        }
        return closest;
    }
}
// @lc code=end

