using System;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class DeleteNode : LeetCodeBase
    {
        /// <summary>
        /// 删除倒数第n个元素（一次遍历）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        /// <param name="n"></param>
        public static void DeleteAt<T>(Node<T> head, int n)
        {
            if (n <= 0)
                return;
            var fast = head;
            var slow = head;
            while (n != 0 && fast != null)
            {
                fast = fast.NextNode;
                n--;
            }
            if (fast == null)
                throw new Exception("当前链表的长度小于指定数值！");

            while (fast.NextNode != null)
            {
                fast = fast.NextNode;
                slow = slow.NextNode;
            }

            //删除
            if (slow.NextNode == null)
            {
                slow = null;
            }
            else
            {
                slow.NextNode = slow.NextNode.NextNode;
            }

        }

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
            Console.WriteLine();
            DeleteAt(head, 2);
            //删除一个节点
            while (head != null)
            {
                Console.Write($"{head.Value} -> ");
                head = head.NextNode;
            }
            Console.Write("null");
            Console.ReadKey();
        }

        public DeleteNode() : base("DeleteNode")
        {
            Test();
        }
    }
}