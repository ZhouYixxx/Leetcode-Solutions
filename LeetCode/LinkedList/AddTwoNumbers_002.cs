using System.Collections.Generic;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class AddTwoNumbers_002 : LeetCodeBase
    {
        public AddTwoNumbers_002() : base("AddTwoNumbers_002")
        {
            var l1 = LinkedListHelper.InitLinkedListByArray(new[] { 9,9,9,9 });
            var l2 = LinkedListHelper.InitLinkedListByArray(new[] { 2,7 });
            var node = AddTwoNumbers(l1, l2);
            LinkedListHelper.ShowLinkedList(node, true);
        }

        /// <summary>
        /// 链表表示的两个数相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var digit = 0;
            var node1 = l1;
            var node2 = l2;
            var dummy = new ListNode(-1);
            var newNode = dummy;
            while (node1 != null && node2 != null)
            {
                var val = node1.val + node2.val + digit;
                digit = val >= 10 ? 1 : 0;
                val = val >= 10 ? val % 10 : val;
                var node = new ListNode(val);
                newNode.next = node;
                newNode = newNode.next;
                node1 = node1.next;
                node2 = node2.next;
            }
            while (node1 != null)
            {
                var val = node1.val + digit;
                digit = val >= 10 ? 1 : 0;
                val = val >= 10 ? val % 10 : val;
                var node = new ListNode(val);
                newNode.next = node;
                newNode = newNode.next;
                node1 = node1.next;
            }
            while (node2 != null)
            {
                var val = node2.val + digit;
                digit = val >= 10 ? 1 : 0;
                val = val >= 10 ? val % 10 : val;
                var node = new ListNode(val);
                newNode.next = node;
                newNode = newNode.next;
                node2 = node2.next;
            }
            if (digit == 1)
            {
                newNode.next = new ListNode(1);
            }
            return dummy.next;
        }
    }
}