using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.LinkedList
{
    public class RemoveNthFromEnd_19 :LeetCodeBase
    {
        public RemoveNthFromEnd_19() : base("RemoveNthFromEnd_19")
        {
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //倒数第N个节点，和最后一个节点相差N-1
            var dummy = new ListNode(-1);
            dummy.next = head;
            var fast = dummy;
            var slow = dummy;
            while (n > 0)
            {
                fast = fast.next;
                n--;
            }
            while (fast?.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            var delNode = slow.next;
            slow.next = delNode == null ? null : delNode.next;
            return dummy.next;
        }
    }
}