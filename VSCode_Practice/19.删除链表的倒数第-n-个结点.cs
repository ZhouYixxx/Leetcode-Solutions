/*
 * @lc app=leetcode.cn id=19 lang=csharp
 *
 * [19] 删除链表的倒数第 N 个结点
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
public class Solution19 {

    // public void Test()
    // {
    //     var nums = new int[]{1,2};
    //     var n = 1;
    //     var head = DataStructureHelper.GenerateLinkedListFromArray(nums);
    //     var node = RemoveNthFromEnd(head, n);
    // }

    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        var dummy = new ListNode(0);
        dummy.next = head;
        var slow = dummy;
        var fast = dummy;
        while (n > 0)
        {
            fast = fast.next;
            n--;
        }
        while (fast?.next != null)
        {
            slow = slow.next;
            fast = fast.next;
        }
        //slow的下一个节点就是待删除的节点
        slow.next = slow.next.next;
        return dummy.next;
    }
}
// @lc code=end

