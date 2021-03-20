using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    /// <summary>
    /// 链表反转
    /// </summary>
    public class ReverseLinkedList : LeetCodeBase
    {
        /// <summary>
        /// 测试
        /// </summary>
        public static void Test()
        {
            var head = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);
            var node6 = new Node<int>(6);
            head.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;
            node4.NextNode = node5;
            node5.NextNode = node6;
            node6.NextNode = null;
            //原有链表
            var curNode = head;
            while (curNode != null)
            {
                Console.Write($"{curNode.Value} -> ");
                curNode = curNode.NextNode;
            }
            Console.Write("null");
            var newHead = ReverseLinkedList.Reverse(head);
            Console.WriteLine();
            //反转后的链表
            curNode = newHead;
            while (curNode != null)
            {
                Console.Write($"{curNode.Value} -> ");
                curNode = curNode.NextNode;
            }
            Console.Write("null");

            //原有链表(测试.Net自带链表)
            Console.WriteLine();
            var list2 = new LinkedList<int>();
            list2.AddFirst(1);
            list2.AddLast(2);
            list2.AddLast(3);
            list2.AddLast(4);
            list2.AddLast(5);
            list2.AddLast(6);
            foreach (var item in list2)
            {
                Console.Write($"{item} -> ");
            }
            Console.Write("null");

            //反转后的链表(测试.Net自带链表)
            Console.WriteLine();
            list2 = new LinkedList<int>(list2.Reverse());
            foreach (var item in list2)
            {
                Console.Write($"{item} -> ");
            }
            Console.Write("null");
            Console.ReadKey();
        }

        public static Node<T> Reverse<T>(Node<T> headNode)
        {
            if (headNode?.NextNode == null)
            {
                return headNode;
            }
            var curNode = headNode;
            var nextNode = headNode.NextNode;
            //注意各个节点的引用改变的顺序，应当遵循先使用，后改变的原则
            while (nextNode != null)
            {
                //nextNode的下一个节点，保存在next当中备用
                var next = nextNode.NextNode;
                //nextNode的下一个节点重新指向curNode
                nextNode.NextNode = curNode;
                curNode = nextNode;
                //nextNode赋值为next
                nextNode = next;
            }
            headNode.NextNode = null;
            return curNode;
        }

        public ReverseLinkedList() : base("ReverseLinkedList")
        {
            Test();
        }
    }
}