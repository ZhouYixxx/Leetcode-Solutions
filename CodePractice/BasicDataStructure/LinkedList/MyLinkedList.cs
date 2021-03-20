
namespace CodePractice.BasicDataStructure.LinkedList
{
    public class MyLinkedList
    {
        public MyLinkedList()
        {
            Head = null;
            Length = 0;
        }

        public MyLinkedList(int val)
        {
            Head = new ListNode(val);
            Length = 1;
        }

        public ListNode Head { get; private set; }
        public int Length { get; private set; }

        //Get the value of the index-th node in the linked list. If the index is invalid, return -1
        public int Get(int index)
        {
            var node = GetNode(index);
            return node == null ? -1: node.val;
        }

        private ListNode GetNode(int index)
        {
            var dummyNode = new ListNode(-1);
            dummyNode.next = Head;
            var node = dummyNode;
            while (index >= 0 && node != null)
            {
                node = node.next;
                index--;
            }
            return node;
        }

        // Add a node of value val before the first element of the linked list. After the insertion,
        // the new node will be the first node of the linked list.
        public void AddAtHead(int val)
        {
            var newNode = new ListNode(val);
            if (Head == null)
            {
                Head = new ListNode(val);
                Length++;
                return;
            }
            newNode.next = Head;
            Head = newNode;
            Length++;
        }


        //Append a node of value val to the last element of the linked list.
        public void AddAtTail(int val)
        {
            if (Head == null)
            {
                Head = new ListNode(val);
                Length++;
                return;
            }
            var newNode = new ListNode(val);
            var tail = Head;
            while (tail.next != null)
            {
                tail = tail.next;
            }
            tail.next = newNode;
            Length++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list,
         the node will be appended to the end of linked list.If index is greater than the length, the node will not be inserted.*/
        public void AddAtIndex(int index,int val)
        {
            if (index > Length)
                return;
            if (index <= 0)
                AddAtHead(val);
            var prevNode = GetNode(index - 1);
            var node = prevNode.next;
            var newNode = new ListNode(val);
            prevNode.next = newNode;
            newNode.next = node;
            Length++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= Length)
                return;
            if (index == 0)
            {
                Head = Head.next;
                Length--;
                return;
            }
            var prevNode = GetNode(index - 1);
            if (prevNode.next != null)
            {
                prevNode.next = prevNode.next.next;
                Length--;
            }
        }
    }
}