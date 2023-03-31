/*
 * @lc app=leetcode.cn id=1669 lang=csharp
 *
 * [1669] 合并两个链表
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
public class Solution1669 {
    public void Test()
    {
        var list1 = DataStructureHelper.GenerateLinkedListFromArray(new int[]{0,1,2,3,4,5,6,7,8});
        var list2 = DataStructureHelper.GenerateLinkedListFromArray(new int[]{100,1001,10001});
        var ans = MergeInBetween(list1, 1, 1, list2).ToArray();
    }

    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
        var dummy = new ListNode();
        dummy.next = list1;
        var head = dummy;
        var tail = dummy;
        while (a > 0 || b >= 0)
        {
            if (a > 0)
            {
                head = head.next;
                a--;
            }
            if (b >= 0)
            {
                tail = tail.next;
                b--;
            }
        }
        if (tail != null)
        {
            tail = tail.next;   
        }

        head.next = list2;
        var tail2 = list2;
        while (tail2.next != null)
        {
            tail2 = tail2.next;
        }
        tail2.next = tail;
        return dummy.next;
    }
}
// @lc code=end

