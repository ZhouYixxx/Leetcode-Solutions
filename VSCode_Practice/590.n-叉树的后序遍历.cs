/*
 * @lc app=leetcode.cn id=590 lang=csharp
 *
 * [590] N 叉树的后序遍历
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
using System;
using System.Collections.Generic;

public class Solution590 {
    public IList<int> Postorder(Node root) 
    {
        var res = new List<int>();
        if (root == null)
        {
            return res;
        }
        var stack = new Stack<Node>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            //把当前节点入栈
            root = stack.Pop();
            res.Add(root.val);
            if (root.children != null)
            {            
                //把所有子节点从右到左入栈
                for (int i = 0; i < root.children.Count; i++)
                {
                    var child = root.children[i];
                    if (child != null)
                    {
                        stack.Push(child);
                    }
                }   
            }
        }
        res.Reverse();
        return res;
    }


    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val,IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
    
}
// @lc code=end

