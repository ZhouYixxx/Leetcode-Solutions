/*
 * @lc app=leetcode.cn id=104 lang=csharp
 *
 * [104] 二叉树的最大深度
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
public class Solution104 {
    public int MaxDepth(TreeNode root) 
    {
        var depth = DFS(root);
        return depth;
    }

    private int DFS(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        var l = DFS(node.left);
        var r = DFS(node.right);
        return l > r ? l+1 : r+1;
    }
}
// @lc code=end

