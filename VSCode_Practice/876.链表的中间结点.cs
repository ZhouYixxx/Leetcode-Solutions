/*
 * @lc app=leetcode.cn id=876 lang=csharp
 *
 * [876] 链表的中间结点
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
public class Solution876 {

    // public void Test()
    // {
    //     var nums = new int[]{4};
    //     var node = DataStructureHelper.GenerateLinkedListFromArray(nums);
    //     var ans = MiddleNode(node);
    // }

    public ListNode MiddleNode(ListNode head) 
    {
        if (head == null)
        {
            return head;
        }
        var node = head;
        var count = 0;
        while (node != null)
        {
            node = node.next;
            count++;
        }
        var mid = count / 2;
        node = head;
        while (mid > 0)
        {
            node = node.next;
            mid--;
        }
        return node;
    }
}
// @lc code=end

