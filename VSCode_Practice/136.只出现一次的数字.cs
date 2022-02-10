public class Solution136 {
    public int SingleNumber(int[] nums) 
    {
        int ret = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            ret = nums[i]^ret;
        }
        return ret;
    }
}