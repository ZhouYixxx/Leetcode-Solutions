/*
 * @lc app=leetcode.cn id=1290 lang=csharp
 *
 * [1290] 二进制链表转整数
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
public class Solution1290 {
    public void Test(){
        var head = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1,0,0,1,0,0,1,1,1,0,0,0,0,0,0});
        var ans = GetDecimalValue(head);
    }

    public int GetDecimalValue(ListNode head) {
        int num = 0;
        var cur = head;
        while (cur != null)
        {
            num = num * 2 + cur.val;
            cur = cur.next;
        }
        return num;
    }
}
// @lc code=end

