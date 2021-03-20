namespace CodePractice.BasicDataStructure.LinkedList
{
    /// <summary>
    /// 链表的节点
    /// </summary>
    public class Node<T>
    {
        public Node()
        {
            Value = default(T);
        }

        public Node(T value, Node<T> prevNode = null, Node<T> nextNode = null)
        {
            Value = value;
            PrevNode = prevNode;
            NextNode = nextNode;
        }

        public T Value { get; set; }

        public Node<T> PrevNode { get; set; }

        public Node<T> NextNode { get; set; }
    }
}