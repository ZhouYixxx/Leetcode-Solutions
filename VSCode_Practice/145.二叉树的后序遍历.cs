/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
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

public class Solution145 {
    public void Test()
    {
        var nodes = new int?[]{1,2,3,4,5,6};
        var root = DataStructureHelper.GenerateTreeFromArray(nodes);
        var ans = PostorderTraversal(root);
    }

    public IList<int> PostorderTraversal(TreeNode root) 
    {
        var res = new List<int>();
        var stack = new Stack<TreeNode>();
        TreeNode prev = null;
        while (root != null || stack.Count > 0)
        {
            if (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            else
            {
                root = stack.Peek();
                //没有右子树或者右子树已访问过，则可以写入列表
                if (root.right == null || root.right == prev)
                {
                    stack.Pop();
                    res.Add(root.val);
                    prev = root;
                    root = null;
                }
                else
                {
                    root = root.right;
                }
            }
        }
        return res;
    }
}
// @lc code=end

