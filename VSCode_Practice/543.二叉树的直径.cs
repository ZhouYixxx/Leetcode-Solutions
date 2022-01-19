/*
 * @lc app=leetcode.cn id=543 lang=csharp
 *
 * [543] 二叉树的直径
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
 using System;
public class Solution543 {
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        var depth = DFS(root);
        return max;
    }

    private int max = 0;
    private int DFS(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        var l = DFS(node.left);
        var r = DFS(node.right);
        max = Math.Max(l+r, max);
        return Math.Max(l,r)+1;
    }
}
// @lc code=end

