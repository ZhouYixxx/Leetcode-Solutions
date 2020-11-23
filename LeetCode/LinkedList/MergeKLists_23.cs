using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
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
            var merged = MergeKLists(lists);
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
    }
}