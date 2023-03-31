/*
 * @lc app=leetcode.cn id=257 lang=csharp
 *
 * [257] 二叉树的所有路径
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
using System.Text;

public class Solution257 {
    public void Test(){
        var vals = new int?[]{1};
        var node = DataStructureHelper.GenerateTreeFromArray(vals);
        var res = BinaryTreePaths(node);
    }

    public IList<string> BinaryTreePaths(TreeNode root) {
        var res = new List<string>();
        if (root == null)
        {
            return res;
        }
        var path = new List<int>();
        DFS(root, path, res);
        return res;
    }
    
    /// <summary>
    /// BackTrack / DFS
    /// </summary>
    /// <param name="node"></param>
    /// <param name="path"></param>
    /// <param name="res"></param>
    private void DFS(TreeNode node, List<int> path, IList<string> res){
        if (node.left == null && node.right == null)
        {
            path.Add(node.val);
            var sb = new StringBuilder();
            for (int i = 0; i < path.Count; i++)
            {
                if (i == path.Count -1)
                    sb.Append($"{path[i]}");   
                else
                    sb.Append($"{path[i]}->");
            }
            res.Add(sb.ToString());
            return;
        }
        path.Add(node.val);
        if (node.left != null)
        {
            DFS(node.left, path, res);
            path.RemoveAt(path.Count-1);   
        }
        if (node.right != null)
        {
            DFS(node.right, path, res);
            path.RemoveAt(path.Count-1);   
        }
    }
}
// @lc code=end

