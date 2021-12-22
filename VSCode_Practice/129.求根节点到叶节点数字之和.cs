/*
 * @lc app=leetcode.cn id=129 lang=csharp
 *
 * [129] 求根节点到叶节点数字之和
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

using System.Collections.Generic;

public class Solution129 {
    public void Test()
    {
        var nums = new int?[]{4,9,0,5,1};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = SumNumbers(root);
    }

    public int SumNumbers(TreeNode root) 
    {
        return DFS(root, 0);
    }

    private int DFS(TreeNode node,int sum)
    {
        if (node == null)
        {
            return 0;
        }
        if (node.left == null && node.right == null)
        {
            return sum*10 + node.val;
        }
        var leftSum = DFS(node.left, sum*10 + node.val);   
        var rightSum = DFS(node.right, sum*10 + node.val);
        return leftSum + rightSum;
    }
}
// @lc code=end

