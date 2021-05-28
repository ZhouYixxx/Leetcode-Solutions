using System;
using System.Collections.Generic;

public static class DataStructureHelper
{
    #region 链表处理

    //从数组生成链表
    public static ListNode GenerateLinkedListFromArray(int[] nums)
    {
        var dummy = new ListNode();
        var cur = dummy;
        for (int i = 0; i < nums.Length; i++)
        {
            var node = new ListNode(nums[i]);
            cur.next = node;
            cur = cur.next;
        }
        return dummy.next;
    }

    //从链表生成数组
    public static int[] ToArray(this ListNode node)
    {
        var list = new List<int>();
        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }
        return list.ToArray();
    }

    #endregion

    #region 二叉树
    //从数组生成二叉树，数组应该是按二叉树的层依次写入的
    public static TreeNode GenerateTreeFromArray(int?[] nums)
    {
        if (nums.Length == 0 || nums[0] == null)
        {
            return null;
        }
        TreeNode root = null;
        for (int i = 0; i < nums.Length/2-1; i++)
        {
            if (nums[i] == null)
            {
                continue;
            }
            var parent = new TreeNode(nums[i].Value);
            if (i == 0)
            {
                root = parent;
            }
            if (nums[2*i+1] != null)
            {
                var left = new TreeNode(nums[2*i+1].Value);
                parent.left = left;
            }
            if (nums[2*i+2] != null)
            {
                var right = new TreeNode(nums[2*i+2].Value);
                parent.right = right;
            }
        }
        return root;
    }


    #endregion
}