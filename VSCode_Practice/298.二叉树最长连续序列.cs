using System.Collections.Generic;
using System;

public class Solution298
{
    public void Test()
    {
        var nums = new int?[]{2,null,3,2,null,1};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = LongestConsecutive(root);
    }

    private int maxLength = 1;

    public int LongestConsecutive(TreeNode root) 
    {
        DFS(root);
        return maxLength;
    }

    /// <summary>
    /// 函数含义：以根节点为起点的最长连续序列的长度
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private int DFS(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        var left = DFS(node.left)+1;
        var right = DFS(node.right)+1;
        if (node.left != null && node.left.val != node.val + 1)
        {
            left = 1;
        }
        if (node.right != null && node.right.val != node.val + 1)
        {
            right = 1;
        }
        var length = Math.Max(left, right);
        maxLength = Math.Max(maxLength ,length);
        return length;
    }
}