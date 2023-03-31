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
        return InOrder(root);
        // return dfs(root).Item3;
    }

    /// <summary>
    /// 递归方法
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Tuple<int, int, bool> dfs(TreeNode node)
    {
        if (node == null)
        {
            //最小值设置为int.MaxValue, 最大值设置为int.MinValue，以便不影响后续的比较
           return new Tuple<int, int, bool>(int.MaxValue, int.MinValue, true); 
        }
        if (node.left == null && node.right == null)
        {
            return new Tuple<int, int, bool>(node.val, node.val, true);
        }
        //item1：当前树中的最小值，item2：当前树中最大值，item3：当前树是否是BST
        var leftValid = dfs(node.left);
        var rightValid = dfs(node.right);
        if (!leftValid.Item3 || !rightValid.Item3)
        {
            return new Tuple<int, int, bool>(0,0,false);
        }
        if (node.left != null && leftValid.Item2 >= node.val)
        {
            return new Tuple<int, int, bool>(0,0,false);  
        }
        if (node.right != null && rightValid.Item1 <= node.val)
        {
            return new Tuple<int, int, bool>(0,0,false);  
        }
        var max = Math.Max(node.val, Math.Max(leftValid.Item2, rightValid.Item2));
        var min = Math.Min(node.val, Math.Min(leftValid.Item1, rightValid.Item1));
        return new Tuple<int, int, bool>(min,max,true);  ;
    }

    /// <summary>
    /// 中序遍历结果有序则为BST
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    private bool InOrder(TreeNode root){
        var stack = new Stack<TreeNode>();
        double pre_val = double.MinValue;
        var cur = root;
        while (cur != null || stack.Count > 0)
        {
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            var top = stack.Pop();
            if (top.val <= pre_val)
            {
                return false;
            }
            pre_val = top.val;
            cur = top.right;
        }
        return true;
    }
}
// @lc code=end

