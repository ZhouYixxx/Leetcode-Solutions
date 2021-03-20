using System;
using System.Collections;
using System.Collections.Generic;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class PalindromeList_234: LeetCodeBase
    {
        public PalindromeList_234() : base("PalindromeList_234")
        {
            var head = LinkedListHelper.InitLinkedListByArray(new[] { 1, 2 });
            Console.WriteLine(IsPalindrome(head));
            Console.ReadKey();
        }
        
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;
            if (head.next == null)
                return true;
            var nodes = new List<ListNode>();
            //找到中间节点，同时把所有元素放入列表
            var dummy = new ListNode(-1);
            dummy.next = head;
            var node = dummy.next;
            while (node != null)
            {
                var tempNode = node;
                nodes.Add(tempNode);
                node = node.next;
            }
            var midIndex = nodes.Count >> 1;
            for (int i = 0; i < midIndex; i++)
            {
                var palinIndex = nodes.Count - 1 - i;
                if (nodes[i].val != nodes[palinIndex].val)
                {
                    return false;
                }
            }
            return true;
        }
    }
}