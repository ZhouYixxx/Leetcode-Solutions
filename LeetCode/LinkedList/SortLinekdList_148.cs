using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class SortLinekdList_148 : LeetCodeBase
    {
        public SortLinekdList_148() : base("SortLinekdList_148")
        {
            var node = LinkedListHelper.InitLinkedListByArray(new int[] {3, 2, 4, 6, 5, 1, 7, 8, 11});
            LinkedListHelper.ShowLinkedList(node,false);
            //var sortedNode = SortList(node, null);
            var sortedNode = SortList2(node);
            LinkedListHelper.ShowLinkedList(sortedNode);
        }

        public ListNode SortList(ListNode head)
        {
            return SortList(head, null);
        }

        private ListNode SortList(ListNode head, ListNode tail)
        {
            if (head?.next == null)
            {
                return head;
            }
            //head指向tail时，应该将head的next设置为null切断链表，避免中点被多次处理甚至死循环
            if (head.next == tail)
            {
                head.next = null;
                return head;
            }
            var mid = FindMidNode(head, tail);
            var node1 = SortList(head, mid);
            var node2 = SortList(mid, tail);
            var sortedNode = MergeTwoLists(node1, node2);
            return sortedNode;
        }

        /// <summary>
        /// O(NlogN)算法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private ListNode SortList2(ListNode head)
        {
            if (head?.next == null)
            {
                return head;
            }
            //求长度
            var length = 0;
            var temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            var dummyNode = new ListNode(0) {next = head};
            int subLength = 1;
            while (subLength <= length)
            {
                ListNode prev = dummyNode;
                ListNode cur = dummyNode.next;
                while (cur != null)
                {
                    ListNode head1 = cur;
                    for (int i = 0; i < subLength - 1; i++)
                    {
                        cur = cur?.next;
                    }
                    ListNode head2 = cur?.next;
                    if (cur != null) cur.next = null;
                    cur = head2;
                    for (int i = 0; i < subLength - 1; i++)
                    {
                        cur = cur?.next;
                    }
                    ListNode next = cur?.next;
                    if (cur != null) cur.next = null;
                    var newHead = MergeTwoLists(head1, head2);
                    prev.next = newHead;
                    //避免下一次循环newHead中的值覆盖prev.next
                    while (prev.next != null)
                    {
                        prev = prev.next;
                    }
                    cur = next;
                }
                subLength <<= 1;
            }
            return dummyNode.next;
        }

        /// <summary>
        /// 合并两个有序链表
        /// </summary>
        private ListNode MergeTwoLists(ListNode head1, ListNode head2)
        {
            var dummyNode = new ListNode(0);
            var temp = dummyNode;
            var temp1 = head1;
            var temp2 = head2;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.val >= temp2.val)
                {
                    temp.next = temp2;
                    temp2 = temp2.next;
                }
                else
                {
                    temp.next = temp1;
                    temp1 = temp1.next;
                }
                temp = temp.next;
            }

            if (temp1 != null)
            {
                temp.next = temp1;
            }
            else if (temp2 != null)
            {
                temp.next = temp2;
            }
            return dummyNode.next;
        }

        /// <summary>
        /// 快慢指针法寻找链表中点
        /// </summary>
        private ListNode FindMidNode(ListNode head, ListNode tail)
        {
            var slow = head;
            var fast = head;
            while (fast != tail)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast != tail)
                {
                    fast = fast.next;
                }
            }
            return slow;
        }
    }
}