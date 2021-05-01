/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
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
public class Solution206 {
    public void Test()
    {
        var node = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1});
        var node1 = ReverseList(node);
        var ans = node1.ToArray();
    }

    public ListNode ReverseList(ListNode head) 
    {
        if (head == null)
        {
            return null;
        }
        var cur = head;
        var next = cur.next;
        cur.next = null;
        while (next != null)
        {
            var temp = next.next;
            next.next = cur;
            cur = next;
            next = temp;
        }
        return cur;
    }
}
// @lc code=end

