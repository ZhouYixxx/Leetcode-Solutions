using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class SerDeserBinaryTree_297 : LeetCodeBase
    {
        public SerDeserBinaryTree_297() : base("SerDeserBinaryTree_297")
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
            var res = serialize(root);
            Console.WriteLine(res);
            var node1 = deserialize(res);
            TreeNodeHelper.ShowBinaryTree(node1);
            Console.ReadKey();
        }

        #region DFS

        public string Serialize(TreeNode root)
        {
            var node = root;
            var stack = new Stack<TreeNode>();
            var sb = new StringBuilder();
            while (stack.Any() || node != null)
            {
                while (node != null)
                {
                    sb.Append(node.val+",");
                    stack.Push(node);
                    node = node.left;
                }
                sb.Append("null,");
                if (stack.Any())
                {
                    node = stack.Pop();
                    node = node.right;
                }
            }

            if (sb[sb.Length - 1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            var strs = data.Split(',');
            var list = new List<string>();
            foreach (var str in strs)
            {
                list.Add(str);
            }
            return Helper(list);
        }

        private TreeNode Helper(List<string> strList)
        {
            if (strList.Count == 0)
            {
                return null;
            }
            if (strList[0] == "null")
            {
                strList.RemoveAt(0);
                return null;
            }
            var value = Int32.Parse(strList[0]);
            var node = new TreeNode(value);
            strList.RemoveAt(0);
            node.left = Helper(strList);
            node.right = Helper(strList);
            return node;
        }

        #endregion

        #region BFS

        public string serialize(TreeNode root)
        {
            var sb = new StringBuilder();
            serializeBfs(root, sb);
            return sb.ToString();
        }

        public void serializeBfs(TreeNode root, StringBuilder sb)
        {
            if (root == null) return;

            sb.Append($"{root.val},");
            if (root.left == null) sb.Append("null,");
            else
            {
               serializeBfs(root.left, sb);
            }

            if (root.right == null) sb.Append("null,");
            else
            {
                serializeBfs(root.right, sb);
            }
        }

        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var dataArray = data.Split(',');
            var parentNode = new TreeNode(Int32.Parse(dataArray[0]));
            deserializeRecursive(dataArray, 1, parentNode);
            return parentNode;
        }

        private int deserializeRecursive(string[] dataArray, int index, TreeNode parentNode)
        {
            var tempIndex = index;
            if (dataArray[tempIndex] == "null" && dataArray[tempIndex + 1] == "null")
            {
                return tempIndex + 2;
            }
            if (dataArray[tempIndex] == "null")
            {
                tempIndex = tempIndex + 1;
            }
            else
            {
                parentNode.left = new TreeNode(Int32.Parse(dataArray[index]));
                tempIndex = deserializeRecursive(dataArray, index + 1, parentNode.left);
            }
            if (dataArray[tempIndex] == "null")
            {
                tempIndex = tempIndex + 1;
            }
            else
            {
                parentNode.right = new TreeNode(Int32.Parse(dataArray[tempIndex]));
                tempIndex = deserializeRecursive(dataArray, tempIndex + 1, parentNode.right);
            }
            return tempIndex;
        }

        #endregion


    }
}