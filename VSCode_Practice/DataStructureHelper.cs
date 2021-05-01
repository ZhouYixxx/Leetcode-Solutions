using System;
using System.Collections.Generic;

public static class DataStructureHelper
{
    #region 链表处理

    //从数组生成链表
    public static ListNode GenerateLinkedListFromArray(int[] nums)
    {
        var dummy = new ListNode();
        var cur = dummy;
        for (int i = 0; i < nums.Length; i++)
        {
            var node = new ListNode(nums[i]);
            cur.next = node;
            cur = cur.next;
        }
        return dummy.next;
    }

    //从链表生成数组
    public static int[] ToArray(this ListNode node)
    {
        var list = new List<int>();
        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }
        return list.ToArray();
    }

    #endregion
}