/*
 * @lc app=leetcode.cn id=1008 lang=csharp
 *
 * [1008] 前序遍历构造二叉搜索树
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
public class Solution1008 {
    public void Test()
    {
        var preorder = new int[]{8,5,1,7,10,12};
        var ans = BstFromPreorder(preorder);
    }

    public TreeNode BstFromPreorder(int[] preorder) 
    {
        var root = DFSHelper(preorder, 0, 0, preorder.Length-1);
        return root;
    }

    private TreeNode DFSHelper(int[] preorder, int pre_root, int left, int right)
    {
        if (left >= preorder.Length || left < 0 || right >= preorder.Length || right < 0 || left > right)
        {
            return null;
        }
        if (left == right)
        {
            return new TreeNode(preorder[left]);
        }
        var val = preorder[pre_root];
        var node = new TreeNode(val);
        int right_node_start = pre_root;
        while (right_node_start < preorder.Length)
        {
            if (preorder[right_node_start] > val)
            {
                break;
            }
            right_node_start++;
        }
        var leftNode = DFSHelper(preorder, pre_root+1, pre_root+1, right_node_start-1);
        var rightNode = DFSHelper(preorder, right_node_start, right_node_start, right);
        node.left = leftNode;
        node.right = rightNode;
        return node;
    }
}
// @lc code=end

