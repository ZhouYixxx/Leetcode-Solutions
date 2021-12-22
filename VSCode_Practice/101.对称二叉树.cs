/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
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

public class Solution101 {
    public void Test()
    {
        var nums = new int?[]{1,2,2,null,3,null,3};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = IsSymmetric(root);
    }

    public bool IsSymmetric(TreeNode root) 
    {
        //递归
        // if (root == null)
        // {
        //     return false;
        // }
        // return IsSymmetric_Recur(root.left, root.right);
        
        //迭代
        return IsSymmetric_Iter(root);
    }

    /// <summary>
    /// 迭代写法（层序遍历）
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    private bool IsSymmetric_Iter(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);
        var list = new List<TreeNode>(); 
        while (queue.Count > 0)
        {
            var node1 = queue.Dequeue();
            var node2 = queue.Dequeue();
            if (node1 == null && node2 == null)
            {
                continue;
            }
            if (node1 == null || node2 == null || node1.val != node2.val)
            {
                return false;
            }
            queue.Enqueue(node1.left);
            queue.Enqueue(node2.right);

            queue.Enqueue(node1.right);
            queue.Enqueue(node2.left);
        }
        return true;
    } 

    /// <summary>
    /// 递归写法
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    private bool IsSymmetric_Recur(TreeNode node1, TreeNode node2)
    {
        if (node1 == null && node2 == null)
        {
            return true;
        }
        if (node1 == null || node2 == null)
        {
            return false;
        }
        if (node1.val != node2.val)
        {
            return false;
        }
        return IsSymmetric_Recur(node1.left, node2.right) && IsSymmetric_Recur(node1.right, node2.left);
    } 
}
// @lc code=end

