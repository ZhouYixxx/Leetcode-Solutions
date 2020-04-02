using System;

namespace CodePractice.BasicDataStructure.LinkedList
{
    public class MergeTwoLists
    {
        public static Node<int> Merge(Node<int> node1, Node<int> node2) 
        {
            Node<int> hNode = node1.Value >= node2.Value ? node2 : node1;
            while (node1 !=null && node2 != null)
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

                if (node2.Value <= node1.Value )
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

            var hNode = Merge(head1, head2);
            while (hNode != null)
            {
                Console.Write(hNode.NextNode != null ? $"{hNode.Value} --> " : $"{hNode.Value}");
                hNode = hNode.NextNode;
            }
            Console.ReadKey();
        }
    }
}