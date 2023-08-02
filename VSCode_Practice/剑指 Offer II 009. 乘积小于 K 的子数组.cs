
public class Solution_Offer09_ii
{
    public void Test(){
        var nums = new int[]{101};
        var nums2 = new int[]{2,3,4,5,6,7,100};
        int k = 100;
        var ans = NumSubarrayProductLessThanK(nums, k);
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        int l = 0, r = 0;
        int count = 0;
        int prod = 1;
        int prev_l = -1;
        int prev_r = -1;
        while (l <= r && r < nums.Length)
        {
            prod = prod * nums[r];
            if (r == nums.Length - 1)
            {
                //TODO
                if (prod < k)
                {
                    count += GetCount(l,r, prev_l, prev_r);
                }
                return count;
            }
            if (prod >= k)
            {
                r++;
                l = r;
                prod = 1;
                continue;
            }
            if (prod * nums[r+1] < k)
            {
                r++;
                continue;
            }
            else
            {
                count += GetCount(l,r, prev_l, prev_r);
                prev_l = l;
                prev_r = r;
                while (prod * nums[r+1] >= k && l <= r)
                {
                    prod = prod / nums[l++];
                }
                r++;
                if (l > r)
                {
                    r = l;
                }
            }
        }
        return count;
    }

    private int GetCount(int start, int end, int prev_start, int prev_end)
    {
        int len = end - start + 1;
        int count = (len+1) * len / 2;
        if (start <= prev_end)
        {
            int redunLength = prev_end - start + 1;
            int redun = redunLength * (redunLength+1) / 2;
            count -= redun;
        }
        return count;
    }
}