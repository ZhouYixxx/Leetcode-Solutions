using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class ZigzagLevelOrder_103 : LeetCodeBase
    {
        public ZigzagLevelOrder_103() : base("ZigzagLevelOrder_103")
        {
            var nodeVals = "5, 3, 7, 1, 4, 6, 8,null, 2";
            var node = TreeNodeHelper.DeserializeBinaryTreeFromBFS(nodeVals);
            TreeNodeHelper.ShowBinaryTree(node);
            Console.WriteLine();
            var list = ZigzagLevelOrder(node);
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    Console.Write($"{list[i][j]}, ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            //用两个stack实现，stack1从左向右入栈，出栈时的顺序则是从右向左
            //stack1出栈将每个node的left和right加入stack2，则stack2中的顺序是从右向左，stack2出栈时则变成从左向右了
            var list = new List<IList<int>>();
            if (root == null)
                return list;
            var stack1 = new Stack<TreeNode>();
            var stack2 = new Stack<TreeNode>();
            stack1.Push(root);
            while (stack1.Any() || stack2.Any())
            {
                var tempList1 = new List<int>();
                while (stack1.Any())
                {
                    var node = stack1.Pop();
                    tempList1.Add(node.val);
                    if (node.left != null)
                    {
                        stack2.Push(node.left);
                    }
                    if (node.right != null)
                    {
                        stack2.Push(node.right);
                    }
                }

                if (tempList1.Any())
                {
                    list.Add(tempList1);
                }
                var tempList2 = new List<int>();
                while (stack2.Any())
                {
                    var node = stack2.Pop();
                    tempList2.Add(node.val);
                    if (node.right != null)
                    {
                        stack1.Push(node.right);
                    }
                    if (node.left != null)
                    {
                        stack1.Push(node.left);
                    }
                }
                if (tempList2.Any())
                {
                    list.Add(tempList2);
                }
            }
            return list;
        }
    }
}