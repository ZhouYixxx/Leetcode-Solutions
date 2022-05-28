/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
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
public class Solution24 {

    public void Test(){
    }
    public ListNode SwapPairs(ListNode head) {
        var ans = RecursiveHelper(head);
        return ans;
    }

    private ListNode RecursiveHelper(ListNode node)
    {
        if (node == null || node.next == null)
        {
            return node;
        }
        var nextNode = node.next;
        var nextSwap = nextNode.next;
        nextNode.next = node;
        node.next = RecursiveHelper(nextSwap);
        return nextNode;
    }
}
// @lc code=end

