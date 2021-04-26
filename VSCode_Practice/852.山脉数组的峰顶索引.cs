/*
 * @lc app=leetcode.cn id=852 lang=csharp
 *
 * [852] 山脉数组的峰顶索引
 */

// @lc code=start
public class Solution852 {
    public void Test()
    {
        //var nums = new int[]{1,2,3,4,5,6,7,8,9,1,0};
        //var nums = new int[]{4,6,8,7,6,5,4,3,2,1,0};
        var nums = new int[]{24,69,100,99,79,78,67,36,26,19};
        var ans = PeakIndexInMountainArray(nums);
    }

    public int PeakIndexInMountainArray(int[] arr) 
    {
        var l = 0;
        var r = arr.Length;
        while (l < r)
        {
            var mid = l + (r-l+1)/2;
            if (arr[mid] > arr[mid-1])
            {
                l = mid;
            }
            else
            {
                r = mid-1;
            }
        }
        return l;
    }
}
// @lc code=end

