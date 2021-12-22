/*
 * @lc app=leetcode.cn id=106 lang=csharp
 *
 * [106] 从中序与后序遍历序列构造二叉树
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

public class Solution106 {
    public void Test()
    {
        var postorder = new int[]{3,2,1,4};
        var inorder = new int[]{4,3,2,1};
        var root = BuildTree(inorder, postorder);
    }

    public TreeNode BuildTree(int[] inorder, int[] postorder) 
    {
        var dic = new Dictionary<int,int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            dic[inorder[i]] = i;
        }
        var root = BuildTreeHelper(inorder, postorder, dic, postorder.Length-1, 0, 0, inorder.Length-1);
        return root;
    }

    private TreeNode BuildTreeHelper(int[] inorder, int[] postorder, Dictionary<int,int> memoDic,
            int post_root, int in_root, int in_left, int in_right)
    {
        if (in_left >= inorder.Length || in_left < 0 || in_right < 0 || in_right >= inorder.Length 
            || in_left > in_right)
        {
            return null;
        }
        if (in_left == in_right)
        {
            return new TreeNode(inorder[in_left]);
        }
        var val = postorder[post_root];
        var node = new TreeNode(val);
        var in_root_new = memoDic[val];
        var right = BuildTreeHelper(inorder, postorder, memoDic, post_root-1,in_root_new,  in_root_new+1, in_right);
        var count = in_right - in_root_new +1;
        var left = BuildTreeHelper(inorder, postorder, memoDic, post_root-count,in_root_new,  in_left, in_root_new-1);
        node.left = left;
        node.right = right;
        return node;
    }
}
// @lc code=end

