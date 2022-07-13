/*
 * @lc app=leetcode.cn id=230 lang=csharp
 *
 * [230] 二叉搜索树中第K小的元素
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
public class Solution230 {
    public void Test()
    {
        var nums = new int?[]{5,3,6,2,4,null,null,1};
        int k = 3;
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = KthSmallest(root, k);
    }

    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="root"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int KthSmallest(TreeNode root, int k) {
        var cur = root;
        var stack = new Stack<TreeNode>();
        while (stack.Count > 0 || cur != null)
        {
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            if (stack.Count > 0)
            {
                cur = stack.Pop();
                if (k == 1)
                {
                    return cur.val;
                }
                else
                {
                    k--;
                }
                cur = cur.right;
            }
        }
        return -1;
    }
}
// @lc code=end

