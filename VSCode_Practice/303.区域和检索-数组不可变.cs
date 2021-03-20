using System;

public class NumArray {
    
    private int[] array = null;
    private int[] preSum = null;

    public NumArray(int[] nums) {
        array = nums;
        preSum = new int[nums.Length+1];
        preSum[0] = 0;
        for (int i = 0; i < preSum.Length-1; i++)
        {
            preSum[i+1] = preSum[i] + nums[i]; 
        }
    }
    
    public int SumRange(int i, int j) {
        return preSum[j+1] - preSum[i];
    }
}