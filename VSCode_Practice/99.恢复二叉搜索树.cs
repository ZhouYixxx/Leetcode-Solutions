/*
 * @lc app=leetcode.cn id=99 lang=csharp
 *
 * [99] 恢复二叉搜索树
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
public class Solution99 {
    public void Test(){
        var root = DataStructureHelper.GenerateTreeFromArray(new int?[]{3,1,4,null,null,2});
        RecoverTree(root);
    }

    public void RecoverTree(TreeNode root) {
        RecoverTreeInternal_2(root);
    }

    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="root"></param>
    private void RecoverTreeInternal_1(TreeNode root)
    {
        var res = new List<TreeNode>();
        var s = new Stack<TreeNode>();
        var cur = root;
        while (s.Count > 0 || cur != null)
        {
            while (cur != null)
            {
                s.Push(cur);
                cur = cur.left;
            }
            cur = s.Pop();
            res.Add(cur);
            cur = cur.right;
        }
        var index1 = -1;
        var index2 = -1;
        for (int i = 0; i < res.Count; i++)
        {
            if (i != res.Count-1 && res[i].val > res[i+1].val)
            {
                if (index1 == -1)
                {
                    index1 = i;   
                }
                index2 = i+1;
            }
        }

        //swap
        var temp = res[index1].val;
        res[index1].val = res[index2].val;
        res[index2].val = temp;
    }

    /// <summary>
    /// 中序遍历优化
    /// </summary>
    /// <param name="root"></param>
    private void RecoverTreeInternal_2(TreeNode root)
    {
        var res = new List<TreeNode>();
        var s = new Stack<TreeNode>();
        var cur = root;
        TreeNode prev = null;
        TreeNode node1 = null;
        TreeNode node2 = null;
        while (s.Count > 0 || cur != null)
        {
            while (cur != null)
            {
                s.Push(cur);
                cur = cur.left;
            }
            cur = s.Pop();
            if (prev == null || prev.val < cur.val)
            {
                prev = cur;
            }
            else
            {
                if (node1 == null)
                {
                    node1 = prev;
                }
                node2 = cur;
            }
            cur = cur.right;
        }

        //swap
        var temp = node1.val;
        node1.val = node2.val;
        node2.val = temp;
    }

}
// @lc code=end

