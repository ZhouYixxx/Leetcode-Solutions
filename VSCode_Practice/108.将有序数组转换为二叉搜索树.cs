/*
 * @lc app=leetcode.cn id=108 lang=csharp
 *
 * [108] 将有序数组转换为二叉搜索树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution108 {
    public void Test()
    {
        var nums = new int[]{-10,-3,0,5,9};
        var node = SortedArrayToBST(nums);
    }

    public TreeNode SortedArrayToBST(int[] nums) {
        return DFS(nums, 0, nums.Length-1);
    }

    private TreeNode DFS(int[] nums, int start, int end)
    {
        if (start > end)
        {
            return null;
        }
        if (start == end)
        {
            return new TreeNode(nums[start]);
        }
        var mid = (start+end) / 2;
        var root = new TreeNode(nums[mid]);
        var left = DFS(nums, start, mid-1);
        var right = DFS(nums, mid+1, end);
        root.left = left;
        root.right = right;
        return root;
    }
}
// @lc code=end

