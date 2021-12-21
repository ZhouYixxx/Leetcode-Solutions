/*
 * @lc app=leetcode.cn id=226 lang=csharp
 *
 * [226] 翻转二叉树
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
public class Solution226 {
    public void Test()
    {
        // var nums = new int?[]{5,4,8,11,null,13,4,7,2,null,null,null,1};
        // var root = DataStructureHelper.GenerateTreeFromArray(nums);
        // var node = InvertTree(root);
    }

    public TreeNode InvertTree(TreeNode root) 
    {
        if (root == null)
        {
            return null;
        }
        var left = InvertTree(root.left);
        var right = InvertTree(root.right);
        root.left = right;
        root.right = left;
        return root;
    }
}
// @lc code=end

