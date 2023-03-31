/*
 * @lc app=leetcode.cn id=113 lang=csharp
 *
 * [113] 路径总和 II
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
public class Solution113 {
    public void Test()
    {
        var nums = new int?[]{5,4,8,11,null,13,4,7,2,null,null,5,1};
        var node = DataStructureHelper.GenerateTreeFromArray(nums);
        int targetSum = 22;
        var ans = PathSum(node, targetSum);
    }

    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        var res = new List<IList<int>>();
        if (root == null)
        {
            return res;
        }
        var path = new List<int>();
        BackTrack(root, targetSum, res, path);
        return res;
    }

    private void BackTrack(TreeNode node, int targetSum, IList<IList<int>> res, List<int> path){
        if (node.left == null && node.right == null)
        {
            path.Add(node.val);
            var sum = 0;
            foreach (var item in path)
            {
                sum += item;
            }
            if (sum == targetSum)
            {
                res.Add(new List<int>(path));
            }
            return;
        }
        path.Add(node.val);
        if (node.left != null)
        {
            BackTrack(node.left, targetSum, res, path);
            path.RemoveAt(path.Count-1);
        }
        if (node.right != null)
        {
            BackTrack(node.right, targetSum, res, path);
            path.RemoveAt(path.Count-1);
        }
    }
}
// @lc code=end

