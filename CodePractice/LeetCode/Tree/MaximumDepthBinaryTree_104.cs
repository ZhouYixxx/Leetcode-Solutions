using CodePractice.BasicDataStructure.Tree;
using CodePractice.Core;

namespace CodePractice.LeetCode.Tree
{
    public class MaximumDepthBinaryTree_104 : LeetCodeBase
    {
        public MaximumDepthBinaryTree_104() : base("MaximumDepthBinaryTree_104")
        {
            var nodeVals = "5, 3, 7, 1, 4, 6, 8,null, 2";
            var root = TreeNodeHelper.DeserializeBinaryTreeFromBFS(nodeVals);
            var height = MaximumDepth(root);
            var depth = MaximumDepthUp(root);
        }

        private int ans;
        /// <summary>
        /// 自顶向下递归
        /// </summary>
        /// <returns></returns>
        public int MaximumDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int height = 1;
            MaximumDepthDown(root, height);
            return ans;
        }

        private void MaximumDepthDown(TreeNode node, int height)
        {
            if (node == null)
            {
                return;
            }

            if (node.left == null && node.right == null)
            {
                ans = System.Math.Max(ans, height);
            }
            height++;
            MaximumDepthDown(node.left,  height);
            MaximumDepthDown(node.right, height);
        }

        /// <summary>
        /// 自底向上递归
        /// </summary>
        /// <returns></returns>
        public int MaximumDepthUp(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            var left = MaximumDepthUp(node.left);
            var right = MaximumDepthUp(node.right);
            return System.Math.Max(left, right) + 1;
        }
    }
}