using System.Text;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    public class ContainsDuplicate_217 : LeetCodeBase
    {
        public ContainsDuplicate_217() : base("ContainsDuplicate_217")
        {
            var nums = new int[] { 1, 2, 6, 3 };
            var contains = ContainsDuplicate(nums);
        }

        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length <= 1)
                return false;
            var a = nums[0] ^ nums[2];
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                res ^= nums[i];
            }
            return res == 0 ? true : false;
        }
    }
}