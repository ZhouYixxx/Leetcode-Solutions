using System;

public class Solution169 {
    public int MajorityElement(int[] nums) 
    {
        var major = nums[0];
        var vote = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            vote += nums[i] == major ? 1 : -1;
            if (vote < 0)
            {
                major = nums[i];
                vote = 1;
            }
        }
        return major;
    }

    /// <summary>
    /// 20220222
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MajorityElement1(int[] nums){
        var majorElement = nums[0];
        var count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (majorElement != nums[i])
            {
                count--;
            }
            else
            {
                count++;
            }
            if (count < 0)
            {
                majorElement = nums[i];
                count = 1;
            }
        }
        return majorElement;
    }
}