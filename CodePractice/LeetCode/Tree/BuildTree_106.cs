using System;
using System.Collections.Generic;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class BuildTree_106 : LeetCodeBase
    {
        public BuildTree_106() : base("BuildTree_106")
        {
            var inorder = new int[] { 1 };
            var postorder = new int[] { 1 };
            var root = BuildTree(inorder, postorder);
            TreeNodeHelper.ShowBinaryTree(root);
            Console.ReadKey();
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0)
            {
                return null;
            }
            var dic = new Dictionary<int,int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                dic.Add(inorder[i], i);
            }
            TreeNode root = BuildTreeRecursively(inorder, postorder, dic, 
                0, inorder.Length-1, 0, postorder.Length-1);
            return root;
        }

        private TreeNode BuildTreeRecursively(int[] inorder, int[] postorder, Dictionary<int,int> dic,
            int in_left, int in_right, int post_left,int post_right)
        {
            if (in_left > in_right || post_left > post_right)
            {
                return null;
            }
            var post_root = post_right;
            var node = new TreeNode(postorder[post_root]);
            var in_root = dic[postorder[post_root]];
            var leftNum = in_root - in_left;
            node.left = BuildTreeRecursively(inorder, postorder, dic, 
                in_left, in_root - 1, post_left, post_left+leftNum-1);
            node.right = BuildTreeRecursively(inorder, postorder, dic, 
                in_root + 1, in_right, post_left + leftNum, post_right-1);
            return node;
        }
    }
}