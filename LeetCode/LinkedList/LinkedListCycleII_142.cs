using System;
using System.Runtime.Serialization.Formatters;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class LinkedListCycleII_142 : LeetCodeBase
    {
        public LinkedListCycleII_142() : base("LinkedListCycleII_142")
        {
            var head = LinkedListHelper.InitLinkedListByArray(new int[] { 3, 2, 0, -4 }, 1);
            var circleNode = DetectCycle(head);
            Console.WriteLine(circleNode.val);
            Console.ReadKey();
        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode fast = head;
            ListNode slow = head;
            bool hasCircle = false;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                {
                    hasCircle = true;
                    break;
                }
            }
            //没有环存在，返回null
            if (!hasCircle || slow == null)
            {
                return null;
            }
            if (slow == head)
            {
                return head;
            }
            //关键点：此时head与slow节点与环的入口节点处的距离相同。
            var temp = head;
            while (temp != slow)
            {
                slow = slow.next;
                temp = temp.next;
            }
            return temp;
        }
    }
}