using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class OddEvenList_328 : LeetCodeBase
    {
        public OddEvenList_328() : base("OddEvenList_328")
        {
            var head = LinkedListHelper.InitLinkedListByArray(new int[] { 1, 2, 3, 4, 5,6 });
            LinkedListHelper.ShowLinkedList(head,false);
            var node = OddEvenList(head);
            LinkedListHelper.ShowLinkedList(node);
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var oddHead = head;
            var evenHead = head.next;
            var odd = oddHead;
            var even = evenHead;
            //temp记录odd当前的值，当odd为空时，则取它上一个值
            var temp = odd;
            while (odd != null && odd.next != null)
            {
                odd.next = odd.next.next;
                temp = odd;
                odd = odd.next;
                if (even != null && even.next != null)
                {
                    even.next = even.next.next;
                    even = even.next;
                }
            }
            odd = odd ?? temp;
            odd.next = evenHead;
            return oddHead;
        }
    }
}