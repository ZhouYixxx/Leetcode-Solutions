/*
 * @lc app=leetcode.cn id=382 lang=csharp
 *
 * [382] 链表随机节点
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
public class Solution382 {
    private ListNode _head;
    public Solution382(ListNode head) {
        _head = head;
    }
    
    public int GetRandom() {
        int i = 0;
        int pool = 0;
        ListNode cur = _head;
        var random = new Random();
        while (cur != null) {
            i++;
            int rand = random.Next(0,i);
            if (rand == 0) {
                pool = cur.val;
            }
            cur = cur.next;
        }
        return pool;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */
// @lc code=end

