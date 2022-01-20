using System;

public class Solution549 {
    public void Test()
    {
        // var nums = new int?[]{1,-2,-3,1,3,-2,null,-1};
        // var root = DataStructureHelper.GenerateTreeFromArray(nums);
        // var ans = LongestConsecutive(root);
    }

    private int maxLength = int.MinValue;

    public int LongestConsecutive(TreeNode root) 
    {
        var res = DFS(root);
        return maxLength;
    }

    private int[] DFS(TreeNode root)
    {
        var arr = new int[2]{1, 1}; 
        if (root == null)
        {
            return arr;
        }
        var leftLen = DFS(root.left);
        if (root.left != null)
        {
            if (root.val == root.left.val + 1)
            {
                arr[0] = leftLen[0] + 1;
            }
            if (root.val == root.left.val - 1)
            {
                arr[1] = leftLen[1] + 1;
            }
        }
        var rightLen = DFS(root.right);
        if (root.right != null)
        {
            if (root.val == root.right.val + 1)
            {
                arr[0] = Math.Max(rightLen[0] + 1, arr[0]);
            }
            if (root.val == root.right.val - 1)
            {
                arr[1] = Math.Max(rightLen[1] + 1, arr[1]);
            }   
        }
        maxLength = Math.Max(maxLength, arr[0] + arr[1] - 1);
        return arr;
    }
    
}