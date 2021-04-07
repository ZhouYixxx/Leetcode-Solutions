using System;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class CheckCircle : LeetCodeBase
    {

        public static void Test()
        {

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

        public CheckCircle() : base("CheckCircle")
        {
            Test();
        }
    }
}