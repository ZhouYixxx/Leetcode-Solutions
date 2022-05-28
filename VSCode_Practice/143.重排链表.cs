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
        var head = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1,2,3,4,5,6,7,8,9,10});
        ReorderList(head);
    }

    public void ReorderList(ListNode head) {
        if (head == null || head.next == null)
        {
            return;
        }
        var mid = FindMidNode(head, out var prev);
        prev.next = null;
        var secondHead = ReverseLinkedList(mid, out var last);
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

    /// <summary>
    /// 递归翻转链表
    /// </summary>
    /// <param name="head">当前链表头</param>
    /// <param name="lastNode">翻转后的链表尾节点</param>
    /// <returns></returns>
    private ListNode ReverseLinkedList(ListNode head, out ListNode lastNode)
    {
        if (head == null || head.next == null)
        {
            lastNode = head;
            return head;
        }
        var next = ReverseLinkedList(head.next, out var subLast);
        //尾部节点后接head节点
        subLast.next = head;
        head.next = null;
        lastNode = head;
        return next;
    }

    private ListNode Merge(ListNode head1, ListNode head2){
        var node1 = head1;
        var node2 = head2;
        var dummy = new ListNode(-1);
        var cur = dummy;
        int flag = 1;//标识符,1：取链表1中节点, 2：取链表2中节点
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
        while (node1 != null)
        {
            cur.next = node1;
            node1 = node1.next;
            cur = cur.next;
        }
        while (node2 != null)
        {
            cur.next = node2;
            node2 = node2.next;
            cur = cur.next;
        }
        return dummy.next;
    }
}
// @lc code=end

