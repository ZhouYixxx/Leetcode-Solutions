using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Tree;

namespace CodePractice.LeetCode.Tree
{
    public class InorderTraversal_94
    {
        public  IList<int> InorderTraversal(TreeNode root)
        {
            return Inorder_Iterative(root);

            var array = new List<int>();
            //Inorder_Recursive(root, array);
            //return array;
        }

        /// <summary>
        /// 中序遍历（递归）
        /// </summary>
        /// <param name="root"></param>
        /// <param name="array"></param>
        private void Inorder_Recursive(TreeNode root, IList<int> array)
        {
            if (root == null)
            {
                return;
            }
            if (root.left != null)
            {
                Inorder_Recursive(root.left, array);
            }
            array.Add(root.val);
            if (root.right != null)
            {
                Inorder_Recursive(root.right, array);
            }
        }

        /// <summary>
        /// 中序遍历（循环）
        /// </summary>n
        /// <param name="root"></param>
        private List<int> Inorder_Iterative(TreeNode root)
        {
            var array = new List<int>();
            var stack = new Stack<TreeNode>();
            var currentNode = root;
            while (currentNode != null || stack.Any())
            {
                //currentNode不为null就一直向左
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                //到达最左子节点
                currentNode = stack.Pop();
                array.Add(currentNode.val);
                currentNode = currentNode.right;
            }
            return array;
        }

        public void Test()
        {
            //var vals = new int?[] { 5,3,7,1,4,6,8,2};
            var node = TreeNodeHelper.DeserializeBinaryTreeFromDFS("1, null, 2, 3");
            var array = InorderTraversal(node);
            foreach (var val in array)
            {
                Console.Write($"{val},  ");
            }
            Console.ReadKey();
        }
    }
}