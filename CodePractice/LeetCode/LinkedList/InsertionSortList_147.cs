using System;
using System.Runtime.InteropServices;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class InsertionSortList_147 : LeetCodeBase
    {
        /// <summary>
        /// 采用插入排序法排序链表
        /// </summary>
        public InsertionSortList_147() : base("InsertionSortList_147")
        {
            Test();
        }

        public void Test()
        {
            var nums = new int[] {1,1};
            var head1 = LinkedListHelper.InitLinkedListByArray(nums);
            LinkedListHelper.ShowLinkedList(head1,false);
            var head = InsertionSortList(head1);
            LinkedListHelper.ShowLinkedList(head);
        }

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            var dummyNode = new ListNode(0) {next = head};
            var lastSortedNode = head;
            var curNode = head.next;
            while (curNode != null)
            {
                if (curNode.val >= lastSortedNode.val)
                {
                    lastSortedNode = curNode;
                }
                else
                {
                    var prev = dummyNode;
                    while (prev.next != null)
                    {
                        if (prev.next.val <= curNode.val)
                        {
                            prev = prev.next;
                            continue;
                        }

                        lastSortedNode.next = curNode.next;
                        var temp = prev.next;
                        prev.next = curNode;
                        curNode.next = temp;
                        break;
                    }
                }
                curNode = lastSortedNode.next;
            }
            return dummyNode.next;
        }
    }
}