using System;
using CodePractice.BasicDataStructure.LinkedList;

namespace CodePractice.LeetCode.LinkedList
{
    public class CheckCircle
    {

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
            node6.NextNode = node4;
            var isCircleExisted = IsCircleExisted(head);
            Console.WriteLine(isCircleExisted ? "当前链表中存在环" : "当前链表中不存在环");
            Console.ReadKey();
        }

        public static bool IsCircleExisted<T>(Node<T> head)
        {
            if (head == null)
            {
                return false;
            }
            var slowNode = head;
            var fastNode = head;
            while (fastNode != null)
            {
                slowNode = slowNode?.NextNode;
                fastNode = fastNode.NextNode?.NextNode;
                if (slowNode == fastNode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}