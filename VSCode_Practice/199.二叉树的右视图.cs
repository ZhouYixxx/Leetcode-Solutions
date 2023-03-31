/*
 * @lc app=leetcode.cn id=199 lang=csharp
 *
 * [199] 二叉树的右视图
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
public class Solution199 {
    public void Test(){
        var nums = new int?[]{1};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = RightSideView(root);
    }
    public IList<int> RightSideView(TreeNode root) {
        var res = new List<int>();
        if (root == null)
        {
            return res;
        }
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        //层序遍历，获取每层最右边的节点
        while (q.Count > 0)
        {
            bool flag = false;
            var count = q.Count;
            while (count-- > 0)
            {
                var p = q.Dequeue();
                if (!flag)
                {
                    res.Add(p.val);
                    flag = true;
                }
                if (p.right != null)
                {
                    q.Enqueue(p.right);
                }
                if (p.left != null)
                {
                    q.Enqueue(p.left);
                }
            }
        }
        return res;
    }
}
// @lc code=end

