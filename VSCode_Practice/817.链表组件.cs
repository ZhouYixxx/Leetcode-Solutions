/*
 * @lc app=leetcode.cn id=817 lang=csharp
 *
 * [817] 链表组件
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
public class Solution817 {
    public void Test()
    {
        var node = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1,2,3,4,5});
        var nums = new int[]{1,2,3};
        var ans = NumComponents(node, nums);
    }

    public int NumComponents(ListNode head, int[] nums) {
        var set = new HashSet<int>(nums);
        var cur = head;
        int cnt = 0;
        while (cur != null)
        {
            //最后一个节点
            if (cur.next == null && set.Contains(cur.val))
            {
                cnt++;
                break;
            }
            if (cur.next != null && set.Contains(cur.val) && !set.Contains(cur.next.val))
            {
                cnt++;
            }
            cur = cur.next;
        }
        return cnt;
    }
}
// @lc code=end

