

public class Solution_Offer07_ii
{
    public void Test()
    {
        var nums = new int[] {0,0,1};
        var ans = ThreeSum(nums);
    }

    public IList<IList<int>> ThreeSum(int[] nums) {
        var lst = new List<IList<int>>();
        Array.Sort(nums);
        if (nums.Length < 3 || nums[0] > 0 || nums[nums.Length-1] < 0) 
        {
            return new List<IList<int>>();
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i-1])
            {
                continue;
            }
            if (nums[i] > 0)
            {
                break;
            }
            int j = i+1;
            int k = nums.Length - 1;
            while (j < k)
            {
                var sum = nums[i] + nums[j] + nums[k];
                if (sum == 0)
                {
                    lst.Add(new List<int>(){nums[i], nums[j], nums[k]});
                    j++;
                    k--;
                    //防止出现重复，例如数组为-1,0,1,1,1,1,1,1，确保只有第一个1有效
                    while (j < nums.Length && nums[j] == nums[j-1])
                    {
                        j++;
                    }
                    while (k >= 0 && nums[k] == nums[k+1])
                    {
                        k--;
                    } 
                    continue;
                }
                if (sum > 0)
                {
                    k--;
                    continue;
                }
                if (sum < 0)
                {
                    j++;
                    continue;
                }
            }
        }
        return lst;
    }
}