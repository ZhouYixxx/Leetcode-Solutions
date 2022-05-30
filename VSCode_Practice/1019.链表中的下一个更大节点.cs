/*
 * @lc app=leetcode.cn id=1019 lang=csharp
 *
 * [1019] 链表中的下一个更大节点
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
public class Solution1019 {
    public void Test()
    {
        var node = DataStructureHelper.GenerateLinkedListFromArray(new int[]{2,1,5});
        var node1 = NextLargerNodes(node);
        var ans = node1.ToArray();
    }

    public int[] NextLargerNodes(ListNode head) {
        //链表转数组
        var list = new List<int>();
        var cur = head;
        while (cur != null)
        {
            list.Add(cur.val);
            cur = cur.next;
        }
        //单调栈寻找下一个更大的值
        var ans = new int[list.Count];
        var s = new Stack<int>();
        for (int i = list.Count -1 ; i >= 0; i--)
        {
            while (s.Count > 0 && s.Peek() <= list[i])
            {
                s.Pop();
            }
            ans[i] = s.Count == 0 ? 0 : s.Peek();
            s.Push(list[i]);
        }
        return ans;
    }
}
// @lc code=end

