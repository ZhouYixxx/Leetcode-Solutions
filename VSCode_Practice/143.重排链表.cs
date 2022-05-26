/*
 * @lc app=leetcode.cn id=143 lang=csharp
 *
 * [143] 重排链表
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
public class Solution143 {
    public void Test(){
        var head = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1,2,3});
        var rev = ReverseLinkedList(head);
        ReorderList(head);
    }

    public void ReorderList(ListNode head) {
        var mid = FindMidNode(head, out var prev);
        prev.next = null;
        var secondHead = ReverseLinkedList(mid);
        head = Merge(head, secondHead);
    }

    private ListNode FindMidNode(ListNode head, out ListNode prev)
    {
        prev = head;
        ListNode fast = head;
        ListNode slow = head;
        while (fast?.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    private ListNode ReverseLinkedList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }
        var next = ReverseLinkedList(head.next);
        next.next = head;
        head.next = null;
        return next;
    }

    private ListNode Merge(ListNode head1, ListNode head2){
        var node1 = head1;
        var node2 = head2;
        var cur = head1;
        int flag = 2;//标识符,1：取链表1中节点, 2：取链表2中节点
        while (node1 != null && node2 != null)
        {
            if (flag == 2)
            {
                cur.next = node2;
                node2 = node2.next;
                flag = 1;
            }
            else 
            {
                cur.next = node1;
                node1 = node1.next;
                flag = 2;
            }
            cur = cur.next;
        }
        return head1;
    }
}
// @lc code=end

