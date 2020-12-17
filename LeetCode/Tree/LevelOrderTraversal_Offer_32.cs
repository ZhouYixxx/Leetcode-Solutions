using System;
using System.Collections.Generic;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    /// <summary>
    /// 二叉树层序遍历（BFS）
    /// </summary>
    public class LevelOrderTraversal_Offer_32 : LeetCodeBase
    {
        public int[] LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new int[0];
            }
            var result = new List<int>();
            var quene = new Queue<TreeNode>();
            quene.Enqueue(root);
            while (quene.Count > 0)
            {
                var node = quene.Dequeue();
                result.Add(node.val);
                if (node.left != null)
                {
                    quene.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    quene.Enqueue(node.right);
                }
            }
            return result.ToArray();
        }

        public List<IList<int>> LevelOrder1(TreeNode root)
        {
            var list = new List<IList<int>>();
            if (root == null)
                return list;
            var node = root;
            var quene = new Queue<TreeNode>();
            quene.Enqueue(node);
            TreeNode last = root;
            TreeNode nextLevelLast = root;
            var levelList = new List<int>();
            while (quene.Count > 0)
            {
                node = quene.Dequeue();
                if (node.left != null)
                {
                    quene.Enqueue(node.left);
                    nextLevelLast = node.left;
                }
                if (node.right != null)
                {
                    quene.Enqueue(node.right);
                    nextLevelLast = node.right;
                }
                levelList.Add(node.val);
                if (node == last)
                {
                    var tempList = new List<int>(levelList);
                    list.Add(tempList);
                    levelList.Clear();
                    last = nextLevelLast;
                }
            }
            return list;
        }

        public void Test()
        {
            var nodeVals = "5, 3, 7, 1, 4, 6, 8,null, 2";
            var node = TreeNodeHelper.DeserializeBinaryTreeFromBFS(nodeVals);
            TreeNodeHelper.ShowBinaryTree(node);
            var array = LevelOrder1(node);
            foreach (var item in array)
            {
                Console.Write($"{item},");
            }
            Console.ReadKey();
        }

        public LevelOrderTraversal_Offer_32() : base("LevelOrderTraversal_Offer_32")
        {
            Test();
        }
    }
}