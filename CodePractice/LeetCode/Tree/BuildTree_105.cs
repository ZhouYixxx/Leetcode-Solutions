using System;
using System.Collections.Generic;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class BuildTree_105 : LeetCodeBase
    {
        public BuildTree_105() : base("BuildTree_105")
        {
            var inorder = new int[] { 9, 3, 15, 20, 7 };
            var preorder = new int[] { 3, 9, 20, 15, 7 };
            var root = BuildTree(preorder, inorder);
            TreeNodeHelper.ShowBinaryTree(root);
            Console.ReadKey();
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                dic.Add(inorder[i], i);
            }
            var root = Build(preorder, inorder, dic, 0, inorder.Length - 1, 0, preorder.Length - 1);
            return root;
        }

        private TreeNode Build(int[] preorder, int[] inorder, Dictionary<int, int> dic,
            int in_left, int in_right, int pre_left, int pre_right)
        {
            if (in_left > in_right || pre_left > pre_right)
                return null;
            var pre_root = pre_left;
            var node = new TreeNode(preorder[pre_root]);
            var in_root = dic[preorder[pre_root]];
            var leftNum = in_root - in_left;
            node.left = Build(preorder, inorder, dic,
                in_left, in_root - 1, pre_left + 1, pre_left + leftNum );
            node.right = Build(preorder, inorder, dic,
                in_root + 1, in_right, pre_left + leftNum+1, pre_right);
            return node;
        }
    }
}