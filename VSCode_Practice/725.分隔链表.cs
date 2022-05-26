/*
 * @lc app=leetcode.cn id=725 lang=csharp
 *
 * [725] 分隔链表
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
public class Solution725 {

    public void Test(){
        int k = 5;
        var head = DataStructureHelper.GenerateLinkedListFromArray(new int[]{1,2,3});
        var res = SplitListToParts(head, k);
    }

    public ListNode[] SplitListToParts(ListNode head, int k) {
        var totalCnt = 0;
        var node = head;
        //获取节点总数
        while (node != null)
        {
            totalCnt++;
            node = node.next;
        }
        var ans = new ListNode[k];
        var cur = head;
        int idx = 0;
        while (idx < ans.Length)
        {
            if (cur == null)
            {
                ans[idx++] = null; 
                continue;
            }
            var count = totalCnt % k == 0 ? totalCnt / k : totalCnt / k + 1;
            totalCnt -= count;
            k--;
            ans[idx++] = cur;
            ListNode prev = null;
            while (count-- > 0)
            {
                prev = cur;
                cur = cur.next;
            }
            prev.next = null;
        }
        return ans;
    }
}
// @lc code=end

