using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class PostorderTraversal_145 : LeetCodeBase
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            //return Postorder_Iterative(root);

            var array = new List<int>();
            Postorder_Recursive(root, array);
            return array;
        }

        /// <summary>
        /// 后序遍历（递归）
        /// </summary>
        /// <param name="root"></param>
        /// <param name="array"></param>
        private void Postorder_Recursive(TreeNode root, IList<int> array)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    Postorder_Recursive(root.left, array);
                }
                if (root.right != null)
                {
                    Postorder_Recursive(root.right, array);
                }
                array.Add(root.val);
            }
        }

        /// <summary>
        /// 后序遍历（迭代）
        /// </summary>n
        /// <param name="root"></param>
        private List<int> Postorder_Iterative(TreeNode root)
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
            var array = PostorderTraversal(root);
            foreach (var val in array)
            {
                Console.Write($"{val},  ");
            }
            Console.ReadKey();
        }

        public PostorderTraversal_145() : base("PostorderTraversal_145")
        {
            Test();
        }
    }
}