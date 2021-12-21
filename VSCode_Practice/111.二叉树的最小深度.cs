/*
 * @lc app=leetcode.cn id=111 lang=csharp
 *
 * [111] 二叉树的最小深度
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
public class Solution111 {
    public int MinDepth(TreeNode root) 
    {
        return DFS(root);
    }

    private int DFS(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        if (node.left == null && node.right == null)
        {
            return 1;
        }
        if (node.left == null)
        {
            return DFS(node.right)+1;
        }
        if (node.right == null)
        {
            return DFS(node.left)+1; 
        }
        var l = DFS(node.left);
        var r = DFS(node.right);
        return l > r ? r+1 : l+1;
    }
}
// @lc code=end

