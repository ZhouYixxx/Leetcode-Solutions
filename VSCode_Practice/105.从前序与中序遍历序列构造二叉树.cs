/*
 * @lc app=leetcode.cn id=105 lang=csharp
 *
 * [105] 从前序与中序遍历序列构造二叉树
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

public class Solution105 {
    public void Test()
    {
        var preorder = new int[]{4,1,3,6,2,5};
        var inorder = new int[]{1,3,6,4,5,2};
        var root = BuildTree(preorder, inorder);
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder) 
    {
        var indexDic = new Dictionary<int,int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            indexDic[inorder[i]] = i;
        }
        var root = BuildTreeHelper(preorder, 0, inorder, indexDic, 0, 0, inorder.Length-1);
        return root;
    }

    public TreeNode BuildTreeHelper(int[] preorder,int pre_root, int[] inorder, Dictionary<int,int> indexDic, 
            int in_root, int in_left, int in_right)
    {
        if (in_left >= inorder.Length || in_left < 0 || in_right >= inorder.Length || in_right < 0 
                || in_left > in_right)
        {
            return null;
        }
        if (in_left == in_right)
        {
            return new TreeNode(inorder[in_left]);
        }
        var val = preorder[pre_root];
        var newNode = new TreeNode(val);
       //寻找根节点在中序表中的位置，可以用哈希表优化速度

        var in_root_new = indexDic[val];
        // var in_root_new = 0;
        // while (in_root_new < inorder.Length)
        // {
        //     if (inorder[in_root_new] == val)
        //     {
        //         break;
        //     }
        //     in_root_new++;
        // }
        var left = BuildTreeHelper(preorder, pre_root+1, inorder, indexDic, in_root_new, in_left, in_root_new-1);
        var count = in_root_new-in_left+1;
        var right = BuildTreeHelper(preorder, pre_root+count, inorder, indexDic, in_root_new, in_root_new+1, in_right);
        newNode.left = left;
        newNode.right = right;
        return newNode;
    }
}
// @lc code=end

