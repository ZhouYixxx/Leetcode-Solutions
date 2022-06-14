/*
 * @lc app=leetcode.cn id=107 lang=csharp
 *
 * [107] 二叉树的层序遍历 II
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
public class Solution107 {
    public void Test(){
        var node = DataStructureHelper.GenerateTreeFromArray(new int?[]{3});
        var ans = LevelOrderBottom(node);
    }

    /// <summary>
    /// 普通层序遍历后翻转
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        var res = new List<IList<int>>();
        if (root == null)
        {
            return res;
        }
        var node = root;
        var q = new Queue<TreeNode>();
        q.Enqueue(node);
        int levelCount = 0;
        while (q.Count > 0)
        {
            var levelRes = new List<int>();
            levelCount = q.Count;
            while (levelCount-- > 0)
            {
                var p = q.Dequeue();
                levelRes.Add(p.val);
                if (p.left != null)
                {
                    q.Enqueue(p.left);
                }
                if (p.right != null)
                {
                    q.Enqueue(p.right);
                }
            }
            res.Add(levelRes);
        }
        res.Reverse();
        return res;
    }
}
// @lc code=end

