/*
 * @lc app=leetcode.cn id=21 lang=csharp
 *
 * [21] 合并两个有序链表
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
public class Solution21 {
    public void Test()
    {
        var node1 = DataStructureHelper.GenerateLinkedListFromArray(new int[]{5});
        var node2 = DataStructureHelper.GenerateLinkedListFromArray(new int[]{2});
        var node = MergeTwoLists(node1, node2);
        var ans = node.ToArray();
    }
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) 
    {
        if (l1 == null && l2 == null)
        {
            return null;
        }
        var dummy = new ListNode();
        var temp = dummy;
        var cur1 = l1;
        var cur2 = l2;
        while (cur1 != null && cur2 != null)
        {
            if (cur1.val <= cur2.val)
            {
                temp.next = cur1;
                temp = temp.next;
                cur1 = cur1.next;
            }
            else
            {
                temp.next = cur2;
                temp = temp.next;
                cur2 = cur2.next;
            }
        }
        while (cur1 != null)
        {
            temp.next = cur1;
            temp = temp.next;
            cur1 = cur1.next;
        }
        while (cur2 != null)
        {
            temp.next = cur2;
            temp = temp.next;
            cur2 = cur2.next;
        }
        return dummy.next;
    }

    public ListNode MergeTwoLists1(ListNode l1, ListNode l2)
    {
        if (l1 == null && l2 == null)
        {
            return null;
        }
        var dummy = new ListNode(-1);
        var node = dummy;
        var cur1 = l1;
        var cur2 = l2;
        while (cur1 != null && cur2 != null)
        {
            if (cur1.val <= cur2.val)
            {
                node.next = cur1;
                cur1 = cur1.next;
                node = node.next;
            }
            else
            {
                node.next = cur2;
                cur2 = cur2.next;
                node = node.next;
            }
        }
        while (cur1 != null)
        {
            node.next = cur1;
            cur1 = cur1.next;
            node = node.next;
        }
        while (cur2 != null)
        {
            node.next = cur2;
            cur2 = cur2.next;
            node = node.next;
        }
        return dummy.next;
    }
}
// @lc code=end

