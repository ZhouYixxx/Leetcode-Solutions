using System;

namespace CodePractice.BasicDataStructure.Tree
{
    public class TreeNodeEx
    {
        //两次遍历式创建
        internal static TreeNode CreateBinaryTree(int?[] treeNodeArray)
        {
            if (treeNodeArray.Length == 0 || treeNodeArray[0] == null)
            {
                return null;
            }
            var treeNodes = new TreeNode[treeNodeArray.Length];
            for (int i = 0; i < treeNodeArray.Length; i++)
            {
                var val = treeNodeArray[i];
                if (val == null)
                {
                    treeNodes[i] = null;
                }
                else
                {
                    treeNodes[i] = new TreeNode(val.Value);
                }
            }

            for (int i = 0; i < treeNodes.Length; i++)
            {
                var leftChildIndex = i * 2 + 1;
                var rightChildIndex = i * 2 + 2;
                if (leftChildIndex < treeNodes.Length)
                {
                    treeNodes[i].left = treeNodes[leftChildIndex];
                }
                if (rightChildIndex < treeNodes.Length)
                {
                    treeNodes[i].right = treeNodes[rightChildIndex];
                }
            }
            return treeNodes[0];
        }
    }
}