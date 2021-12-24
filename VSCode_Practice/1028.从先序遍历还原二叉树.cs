/*
 * @lc app=leetcode.cn id=1028 lang=csharp
 *
 * [1028] 从先序遍历还原二叉树
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

public class Solution1028 {
    public void Test()
    {
        var trav = "1-2--3---4--5-6";
        var node1 = RecoverFromPreorder_Iterator(trav);
    }

    public TreeNode RecoverFromPreorder(string traversal) 
    {
        //生成二叉树节点的值列表和深度列表
        var values = new List<int>();
        var depths = new List<int>(){0};
        int value = 0;
        int depth = 0;
        for (int i = 0; i < traversal.Length; i++)
        {
            if (traversal[i] == '-')
            {
                if (value != 0)
                {
                    values.Add(value);
                }
                value = 0;
                depth++;
            }
            else
            {
                if (depth != 0)
                {
                    depths.Add(depth);
                }
                depth = 0;
                var digit = (int)traversal[i] - 48;
                value = value * 10 + digit;
                if (i == traversal.Length-1)
                {
                    values.Add(value);
                }
            }
        }
        //递归生成二叉树
        var node = RecursiveHelper(values.ToArray(), depths.ToArray(), 0, 0, values.Count-1);
        return node;
    }

    public TreeNode RecursiveHelper(int[] values, int[] depths, int root_index, int child_start, int child_end)
    {
        if (root_index >= values.Length || child_start > child_end || child_start >= values.Length || child_end < 0)
        {
            return null;
        }
        if (child_start == child_end)
        {
            return new TreeNode(values[child_start]);
        }
        var val = values[root_index];
        var node = new TreeNode(val);
        var root_new = root_index+1;
        var end_node_new = root_new;
        while (end_node_new < values.Length)
        {
            if (end_node_new == values.Length-1 || depths[end_node_new+1] <= depths[root_new])
            {
                break;
            }
            else
            {
                end_node_new++;
            }
        }
        var left = RecursiveHelper(values, depths, root_new, root_new, end_node_new);
        var right = RecursiveHelper(values, depths, end_node_new+1, end_node_new+1, child_end);
        node.left = left;
        node.right = right;
        return node;
    }

    public TreeNode RecoverFromPreorder_Iterator(string traversal)
    {
        var stack = new Stack<TreeNode>();
        int i = 0;
        TreeNode root = null;
        while (i < traversal.Length)
        {
            int level = 0;
            int val = 0;
            while (i != 0 && traversal[i] == '-')
            {
                level++;
                i++;
            }
            while (i < traversal.Length && traversal[i] != '-')
            {
                var digit = (int)traversal[i] - 48;
                val = val*10 + digit;
                i++;
            }
            var curNode = new TreeNode(val);
            if (stack.Count == 0)
            {
                root = curNode;
                stack.Push(curNode);
                continue;
            }
            //栈中的元素深度逐渐增加
            if (level > stack.Count)
            {
                stack.Push(curNode);
            }
            while (level < stack.Count)
            {
                stack.Pop();
            }
            var dad = stack.Peek();
            if (dad.left == null)
            {
                dad.left = curNode;
            }
            else
            {
                dad.right = curNode;
            }
            stack.Push(curNode);
        }
        return root;;
    }
}
// @lc code=end

