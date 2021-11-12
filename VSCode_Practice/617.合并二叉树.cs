/*
 * @lc app=leetcode.cn id=617 lang=csharp
 *
 * [617] 合并二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution617 {
    public void Test()
    {
        var nums1 = new int?[]{4};
        var nums2 = new int?[]{2,1,3,null,4,null,7};
        var node1 = DataStructureHelper.GenerateTreeFromArray(nums1);
        var node2 = DataStructureHelper.GenerateTreeFromArray(nums2);
        var ans = MergeTrees(node1,node2);
        var nums = DataStructureHelper.ToArray(ans);
    }

    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) 
    {
        var ans = MergeDFS(root1,root2);
        return ans;
    }

    private TreeNode MergeDFS(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null)
        {
            return null;
        }
        if (root1 == null && root2 != null)
        {
            return root2;
        }
        if (root1 != null && root2 == null)
        {
            return root1;
        }
        var left = MergeDFS(root1.left,root2.left);
        var right = MergeDFS(root1.right, root2.right);
        var node = new TreeNode(root1.val+root2.val, left, right);
        return node;
    }
}
// @lc code=end

