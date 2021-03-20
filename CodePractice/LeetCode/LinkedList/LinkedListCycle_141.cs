using System;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class LinkedListCycle_141: LeetCodeBase
    {
        public LinkedListCycle_141() : base("LinkedListCycle_141")
        {
            var head = LinkedListHelper.InitLinkedListByArray(new int[] { 3, 2, 0, 4 }, -1);
            Console.WriteLine(HasCycle(head));
            Console.ReadKey();
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            var fastNode = head;
            var slowNode = head;
            while (fastNode?.next != null)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;
                if (fastNode == slowNode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}