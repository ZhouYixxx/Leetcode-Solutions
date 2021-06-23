using System;
using System.Collections.Generic;

public class Solution32_offer {
    public void Test()
    {
        var nums = new int?[]{3};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = LevelOrder(root);
    }

    public int[] LevelOrder(TreeNode root) 
    {
        if (root == null)
        {
            return new int[0];
        }
        var res = new List<int>();
        var quene = new Queue<TreeNode>();
        quene.Enqueue(root);
        while (quene.Count > 0)
        {
            var node = quene.Dequeue();
            res.Add(node.val);
            if (node.left != null)
            {
                quene.Enqueue(node.left);
            }
            if (node.right != null)
            {
                quene.Enqueue(node.right);
            }
        }
        return res.ToArray();
    }
}