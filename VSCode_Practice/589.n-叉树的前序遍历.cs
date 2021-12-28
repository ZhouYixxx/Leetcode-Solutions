/*
 * @lc app=leetcode.cn id=589 lang=csharp
 *
 * [589] N 叉树的前序遍历
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

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
using System;
using System.Collections.Generic;

public class Solution589 {
    public IList<int> Preorder(Node root) 
    {
        var ans = new List<int>();
        PreOrder_Recursive(ans, root);
        return ans;
    }

    private void PreOrder_Recursive(IList<int> res, Node node)
    {
        if (node == null)
        {
            return;
        }
        res.Add(node.val);
        for (int i = 0; i < node.children.Count; i++)
        {
            PreOrder_Recursive(res,node.children[i]);
        }
    }

    /// <summary>
    /// 迭代写法
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private IList<int> PreOrder_Iterator(Node node)
    {
        var res = new List<int>();
        if (node == null)
        {
            return res;
        }
        var stack = new Stack<Node>();
        stack.Push(node);
        while (stack.Count > 0)
        {
            var top = stack.Pop();
            res.Add(top.val);
            if (top.children != null)
            {
                for (int i = top.children.Count-1; i >= 0; i--)
                {
                    var child = top.children[i];
                    if (child != null)
                    {
                        stack.Push(child);
                    }
                }   
            }
        }
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

