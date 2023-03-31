/*
 * @lc app=leetcode.cn id=235 lang=csharp
 *
 * [235] 二叉搜索树的最近公共祖先
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution235 {
    public void Test()
    {
        var vals = new int?[]{6,2,8,0,4,7,9,null,null,3,5};
        var node = DataStructureHelper.GenerateTreeFromArray(vals);
        var p = node.left.right.right;
        var q = node.left.left;
        var ans = LowestCommonAncestor(node, p, q);
    }


    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var node = root;
        while (node != null)
        {
            if (node.val > p.val && node.val > q.val)
            {
                node = node.left;
                continue;
            }
            if (node.val < p.val && node.val < q.val)
            {
                node = node.right;
                continue;
            }
            break;
            
        }
        return node;
    }
}
// @lc code=end

