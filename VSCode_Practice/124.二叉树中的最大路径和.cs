/*
 * @lc app=leetcode.cn id=124 lang=csharp
 *
 * [124] 二叉树中的最大路径和
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
public class Solution124 {
    public void Test()
    {
        // var nums = new int?[]{1,-2,-3,1,3,-2,null,-1};
        // var root = DataStructureHelper.GenerateTreeFromArray(nums);
        // var ans = MaxPathSum(root);
    }

    private int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root) 
    {
        var res = DFS(root);
        return maxSum;
    }

    /// <summary>
    /// 某个子树最大路径和（必须过子树根节点）
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private int DFS(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        var left = DFS(node.left);
        var right = DFS(node.right);
        //当前节点为n,对于当前节点来说，最大值可以为n+left,n+right,n,n+left+right
        //但是不能返回第四种情况，因为不能同时两边跑
        var outMaxSum = Math.Max( Math.Max(left, right), 0) + node.val;
        maxSum = Math.Max(maxSum, outMaxSum);
        var innerMaxSum = Math.Max(outMaxSum, node.val + left + right);
        maxSum = Math.Max(maxSum, innerMaxSum);
        return outMaxSum;
    }
}
// @lc code=end

