/*
 * @lc app=leetcode.cn id=98 lang=csharp
 *
 * [98] 验证二叉搜索树
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
public class Solution98 {
    public void Test(){
        var nums = new int?[]{5,1,10,null,2,6,14};
        var root = DataStructureHelper.GenerateTreeFromArray(nums);
        var ans = IsValidBST(root);
    }

    public bool IsValidBST(TreeNode root) {
        if (root == null)
        {
            return false;
        }
        return dfs(root).Item3;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Tuple<int, int, bool> dfs(TreeNode node)
    {
        if (node == null)
        {
           return new Tuple<int, int, bool>(int.MaxValue, int.MinValue, true); 
        }
        if (node.left == null && node.right == null)
        {
            return new Tuple<int, int, bool>(node.val, node.val, true);
        }
        //item1：最小值，item2：最大值，item3：是否valid
        var isLeftValid = dfs(node.left);
        var isRightValid = dfs(node.right);
        if (!isLeftValid.Item3 || !isRightValid.Item3)
        {
            return new Tuple<int, int, bool>(0,0,false);
        }
        if (node.left != null && isLeftValid.Item2 >= node.val)
        {
            return new Tuple<int, int, bool>(0,0,false);  
        }
        if (node.right != null && isRightValid.Item1 <= node.val)
        {
            return new Tuple<int, int, bool>(0,0,false);  
        }
        var max = Math.Max(node.val, Math.Max(isLeftValid.Item2, isRightValid.Item2));
        var min = Math.Min(node.val, Math.Min(isLeftValid.Item1, isRightValid.Item1));
        return new Tuple<int, int, bool>(min,max,true);  ;
    }
}
// @lc code=end

