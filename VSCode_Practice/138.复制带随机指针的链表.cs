/*
 * @lc app=leetcode.cn id=138 lang=csharp
 *
 * [138] 复制带随机指针的链表
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution_138 {

    public void Test() {
        var head = new MyNode(7) { random = null};
        var node1 = new MyNode(13) { random = null};
        var node2 = new MyNode(11) { random = null};
        var node3 = new MyNode(10) { random = null};
        var node4 = new MyNode(1) { random = null};
        head.next = node1;
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = null;
        var ans = CopyRandomList(head);
    }

    public MyNode CopyRandomList(MyNode head) {
        if (head == null) return head;
        //一次遍历：创建所有的节点
        var map = new Dictionary<MyNode, MyNode>();
        var node = head;
        while (node != null)
        {
            var newNode = new MyNode(node.val);
            map.Add(node, newNode);
            node = node.next;
        }
        //二次遍历：更新next和random
        foreach (var oldNode in map.Keys)
        {
            var newNode = map[oldNode];
            var new_next = oldNode.next == null ? null : map[oldNode.next];
            var new_random = oldNode.random == null ? null : map[oldNode.random];
            newNode.next = new_next;
            newNode.random = new_random;
        }
        return map[head];
    }
}

public class MyNode {
    public int val;
    public MyNode next;
    public MyNode random;
    
    public MyNode(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
// @lc code=end

