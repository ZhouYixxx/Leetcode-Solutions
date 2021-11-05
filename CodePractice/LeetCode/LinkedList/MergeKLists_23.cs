using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using CodePractice.BasicDataStructure.Heap;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class MergeKLists_23 : LeetCodeBase
    {
        public MergeKLists_23() : base("MergeKLists_23")
        {
            var head1 = LinkedListHelper.InitLinkedListByArray(new int[] {});
            var head2 = LinkedListHelper.InitLinkedListByArray(new int[] {-1,5,11});
            var head3 = LinkedListHelper.InitLinkedListByArray(new int[] {});
            var head4 = LinkedListHelper.InitLinkedListByArray(new int[] {6,10});
            var head5 = LinkedListHelper.InitLinkedListByArray(new int[] {7,8});
            var lists = new ListNode[] {head1, head2, head3, head4, head5};
            //var merged = MergeKLists(lists);
            var merged = MergeKListsRecursion(lists, 0, lists.Length - 1);
            LinkedListHelper.ShowLinkedList(merged);
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            int count = lists.Length;
            if (count == 0)
                return null;
            int newIndex = 0;
            int i = 0;
            while (count > 1)
            {
                while (i < count)
                {
                    if (i == count - 1)
                    {
                        lists[newIndex] = lists[i];
                        newIndex++;
                        break;
                    }
                    var head1 = lists[i];
                    var head2 = lists[i + 1];
                    var mergedHead = MergeTwoLists(head1, head2);
                    lists[newIndex] = mergedHead;
                    i += 2;
                    newIndex++;
                }
                count = newIndex;
                i = 0;
                newIndex = 0;
            }

            return lists[0];
        }

        public ListNode MergeKListsRecursion(ListNode[] lists, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            if (start == end)
            {
                return lists[start];
            }
            var mid = (start + end) >> 1;
            return MergeTwoLists(MergeKListsRecursion(lists, start, mid), MergeKListsRecursion(lists, mid + 1, end));

        }

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

            if (temp2 != null)
            {
                temp.next = temp2;
            }

            return dummyNode.next;
        }

        /// <summary>
        /// 用小顶堆/优先队列实现,K个长度为n的链表，复杂度为O(nkLogK)
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists2(ListNode[] lists)
        {
            var minHeap = new MinHeap<ListNode>(lists, Comparison);
            var head = minHeap.Pop();
            var node = head;
            for (int i = 0; i < lists.Length; i++)
            {
                var tempNode = lists[i].next;
                while (tempNode != null)
                {
                    minHeap.Insert(tempNode);
                    var curNode = minHeap.Pop();
                    node.next = curNode;
                    node = node.next;
                    tempNode = tempNode.next;
                }
            }
            return head;
        }

        private int Comparison(ListNode x, ListNode y)
        {
            return x.val.CompareTo(y.val);
        }
    }
}