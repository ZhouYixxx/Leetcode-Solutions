/*
 * @lc app=leetcode.cn id=95 lang=csharp
 *
 * [95] 不同的二叉搜索树 II
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
public class Solution95 {
    public void Test()
    {
        int n = 3;
        var ans = GenerateTrees(n);
    }

    public IList<TreeNode> GenerateTrees(int n) {
        var res = DFS(1, n);
        return res;
    }

    private List<TreeNode> DFS(int start, int end)
    {
        if (start > end)
        {
            return new List<TreeNode>(){null};
        }
        if (end == start)
        {
            return new List<TreeNode>(){new TreeNode(end)};
        }
        var ans = new List<TreeNode>();
        for (int i = start; i <= end; i++)
        {
            var leftChildren = DFS(start, i-1);
            var rightChildren = DFS(i+1, end);
            foreach (var leftChild in leftChildren)
            {
                foreach (var rightChild in rightChildren)
                {
                    var root = new TreeNode(i);
                    root.left = leftChild;
                    root.right = rightChild;
                    ans.Add(root);
                }
            }
        }
        return ans;
    }
}
// @lc code=end

