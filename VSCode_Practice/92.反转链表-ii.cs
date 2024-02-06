/*
 * @lc app=leetcode.cn id=92 lang=csharp
 *
 * [92] 反转链表 II
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
public class Solution92 {
    public void Test()
    {
        var node = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1,2,3,4,5});
        var node1 = reverseBetween2(node,2,2);
        var ans = node1.ToArray();
    }

    /// <summary>
    /// 基础方法
    /// </summary>
    /// <param name="head"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public ListNode ReverseBetween1(ListNode head, int left, int right) 
    {
        if (head == null || left == right)
        {
            return head;
        }
        var dummy = new ListNode();
        dummy.next = head;
        //找到前驱和后继节点
        var preNode = dummy;
        var succNode = dummy;
        while (--left > 0)
        {
            preNode = preNode.next;
            succNode = succNode.next;
            right--;
        }
        while (right-- >= 0)
        {
            succNode = succNode.next;
        }

        //中间部分反转
        var cur = preNode.next;
        var next = cur.next;
        cur.next = succNode;
        while (next != succNode)
        {
            var temp = next.next;
            next.next = cur;
            cur = next;
            next = temp;  
        }
        preNode.next = cur;
        return dummy.next;
    }

    /// <summary>
    /// 头插法，一次遍历完成
    /// </summary>
    /// <param name="head"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || left == right)
        {
            return head;
        }
        var dummy = new ListNode();
        dummy.next = head;
        var preNode = dummy;
        int count = 0;
        while (++count < left)
        {
            preNode = preNode.next;
        }
        //头插法
        var cur = preNode.next;
        while (count++ < right)
        {
            var next = cur.next;
            cur.next = next.next;
            next.next = preNode.next;
            preNode.next = next;//next插入preNode之后
        }

        return dummy.next;
    }

    public ListNode reverseBetween2(ListNode head, int m, int n) {
        // write code here
        var dummy = new ListNode(0);
        dummy.next = head;
        ListNode pre = dummy; //the node before the start node
        ListNode start = dummy.next; //the moved node

        for(int i = 0; i<m-1; i++){
            pre = pre.next;
            start = start.next;
        }
        for(int i = 0; i< n-m; i++)
        {
            //reverse start and next
            var removed = start.next;
            start.next = removed == null ? null : removed.next;
            removed.next = pre.next;
            pre.next = removed;
        }
        return dummy.next;
    }
}
// @lc code=end

