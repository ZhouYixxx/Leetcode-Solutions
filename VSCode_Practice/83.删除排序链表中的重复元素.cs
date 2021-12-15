/*
 * @lc app=leetcode.cn id=83 lang=csharp
 *
 * [83] 删除排序链表中的重复元素
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
using System;

public class Solution083 {
    public void Test()
    {
        var nums = new int[]{2,2,2,2,3};
        var head = DataStructureHelper.GenerateLinkedListFromArray(nums);
        var node = DeleteDuplicatesRecursive(head);
    }

    public ListNode DeleteDuplicates(ListNode head) 
    {
        var dummy = new ListNode(-1);
        dummy.next = head;
        var left = dummy.next;
        var right = dummy.next;
        while (right != null)
        {
            if (right.val != left.val)
            {
                left.next = right;
                left = right;
            }
            else if (right.next == null && left.val == right.val)
            {
                left.next = null;
            }
            right = right.next;
        }
        return dummy.next;
    }

    public ListNode DeleteDuplicatesRecursive(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }
        if (head.val == head.next.val)
        {
            return DeleteDuplicatesRecursive(head.next);
        }
        else
        {
            head.next = DeleteDuplicatesRecursive(head.next);
            return head;
        }
    }
}
// @lc code=end

