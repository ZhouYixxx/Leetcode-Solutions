/*
 * @lc app=leetcode.cn id=82 lang=csharp
 *
 * [82] 删除排序链表中的重复元素 II
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
public class Solution082 {
    public void Test()
    {
        var nums = new int[]{1,1,1,2,3,3,4};
        var head = DataStructureHelper.GenerateLinkedListFromArray(nums);
        var node = DeleteDuplicatesRecursive(head);
    }

    /// <summary>
    /// 迭代法
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode DeleteDuplicates(ListNode head) 
    {
        var dummy = new ListNode();
        dummy.next = head;
        var left = dummy;
        var right = dummy.next;
        while (right != null)
        {
            bool needDelete = false;//是否需要删除
            //right.val == right.next.val，说明需要移除至少right和right.next，needDelete设为true
            while (right.next != null && right.val == right.next.val)
            {
                needDelete = true;
                right = right.next;
            }
            if (needDelete)
            {
                left.next = right.next;
            }
            else
            {
                left = left.next;
            }
            right = right.next;

        }
        return dummy.next;
    }

    /// <summary>
    /// 递归法
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode DeleteDuplicatesRecursive(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }
        // 当前节点和下一个节点，值不同，则head的值是需要保留的，对head.next继续递归
        if (head.val != head.next.val)
        {
            var node = DeleteDuplicatesRecursive(head.next);
            head.next = node;
            return head;
        }
        // 当前节点与下一个节点的值重复了，重复的值都不能要。
        else
        {
            // 一直往下找，找到不重复的节点。返回对不重复节点的递归结果
            var node = head;
            while (node != null && node.val == head.val)
            {
                node = node.next;
            }
            var newHead = DeleteDuplicatesRecursive(node);
            return newHead;
        }
    }
}
// @lc code=end

