/*
 * @lc app=leetcode.cn id=496 lang=csharp
 *
 * [496] 下一个更大元素 I
 */

// @lc code=start
public class Solution496 {
    public void Test()
    {
        var nums1 = new int[]{4,1,2};
        var nums2 = new int[]{1,3,4,2};
        var ans = NextGreaterElement(nums1, nums2);
    }

    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var stack = new Stack<int>();
        var dic = new Dictionary<int,int>();//key=当前值，value = 下一个更大的值
        for (int i = nums2.Length-1; i >=0; i--)
        {
            while (stack.Count > 0 && stack.Peek() <= nums2[i])
            {
                stack.Pop();
            }
            dic.Add(nums2[i], stack.Count == 0 ? -1 : stack.Peek());
            stack.Push(nums2[i]);
        }
        var res = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            res[i] = dic[nums1[i]];
        }
        return res;
    }
}
// @lc code=end

