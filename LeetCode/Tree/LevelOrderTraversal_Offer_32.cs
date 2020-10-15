using System.Collections.Generic;
using CodePractice.BasicDataStructure.Tree;

namespace CodePractice.LeetCode.Tree
{
    /// <summary>
    /// 二叉树层序遍历（BFS）
    /// </summary>
    public class LevelOrderTraversal_Offer_32
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

        public void Test()
        {
        }
    }
}