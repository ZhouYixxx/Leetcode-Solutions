/*
 * @lc app=leetcode.cn id=110 lang=csharp
 *
 * [110] 平衡二叉树
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
public class Solution110 {
    public void Test()
    {
        var s = "[3,9,20,null,null,15,7]";
        var nums = DataStructureHelper.ConvertStringToNullableNumArray(s);
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = IsBalanced(root);
    }

    bool isBalanced = true;
    public bool IsBalanced(TreeNode root) {
        var height = GetHeight(root);
        return isBalanced;
    }

    private int GetHeight(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        var leftH = GetHeight(root.left);
        var rightH = GetHeight(root.right);
        if (Math.Abs(leftH - rightH) > 1)
        {
            isBalanced = false;
        }
        return Math.Max(leftH, rightH)+1;
    }
}
// @lc code=end

