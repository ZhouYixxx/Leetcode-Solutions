/*
 * @lc app=leetcode.cn id=109 lang=csharp
 *
 * [109] 有序链表转换二叉搜索树
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
public class Solution109 {
    public void Test()
    {
        var head = DataStructureHelper.GenerateLinkedListFromArray(
            new int[]{1,2,3,4,5,6,7,8,9}
        );
        var ans = SortedListToBST(head);
        var show = DataStructureHelper.ToArray(ans);
    }

    public TreeNode SortedListToBST(ListNode head) {
        return SortedListToBST_1(head);
    }

    /// <summary>
    /// 方法一：链表转化为有序数组，递归处理
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    private TreeNode SortedListToBST_1(ListNode head){
        if (head == null)
        {
            return null;
        }
        var nums = ListNodeToArray(head);
        var node = RecursiveHelper(nums,0,nums.Length-1);
        return node;
    }

    private int[] ListNodeToArray(ListNode head)
    {
        var res = new List<int>();
        var node = head;
        while (node != null)
        {
            res.Add(node.val);
            node = node.next;
        }
        return res.ToArray();
    }

    /// <summary>
    /// 递归
    /// </summary>
    /// <returns></returns>
    private TreeNode RecursiveHelper(int[] nums, int left, int right)
    {
        if (left > right)
        {
            return null;
        }
        if (left == right)
        {
            return new TreeNode(nums[left]);
        }
        var mid = (left + right + 1) / 2;
        var node = new TreeNode(nums[mid]);
        node.left = RecursiveHelper(nums,left, mid-1);
        node.right = RecursiveHelper(nums,mid+1, right);
        return node;
    }
}
// @lc code=end

