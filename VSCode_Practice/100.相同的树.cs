/*
 * @lc app=leetcode.cn id=100 lang=csharp
 *
 * [100] 相同的树
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
public class Solution100 {
    public void Test()
    {
        // var p = DataStructureHelper.GenerateTreeFromArray(new int?[]{1,2,1});
        // var q = DataStructureHelper.GenerateTreeFromArray(new int?[]{1,2,1});
        // var ans = IsSameTree(p,q);
    }

    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        if (p == null && q == null)
        {
            return true;
        }
        if (p == null || q == null)
        {
            return false;
        }
        if (p.val != q.val)
        {
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
// @lc code=end

