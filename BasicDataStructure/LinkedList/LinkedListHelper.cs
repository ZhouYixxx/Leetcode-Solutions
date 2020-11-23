using System;
using CodePractice.LeetCode.LinkedList;

namespace CodePractice.BasicDataStructure.LinkedList
{
    public static class LinkedListHelper
    {
        public static ListNode InitLinkedListByArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return null;
            }
            var head = new ListNode(nums[0]);
            var node = head;
            for (int i = 1; i < nums.Length; i++)
            {
                node.next = new ListNode(nums[i]);
                node = node.next;
            }
            return head;
        }

        public static void ShowLinkedList(ListNode head, bool needPause = true)
        {
            while (head != null)
            {
                var text = head.next == null ? $"{head.val}" : $"{head.val} -> ";
                Console.Write(text);
                head = head.next;
            }
            Console.WriteLine();
            if (needPause)
            {
                Console.ReadKey();
            }
        }
    }
}