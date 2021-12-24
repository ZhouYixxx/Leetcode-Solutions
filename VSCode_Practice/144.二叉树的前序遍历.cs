/*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
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
 using System.Collections.Generic;
public class Solution144 {
    public void Test()
    {

    }

    public IList<int> PreorderTraversal(TreeNode root) 
    {
        var ans = new List<int>();
        RecursiveHelper(ans,root);
        return ans;
    }

    //递归写法
    private void RecursiveHelper(IList<int> list, TreeNode node)
    {
        if (node == null)
        {
            return;
        }
        list.Add(node.val);
        RecursiveHelper(list, node.left);
        RecursiveHelper(list, node.right);
    }

    //迭代写法
    private void IteratorHelper(IList<int> list, TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node.right != null)
            {
                stack.Push(node.right);
            }
            if (node.left != null)
            {
                stack.Push(node.left);
            }
            list.Add(node.val);
        }
    }

    //Definition for a binary tree node.
    // public class TreeNode 
    // {
    //     public int val;
    //     public TreeNode left;
    //     public TreeNode right;
    //     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
    //     {
    //       this.val = val;
    //       this.left = left;
    //       this.right = right;
    //     }
    // }
 
}
// @lc code=end

