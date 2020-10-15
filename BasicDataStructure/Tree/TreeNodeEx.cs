using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BasicDataStructure.Tree
{
    /// <summary>
    /// 基于层序遍历实现
    /// </summary>
    public class TreeNodeEx
    {
        #region 二叉树序列化(基于前序遍历/DFS)

        /// <summary>
        /// 二叉树序列化(基于前序遍历/DFS)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        internal static string SerializeBinaryTreeFromDFS(TreeNode root)
        {
            var builder = new StringBuilder();
            PreOrder(root, builder);
            var val = builder.ToString();
            val = val.Remove(val.LastIndexOf(","), 1);
            return val;
        }

        /// <summary>
        /// 基于前序遍历的实现
        /// </summary>
        /// <param name="node"></param>
        /// <param name="builder"></param>
        private static void PreOrder(TreeNode node, StringBuilder builder)
        {
            if (node == null)
            {
                builder.Append("null,");
                return;
            }
            builder.Append(node.val + ",");
            PreOrder(node.left, builder);
            PreOrder(node.right, builder);
        }

        #endregion

        #region 字符串反序列化为二叉树(基于前序遍历/DFS)

        /// <summary>
        /// 字符串反序列化为二叉树(基于前序遍历/DFS)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static TreeNode DeserializeBinaryTreeFromDFS(string str)
        {
            var array = str.Split(',');
            var treeNodeArray = new int?[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "null")
                {
                    treeNodeArray[i] = null;
                }
                else
                {
                    treeNodeArray[i] = Int32.Parse(array[i]);
                }
            }
            var quene = new Queue<int?>(treeNodeArray);
            var node = BuildTree(quene);
            return node;
        }

        private static TreeNode BuildTree(Queue<int?> quene)
        {
            var val = quene.Dequeue();
            if (val == null)
            {
                return null;
            }
            var node = new TreeNode(val.Value);
            node.left = BuildTree(quene);
            node.right = BuildTree(quene);
            return node;
        }

        #endregion

        #region 二叉树序列化(基于BFS)

        /// <summary>
        /// 二叉树序列化(基于层序遍历/BFS)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        internal static string SerializeBinaryTreeFromBFS(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            var sb = new StringBuilder();
            var quene = new Queue<TreeNode>();
            quene.Enqueue(root);
            while (quene.Count > 0)
            {
                var node = quene.Dequeue();
                if (node == null)
                {
                    sb.Append("null,");
                    continue;
                }
                sb.Append(node.val + ",");
                quene.Enqueue(node.left);
                quene.Enqueue(node.right);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        #endregion

        #region 字符串反序列化为二叉树(基于BFS)

        /// <summary>
        /// 字符串反序列化为二叉树(基于BFS)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static TreeNode DeserializeBinaryTreeFromBFS(string str)
        {
            //字符串处理成数组
            var array = str.Split(',');
            var treeNodeArray = new int?[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "null")
                {
                    treeNodeArray[i] = null;
                }
                else
                {
                    treeNodeArray[i] = Int32.Parse(array[i]);
                }
            }
            //使用队列辅助
            if (treeNodeArray.Length == 0 || treeNodeArray[0] == null)
            {
                return null;
            }
            var quene = new Queue<TreeNode>();
            var root = new TreeNode(treeNodeArray[0].Value);
            quene.Enqueue(root);
            for (int i = 1; i < treeNodeArray.Length - 1; i = i + 2)
            {
                var parent = quene.Dequeue();
                var left = treeNodeArray[i];
                var right = treeNodeArray[i + 1];
                if (left != null)
                {
                    var leftNode = new TreeNode(left.Value);
                    parent.left = leftNode;
                    quene.Enqueue(leftNode);
                }
                if (right != null)
                {
                    var rightNode = new TreeNode(right.Value);
                    parent.right = rightNode;
                    quene.Enqueue(rightNode);
                }
            }
            return root;
        }

        #endregion

        public static void Test()
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
            var dfs = SerializeBinaryTreeFromDFS(root);
            var node = DeserializeBinaryTreeFromDFS(dfs);

            var bfs = SerializeBinaryTreeFromBFS(root);
            var node1 = DeserializeBinaryTreeFromBFS(bfs);
        }
    }
}