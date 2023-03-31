/*
 * @lc app=leetcode.cn id=222 lang=csharp
 *
 * [222] 完全二叉树的节点个数
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
public class Solution222 {
    public void Test(){
        var root = DataStructureHelper.GenerateTreeFromArray(new int?[]{1,2,3,4,5,6});
        var ans = CountNodes(root);
    }

    public int CountNodes(TreeNode root) {
        if (root == null)
        {
            return 0;
        }
        var leftH = GetHeight(root.left);
        var rightH = GetHeight(root.right);
        if (leftH == rightH)
        {
            var leftCount = GetNodeCount(leftH);
            var rightCount = CountNodes(root.right);
            return leftCount + rightCount + 1;
        }
        else
        {
            var leftCount = CountNodes(root.left);
            var rightCount = GetNodeCount(rightH);
            return leftCount + rightCount + 1;
        }
    }

    /// <summary>
    /// 获取二叉树高度
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    private int GetHeight(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        var level = 0;
        while (root != null)
        {
            level++;
            root = root.left;
        }
        return level;
    }

    /// <summary>
    /// 完全二叉树的节点个数
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    private int GetNodeCount(int level)
    {
        int cnt = 1;
        for (int i = 1; i <= level; i++)
        {
            cnt = cnt << 1;
        }
        return cnt-1;
    }
}
// @lc code=end

