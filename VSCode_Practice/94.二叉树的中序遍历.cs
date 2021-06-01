/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
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
public class Solution94 {
    public void Test()
    {
        var nodes = new int?[]{1,null,2,};
        var root = DataStructureHelper.GenerateTreeFromArray(nodes);
        var ans = InorderTraversal(root);
    }

    //前序中序后序统一的写法
    public IList<int> InorderTraversal(TreeNode root) 
    {
        if (root == null)
        {
            return new List<int>();
        }
        var res =  new List<int>(); 
        //字典保存每个树节点是否被访问过
        var visitedDic = new Dictionary<TreeNode, bool>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (!visitedDic.ContainsKey(node))
            {
                visitedDic.Add(node,true);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                stack.Push(node);
                if (node.left != null)
                {
                    stack.Push(node.left);
                }

            }
            else
            {
                //第二次访问才会添加到list中
                res.Add(node.val);
            }
        }
        return res;
    }
}
// @lc code=end

