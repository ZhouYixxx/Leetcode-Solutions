/*
 * @lc app=leetcode.cn id=112 lang=csharp
 *
 * [112] 路径总和
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
public class Solution112 {
    public void Test()
    {
        var nums = new int?[]{-2, null ,-3};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var targetSum = -5;
        var ans = HasPathSum(root, targetSum);
    }

    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        if (root == null)
        {
            return false;
        }
        var ans = DFS(root, 0, targetSum);
        return ans;
    }

    private bool DFS(TreeNode node, int sum, int targetSum)
    {
        if (node == null)
        {
            return sum == targetSum;
        }
        if (node.left == null)
        {
            return DFS(node.right, sum + node.val, targetSum);
        }
        if (node.right == null)
        {
            return DFS(node.left, sum + node.val, targetSum);
        }
        return DFS(node.left, sum + node.val, targetSum) || DFS(node.right, sum + node.val, targetSum);
    }
}
// @lc code=end

