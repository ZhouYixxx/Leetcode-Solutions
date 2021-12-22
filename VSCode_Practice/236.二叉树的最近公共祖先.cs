/*
 * @lc app=leetcode.cn id=236 lang=csharp
 *
 * [236] 二叉树的最近公共祖先
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution236 {
    public void Test()
    {
        var root = DataStructureHelper.GenerateTreeFromArray(new int?[]{3,5,1,6,2,0,8,null,null,7,4});
        var p = root.GetNode(7);
        var q = root.GetNode(6);
        var ans = LowestCommonAncestor(root, p, q);
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        //理解递归函数的含义：给定一课树(root)，返回结果为一个节点，该节点是p或q的祖先。如果p/q都未找到祖先则返回null
        if (root == null || root == p || root == q)
        {
            return root;
        }
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if (left == null && right == null)
        {
            return null;
        }
        if (left != null && right != null)
        {
            return root;
        }
        return left == null ? right : left;
    }
}
// @lc code=end

