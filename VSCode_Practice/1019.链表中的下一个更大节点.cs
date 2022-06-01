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
        var node = DataStructureHelper.GenerateLinkedListFromArray(new int[]{2,1,4,8,6});
        var ans = NextLargerNodes(node);
        var ans1 = NextLargerNodes1(node);
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

    public int[] NextLargerNodes1(ListNode head) {
        //链表翻转
        var reverseHead = Reverse(head);
        //单调栈寻找下一个更大的值
        var ans = new List<int>();
        var s = new Stack<int>();
        var cur = reverseHead;
        while (cur != null)
        {
            while (s.Count > 0 && s.Peek() <= cur.val)
            {
                s.Pop();
            }
            var num = s.Count == 0 ? 0 : s.Peek();
            ans.Add(num);
            s.Push(cur.val);
            cur = cur.next;
        }
        ans.Reverse();
        return ans.ToArray();
    }

    private ListNode Reverse(ListNode head)
    {
        var cur = head;
        ListNode prev = null;
        while (cur != null)
        {
            var nextTemp = cur.next;
            cur.next = prev;
            prev = cur;
            cur = nextTemp;
        }
        return prev;
    }
}
// @lc code=end

