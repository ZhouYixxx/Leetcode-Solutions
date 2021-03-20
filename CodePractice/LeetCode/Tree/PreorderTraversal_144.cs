using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class PreorderTraversal_144 : LeetCodeBase
    {
        public PreorderTraversal_144() : base("PreorderTraversal")
        {
            
        }

        public static IList<int> PreorderTraversal(TreeNode root)
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
        private static void Preorder_Recursive(TreeNode root, IList<int> array)
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
        private static List<int> Preorder_Iterative(TreeNode root)
        {
            var res = new List<int>();
            var stack = new Stack<TreeNode>();
            var node = root;
            while (stack.Any() || node != null)
            {
                //一直向左下方向寻找
                while (node != null)
                {
                    res.Add(node.val);
                    stack.Push(node);
                    node = node.left;
                }
                //入栈的节点都不再add
                node = stack.Pop();
                node = node.right;
            }
            return res;

            //迭代方法二：
            //var array = new List<int>();
            //var stack = new Stack<TreeNode>();
            //stack.Push(root);
            //while (stack.Count > 0)
            //{
            //    //根节点加入
            //    var topNode = stack.Pop();
            //    array.Add(topNode.val);
            //    //右子树先入栈，后出栈，保证根左右的顺序
            //    if (topNode.right != null)
            //    {
            //        stack.Push(topNode.right);
            //    }
            //    if (topNode.left != null)
            //    {
            //        stack.Push(topNode.left);
            //    }
            //}

            //return array;
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