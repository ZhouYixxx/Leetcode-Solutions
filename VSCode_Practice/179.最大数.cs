/*
 * @lc app=leetcode.cn id=179 lang=csharp
 *
 * [179] 最大数
 */

// @lc code=start
using System.Text;

public class Solution179 {
    public void Test(){
        var nums = new int[]{3,30,34,5,9};
        var ans = LargestNumber(nums);
    }

    public string LargestNumber(int[] nums) {
        var ss = new string[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            ss[i] = "" + nums[i];
        }
        Array.Sort(ss, (a, b) =>{
            string sa = a + b, sb = b + a;
            return sb.CompareTo(sa);
        });
        StringBuilder sb = new StringBuilder();
        foreach (string s in ss) 
            sb.Append(s);
        int len = sb.Length;
        int k = 0;
        while (k < len-1 && sb[k] == '0') 
            k++;
        return sb.ToString(k,len-k);
    }
}
// @lc code=end

