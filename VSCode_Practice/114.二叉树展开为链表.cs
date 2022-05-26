/*
 * @lc app=leetcode.cn id=114 lang=csharp
 *
 * [114] 二叉树展开为链表
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
public class Solution114 {
    public void Test(){
        var node = DataStructureHelper.GenerateTreeFromArray(new int?[]{1,2,5,3,4,null,6});
        var node1 = DataStructureHelper.GenerateTreeFromArray(new int?[]{2,3,4});
        Flatten(node);
    }

    public void Flatten(TreeNode root) {
        while (root != null)
        {
            if (root.left == null)
            {
                root = root.right;
            }
            else
            {
                var pre = root.left;
                while (pre.right != null)
                {
                    pre = pre.right;
                }
                pre.right = root.right;
                root.right = root.left;
                root.left = null;
                root = root.right;
            }
        }
    }
}
// @lc code=end

