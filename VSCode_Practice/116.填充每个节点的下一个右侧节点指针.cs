/*
 * @lc app=leetcode.cn id=116 lang=csharp
 *
 * [116] 填充每个节点的下一个右侧节点指针
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/
using System.Collections.Generic;

public class Solution116 {
    public void Test()
    {
        var root = new Node(1);
        root.left = new Node(2);
        root.right = new Node(3);
        var left = root.left;
        var right = root.right;
        left.left = new Node(4);
        left.right = new Node(5);
        right.left = new Node(6);
        right.right = new Node(7);
        var ans = Connect2(root);
    }

    /// <summary>
    /// 层次遍历
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public Node Connect(Node root)
    {
        if (root == null)
            return root;
        root.next = null;
        var queue = new Queue<Node>(2048);
        queue.Enqueue(root);
        var list = new List<Node>(2048);
        while (queue.Count > 0)
        {
            var size = queue.Count;
            // var list = new List<Node>();
            while (size-- > 0)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                {
                    list.Add(node.left);
                }
                if (node.right != null)
                {
                    list.Add(node.right);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].next = i == list.Count-1 ? null : list[i+1];
                queue.Enqueue(list[i]);
            }
            list.Clear();
        }
        return root;
    }

    /// <summary>
    /// 递归写法
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public Node Connect2(Node root)
    {
        if (root == null)
        {
            return null;
        }
        if (root.left != null)
        {
            root.left.next = root.right;
            root.right.next = root.next == null ? null : root.next.left;
            Connect2(root.left);
            Connect2(root.right);
        }
        return root;
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}


// @lc code=end

