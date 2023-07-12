public class Solution_Offer06 {
    public void Test() {
        var arr = new int[]{1};
        var node = DataStructureHelper.GenerateLinkedListFromArray(arr);
        var ans = ReversePrint(node);
    }

    public int[] ReversePrint(ListNode head) {
        var lst = new List<int>();
        var node = head;
        while (node != null) {
            lst.Add(node.val);
            node = node.next;
        }
        lst.Reverse();
        return lst.ToArray();
    }
}