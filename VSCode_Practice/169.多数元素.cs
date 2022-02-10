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
}