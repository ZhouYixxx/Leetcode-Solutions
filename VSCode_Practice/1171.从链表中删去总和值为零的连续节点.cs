/*
 * @lc app=leetcode.cn id=1171 lang=csharp
 *
 * [1171] 从链表中删去总和值为零的连续节点
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
public class Solution1171 {
    public void Test()
    {
        var node = DataStructureHelper.GenerateLinkedListFromArray(new int[]{0,1,2,});
        var node1 = RemoveZeroSumSublists(node);
        var ans = node1.ToArray();
    }

    public ListNode RemoveZeroSumSublists(ListNode head) {
        //字典存储：key=当前节点的前缀和，value=当前节点
        var sumDic = new Dictionary<int, ListNode>();
        var dummy = new ListNode();
        dummy.next = head;
        var sum = 0;
        var cur = dummy.next;
        sumDic.Add(0, dummy);
        while (cur != null)
        {
            sum += cur.val;
            if (!sumDic.ContainsKey(sum))
            {
                sumDic.Add(sum, cur);
            }
            else
            {
                var node = sumDic[sum];
                //要把字典中node到cur节点中间的所有项删除
                var delNode = node.next;
                var tempSum = sum + delNode.val;
                while (delNode != cur)
                {
                    sumDic.Remove(tempSum);
                    delNode = delNode.next;
                    tempSum += delNode.val;
                }
                node.next = cur.next;
            }
            cur = cur.next;
        }
        return dummy.next;
    }
}
// @lc code=end

