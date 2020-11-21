using System;
using CodePractice.BasicDataStructure.LinkedList;

namespace CodePractice.LeetCode.LinkedList
{

    public class MergeTwoLists
    {
        public ListNode MergeTwoLists1(ListNode l1, ListNode l2)
        {
            ListNode preHead = new ListNode(0);
            ListNode prevNode = preHead;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prevNode.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prevNode.next = l2;
                    l2 = l2.next;
                }
                prevNode = prevNode.next;
            }
            if (l1 != null)
            {
                prevNode.next = l1;
            }
            if (l2 != null)
            {
                prevNode.next = l2;
            }
            return preHead.next;
        }

        /// <summary>
        /// 迭代法
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static Node<int> Merge(Node<int> node1, Node<int> node2)
        {
            Node<int> hNode = node1.Value >= node2.Value ? node2 : node1;
            while (node1 != null && node2 != null)
            {
                if (node1.Value <= node2.Value)
                {
                    if (node1.NextNode != null && node1.NextNode.Value >= node2.Value)
                    {
                        var tempNode = node1.NextNode;
                        node1.NextNode = node2;
                        node1 = tempNode;
                        //node2 = node2.NextNode;
                    }
                    else
                    {
                        var tempNode = node1.NextNode;
                        if (node2.NextNode == null)
                        {
                            node1.NextNode = node2;
                        }
                        node1 = tempNode;
                    }
                    continue;
                }

                if (node2.Value <= node1.Value)
                {
                    if (node2.NextNode != null && node2.NextNode.Value >= node1.Value)
                    {
                        var tempNode = node2.NextNode;
                        node2.NextNode = node1;
                        node2 = tempNode;
                        //node1 = node1.NextNode;
                    }
                    else
                    {
                        var tempNode = node2.NextNode;
                        if (node2.NextNode == null)
                        {
                            node2.NextNode = node1;
                        }
                        node2 = tempNode;
                    }
                }
            }

            return hNode;
        }

        /// <summary>
        /// 迭代法（采用带头结点的链表,无需考虑NextNode为null的情况）
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static Node<int> Merge2(Node<int> node1, Node<int> node2)
        {
            Node<int> preHead = new Node<int>();
            Node<int> prevNode = preHead;
            while (node1 != null && node2 != null)
            {
                if (node1.Value <= node2.Value)
                {
                    prevNode.NextNode = node1;
                    node1 = node1.NextNode;
                }
                else
                {
                    prevNode.NextNode = node2;
                    node2 = node2.NextNode;
                }
                prevNode = prevNode.NextNode;
            }
            prevNode.NextNode = node1 ?? node2;
            return preHead.NextNode;
        }

        /// <summary>
        /// 递归法,递归法的思想类似于数学归纳法
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists2(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists2(l2.next, l1);
                return l2;
            }
        }

        public static void Test()
        {
            var head1 = new Node<int>(1);
            var node1 = new Node<int>(4);
            var node2 = new Node<int>(7);
            var node3 = new Node<int>(13);

            var head2 = new Node<int>(2);
            var node4 = new Node<int>(5);
            var node5 = new Node<int>(9);
            var node6 = new Node<int>(10);
            head1.NextNode = node1;
            node1.NextNode = node2;
            node2.NextNode = node3;

            head2.NextNode = node4;
            node4.NextNode = node5;
            node5.NextNode = node6;

            var hNode = Merge2(head1, head2);
            while (hNode != null)
            {
                Console.Write(hNode.NextNode != null ? $"{hNode.Value} --> " : $"{hNode.Value}");
                hNode = hNode.NextNode;
            }
            Console.ReadKey();
        }
    }
}