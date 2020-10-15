using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Tree;

namespace CodePractice.LeetCode.Tree
{
    public class PreorderTraversal_144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            return Preorder_Iterative(root);

            var array = new List<int>();
            Preorder_Recursive(root, array);
            return array;
        }

        /// <summary>
        /// 前序遍历（递归）
        /// </summary>
        /// <param name="root"></param>
        /// <param name="array"></param>
        private void Preorder_Recursive(TreeNode root, IList<int> array)
        {
            if (root == null)
            {
                return;
            }
            array.Add(root.val);
            if (root.left != null)
            {
                Preorder_Recursive(root.left, array);
            }
            if (root.right != null)
            {
                Preorder_Recursive(root.right, array);
            }
        }

        /// <summary>
        /// 前序遍历（迭代）
        /// </summary>n
        /// <param name="root"></param>
        private List<int> Preorder_Iterative(TreeNode root)
        {
            var array = new List<int>();
            var stack = new Stack<TreeNode>();
            var currentNode = root;
            while (currentNode != null || stack.Any())
            {
                while (currentNode != null)
                {
                    array.Add(currentNode.val);
                    if (currentNode.right != null)
                    {
                        stack.Push(currentNode.right);
                    }
                    currentNode = currentNode.left;
                }

                if (stack.Any())
                {
                    currentNode = stack.Pop();
                }
            }
            return array;
        }

        public void Test()
        {
            var root = new TreeNode(5);
            var left1 = new TreeNode(3);
            root.left = left1;
            var right1 = new TreeNode(7);
            root.right = right1;
            left1.left = new TreeNode(1);
            left1.right = new TreeNode(4);
            right1.left = new TreeNode(6);
            right1.right = new TreeNode(8);

            left1.left.right = new TreeNode(2);
            var array = PreorderTraversal(root);
            foreach (var val in array)
            {
                Console.Write($"{val},  ");
            }
            Console.ReadKey();
        }
    }
}